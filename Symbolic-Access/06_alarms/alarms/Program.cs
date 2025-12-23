using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using PLCcom;
using PLCcom.Core.S7Plus.Alarm;
using PLCcom.Enums.S7Plus;
using PLCcom.Requests.S7Plus;
using PLCcom.Results.S7Plus;

namespace Alarms;

internal static class Program
{
    // We lock all console writes so that:
    //  - user input prompts
    //  - asynchronous alarm events
    // do not interleave and become unreadable.
    private static readonly object ConsoleSync = new();

    static void Main(string[] args)
    {
        // Ensure UTF-8 output (useful if alarm texts contain non-ASCII characters).
        Console.OutputEncoding = Encoding.UTF8;

        // Keep culture explicit. PLC alarm texts are delivered per culture/LCID.
        // We follow the WinForms sample logic: prefer CurrentUICulture if available.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;

        // Allow overriding the PLC IP by CLI:
        //   dotnet run -- 192.168.1.10
        var ip = args.Length > 0 ? args[0] : "192.168.1.10";

        // Create device instance.
        // Note: In your snippet you used Tls13Device; in the WinForms sample the variable type is SymbolicDevice.
        // Typically Tls13Device derives from SymbolicDevice; hence we can pass it to alarm helpers expecting SymbolicDevice.
        var device = new Tls13Device(ip);

        try
        {
            // License/authentication: user must provide correct values.
            authentication.User = "";
            authentication.Serial = "";

            SafeWriteLine($"Connecting to {ip} ...");

            var connectResult = device.Connect();
            if (connectResult.IsQualityBad())
            {
                // If connection fails or server certificate is invalid, abort early.
                SafeWriteLine($"Connection failed: {connectResult}");
                return;
            }

            SafeWriteLine("Connected successfully with valid server certificate.");
            SafeWriteLine($"PLCcom for S7 assembly version: {typeof(BasicInfoResult).Assembly.GetName().Version}");

            // All alarm-related behavior is encapsulated in one class:
            //  1) load current active alarms (BrowseActiveAlarms)
            //  2) subscribe to future notifications (AlarmNotification event)
            //  3) provide console commands to list / details / acknowledge
            using var alarms = new PlcAlarmConsole(device, ConsoleSync);

            // Step 1: Load initial state (current active alarms).
            // This is important for customers to see "snapshot + live stream" behavior.
            alarms.LoadActiveAlarmsSnapshot();

            // Step 2: Subscribe to event-based updates (new alarms, state changes, cancellations).
            alarms.SubscribeToAlarmNotifications();

            // Step 3: Keep the process alive and allow interaction via commands.
            RunCommandLoop(alarms);
        }
        catch (Exception ex)
        {
            // In a sample program we want failures to be clearly visible.
            SafeWriteLine($"Unhandled exception: {ex}");
        }
        finally
        {
            // Always disconnect. Even for examples, this is good hygiene and avoids hanging sessions.
            try
            {
                device.DisConnect();
            }
            catch (Exception ex)
            {
                SafeWriteLine($"Disconnect failed: {ex.Message}");
            }
        }
    }

    private static void RunCommandLoop(PlcAlarmConsole alarms)
    {
        // Enable Ctrl+C clean exit (typical console app behavior).
        var exitRequested = false;
        Console.CancelKeyPress += (_, e) =>
        {
            e.Cancel = true;          // Prevent immediate termination
            exitRequested = true;     // Let our loop exit gracefully
        };

        PrintHelp();

        while (!exitRequested)
        {
            WritePrompt();

            // ReadLine blocks until user input; meanwhile alarm events may still print.
            var line = Console.ReadLine();
            if (line is null)
                break;

            line = line.Trim();
            if (line.Length == 0)
                continue;

            // Split into command + optional argument:
            //   list
            //   details <alarmId>
            //   ack <alarmId>
            var parts = line.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            var cmd = parts[0].ToLowerInvariant();
            var arg = parts.Length > 1 ? parts[1].Trim() : string.Empty;

            switch (cmd)
            {
                case "h":
                case "help":
                    PrintHelp();
                    break;

                case "l":
                case "list":
                    alarms.PrintActiveAlarmTable();
                    break;

                case "d":
                case "details":
                    if (arg.Length == 0)
                    {
                        SafeWriteLine("Usage: details <alarmId>");
                        break;
                    }
                    alarms.PrintAlarmDetails(arg);
                    break;

                case "a":
                case "ack":
                    if (arg.Length == 0)
                    {
                        SafeWriteLine("Usage: ack <alarmId>");
                        break;
                    }
                    alarms.Acknowledge(arg);
                    break;

                case "ackall":
                    alarms.AcknowledgeAll();
                    break;

                case "q":
                case "quit":
                case "exit":
                    exitRequested = true;
                    break;

                default:
                    SafeWriteLine($"Unknown command '{cmd}'. Type 'help'.");
                    break;
            }
        }
    }

    private static void PrintHelp()
    {
        SafeWriteLine("");
        SafeWriteLine("Commands:");
        SafeWriteLine("  help                Show this help");
        SafeWriteLine("  list                List currently active alarms (snapshot cache)");
        SafeWriteLine("  details <alarmId>   Print full details for one alarm (similar to WinForms AlarmDetails)");
        SafeWriteLine("  ack <alarmId>       Acknowledge one alarm (if acknowledgeable)");
        SafeWriteLine("  ackall              Acknowledge all acknowledgeable active alarms");
        SafeWriteLine("  quit                Exit the program");
        SafeWriteLine("");
    }

    private static void WritePrompt()
    {
        lock (ConsoleSync)
        {
            Console.Write("> ");
        }
    }

    private static void SafeWriteLine(string message)
    {
        lock (ConsoleSync)
        {
            Console.WriteLine(message);
        }
    }
}

/// <summary>
/// Console-oriented alarm sample which mirrors the WinForms example behavior:
/// - Browse initial active alarms (BrowseActiveAlarms)
/// - Subscribe to AlarmNotification event for real-time updates
/// - Print details like the AlarmDetails dialog
/// - Acknowledge alarms via AckAlarm
///
/// This class deliberately keeps the API usage explicit and readable for customers.
/// </summary>
internal sealed class PlcAlarmConsole : IDisposable
{
    private readonly SymbolicDevice _device;
    private readonly object _consoleSync;

    // Cache active alarms by AlarmId string, so users can reference the ID directly in console commands.
    // Using ConcurrentDictionary allows safe updates from the alarm event callback thread.
    private readonly ConcurrentDictionary<string, AlarmNotification> _activeAlarms = new();

    // Optional: keep a small history of information notifications (not "active alarms").
    // This is purely for demo output convenience; it is not required for alarm acknowledging.
    private readonly ConcurrentQueue<AlarmNotification> _infoHistory = new();
    private const int MaxInfoHistory = 50;

    private bool _subscribed;

    public PlcAlarmConsole(SymbolicDevice device, object consoleSync)
    {
        _device = device ?? throw new ArgumentNullException(nameof(device));
        _consoleSync = consoleSync ?? throw new ArgumentNullException(nameof(consoleSync));
    }

    public void LoadActiveAlarmsSnapshot()
    {
        // The WinForms sample creates the request using CultureInfo.CurrentCulture.
        // That is the "browse call culture" (not necessarily the same as the text LCID selection).
        var request = new BrowseAlarmsRequest(CultureInfo.CurrentCulture);

        // BrowseActiveAlarms returns a result object containing Quality + alarms.
        BrowseAlarmsResult result = _device.BrowseActiveAlarms(request);

        if (result.IsQualityBad())
        {
            // In WinForms this is a MessageBox error; in console we print it.
            SafeWriteLine($"ERROR: Browsing active alarms failed. Quality={result.Quality} Message={result.Message}");
            return;
        }

        // WinForms sample sorts by priority and then populates the UI list.
        // We do the same and populate our cache.
        var alarms = result.getAlarms() ?? Enumerable.Empty<AlarmNotification>();

        foreach (var alarm in alarms.OrderBy(a => a.AlarmPriority))
        {
            _activeAlarms[alarm.AlarmId.ToString()] = alarm;
        }

        SafeWriteLine($"Loaded {_activeAlarms.Count} active alarms (initial snapshot).");
        PrintActiveAlarmTable();
    }

    public void SubscribeToAlarmNotifications()
    {
        if (_subscribed)
            return;

        // Attach event handler for real-time alarm notifications.
        // This mirrors SubscribeAlarms() in the WinForms example. :contentReference[oaicite:2]{index=2}
        _device.AlarmNotification += OnAlarmNotification;
        _subscribed = true;

        SafeWriteLine("Subscribed to AlarmNotification (live updates enabled).");
    }

    public void Unsubscribe()
    {
        if (!_subscribed)
            return;

        // Always detach events to avoid memory leaks and dangling callbacks.
        _device.AlarmNotification -= OnAlarmNotification;
        _subscribed = false;

        SafeWriteLine("Unsubscribed from AlarmNotification.");
    }

    public void PrintActiveAlarmTable()
    {
        // Take a snapshot to print a consistent view, even if events update the dictionary concurrently.
        var snapshot = _activeAlarms.Values
            .OrderBy(a => a.AlarmPriority)
            .ThenBy(a => a.AlarmId.ToString())
            .ToList();

        SafeWriteLine("");
        SafeWriteLine($"Active alarms: {snapshot.Count}");
        SafeWriteLine("----------------------------------------------------------------------------------------------------");
        SafeWriteLine("AlarmId | Priority | MessageType | State | AlarmNo | TS Coming (local)       | AlarmText");
        SafeWriteLine("----------------------------------------------------------------------------------------------------");

        foreach (var alarm in snapshot)
        {
            // In WinForms the timestamp column is TimeStampComing.GetDateTime().ToLocalTime().ToString()
            // but event notifications sometimes use ?.GetDateTime(). We use null-safe formatting.
            var comingLocal = FormatPlcTimestampLocal(alarm.TimeStampComing);

            // Alarm text selection follows WinForms: choose best culture, then take AlarmTextType.AlarmText.
            var alarmText = GetAlarmText(alarm, eAlarmTextType.AlarmText);

            SafeWriteLine($"{alarm.AlarmId} | {alarm.AlarmPriority} | {alarm.MessageType} | {alarm.AlarmState} | {alarm.AlarmNumber} | {comingLocal,-20} | {alarmText}");
        }

        SafeWriteLine("----------------------------------------------------------------------------------------------------");
        SafeWriteLine("");
    }

    public void PrintAlarmDetails(string alarmId)
    {
        // This is the console counterpart to the AlarmDetails dialog.
        // It prints the same logical fields and text breakdown. :contentReference[oaicite:3]{index=3}
        if (!_activeAlarms.TryGetValue(alarmId, out var alarm))
        {
            SafeWriteLine($"Alarm '{alarmId}' not found in active cache.");
            return;
        }

        var textCulture = ChooseBestTextCulture(alarm);

        SafeWriteLine("");
        SafeWriteLine($"Alarm Details - AlarmId={alarm.AlarmId}");
        SafeWriteLine("----------------------------------------------------------------------------------------------------");

        // Core metadata
        SafeWriteLine($"Producer:            {alarm.AlarmProducer}");
        SafeWriteLine($"MessageType:         {alarm.MessageType}");
        SafeWriteLine($"State:               {alarm.AlarmState}");
        SafeWriteLine($"AlarmClass:          {alarm.AlarmClass}");
        SafeWriteLine($"AlarmNumber:         {alarm.AlarmNumber}");
        SafeWriteLine($"Priority:            {alarm.AlarmPriority}");

        SafeWriteLine("");
        SafeWriteLine($"Selected Text Culture: {textCulture.Name} (LCID={textCulture.LCID})");
        SafeWriteLine("");

        // Timestamps
        // In the WinForms details dialog timestamps are displayed using ToString() (may be empty).
        // For console clarity we show both raw and local DateTime if available.
        SafeWriteLine($"TS Coming (raw):     {alarm.TimeStampComing?.ToString() ?? string.Empty}");
        SafeWriteLine($"TS Coming (local):   {FormatPlcTimestampLocal(alarm.TimeStampComing)}");
        SafeWriteLine($"TS Going (raw):      {alarm.TimeStampGoing?.ToString() ?? string.Empty}");
        SafeWriteLine($"TS Going (local):    {FormatPlcTimestampLocal(alarm.TimeStampGoing)}");
        SafeWriteLine($"TS Ack (raw):        {alarm.TimeStampAck?.ToString() ?? string.Empty}");
        SafeWriteLine($"TS Ack (local):      {FormatPlcTimestampLocal(alarm.TimeStampAck)}");

        SafeWriteLine("");
        SafeWriteLine("Texts (filtered by selected culture):");

        // These fields mirror AlarmDetails.cs one-to-one:
        // InfoText, AlarmText, AdditionalText1..9. :contentReference[oaicite:4]{index=4}
        SafeWriteLine($"InfoText:            {GetAlarmText(alarm, eAlarmTextType.InfoText, textCulture)}");
        SafeWriteLine($"AlarmText:           {GetAlarmText(alarm, eAlarmTextType.AlarmText, textCulture)}");
        SafeWriteLine($"AdditionalText1:     {GetAlarmText(alarm, eAlarmTextType.AdditionalText1, textCulture)}");
        SafeWriteLine($"AdditionalText2:     {GetAlarmText(alarm, eAlarmTextType.AdditionalText2, textCulture)}");
        SafeWriteLine($"AdditionalText3:     {GetAlarmText(alarm, eAlarmTextType.AdditionalText3, textCulture)}");
        SafeWriteLine($"AdditionalText4:     {GetAlarmText(alarm, eAlarmTextType.AdditionalText4, textCulture)}");
        SafeWriteLine($"AdditionalText5:     {GetAlarmText(alarm, eAlarmTextType.AdditionalText5, textCulture)}");
        SafeWriteLine($"AdditionalText6:     {GetAlarmText(alarm, eAlarmTextType.AdditionalText6, textCulture)}");
        SafeWriteLine($"AdditionalText7:     {GetAlarmText(alarm, eAlarmTextType.AdditionalText7, textCulture)}");
        SafeWriteLine($"AdditionalText8:     {GetAlarmText(alarm, eAlarmTextType.AdditionalText8, textCulture)}");
        SafeWriteLine($"AdditionalText9:     {GetAlarmText(alarm, eAlarmTextType.AdditionalText9, textCulture)}");

        SafeWriteLine("----------------------------------------------------------------------------------------------------");
        SafeWriteLine("");
    }

    public void Acknowledge(string alarmId)
    {
        // Console equivalent of the WinForms "Acknowledge" button:
        // it calls device.AckAlarm(alarm.AlarmId). :contentReference[oaicite:5]{index=5}
        if (!_activeAlarms.TryGetValue(alarmId, out var alarm))
        {
            SafeWriteLine($"Alarm '{alarmId}' not found in active cache.");
            return;
        }

        // In the WinForms sample the button is only enabled for acknowledgeable alarms.
        // Here we check and reject non-acknowledgeable alarms for clarity.
        if (alarm.MessageType != eAlarmMessageType.AcknowledgeableAlarm)
        {
            SafeWriteLine($"Alarm '{alarmId}' is not acknowledgeable (MessageType={alarm.MessageType}).");
            return;
        }

        OperationResult res = _device.AckAlarm(alarm.AlarmId);

        if (res.IsQualityGood())
            SafeWriteLine($"ACK OK: AlarmId={alarm.AlarmId} Quality={res.Quality}");
        else
            SafeWriteLine($"ACK FAILED: AlarmId={alarm.AlarmId} Quality={res.Quality} Message={res.Message}");
    }

    public void AcknowledgeAll()
    {
        // Demo helper: acknowledge every acknowledgeable alarm currently in the cache.
        var ids = _activeAlarms.Values
            .Where(a => a.MessageType == eAlarmMessageType.AcknowledgeableAlarm)
            .Select(a => a.AlarmId.ToString())
            .Distinct()
            .ToList();

        if (ids.Count == 0)
        {
            SafeWriteLine("No acknowledgeable alarms found.");
            return;
        }

        SafeWriteLine($"Acknowledging {ids.Count} alarm(s) ...");
        foreach (var id in ids)
            Acknowledge(id);
    }

    private void OnAlarmNotification(object? sender, AlarmNotificationEventArgs e)
    {
        // This event is raised asynchronously by PLCcom whenever:
        //  - a new alarm appears
        //  - an alarm changes its state
        //  - an alarm becomes NotActive or Canceled
        //  - an information notification is emitted
        //
        // The WinForms sample distinguishes:
        //  - AcknowledgeableAlarm / NonAcknowledgeableAlarm -> goes to alarm list
        //  - InformationNotification -> goes to information list :contentReference[oaicite:6]{index=6}
        var alarm = e.Alarm;
        if (alarm is null)
            return;

        var id = alarm.AlarmId.ToString();

        switch (alarm.MessageType)
        {
            case eAlarmMessageType.AcknowledgeableAlarm:
            case eAlarmMessageType.NonAcknowledgeableAlarm:
                {
                    // WinForms removes alarms if NotActive or Canceled.
                    // We do the same by removing from our active cache.
                    if (alarm.AlarmState == eAlarmState.NotActive || alarm.AlarmState == eAlarmState.Canceled)
                    {
                        _activeAlarms.TryRemove(id, out _);

                        SafeWriteLine(
                            $"[{NowTime()}] ALARM REMOVED | Id={id} | State={alarm.AlarmState} | Text={GetAlarmText(alarm, eAlarmTextType.AlarmText)}");
                    }
                    else
                    {
                        // Otherwise keep the newest alarm snapshot in the cache.
                        _activeAlarms[id] = alarm;

                        SafeWriteLine(
                            $"[{NowTime()}] ALARM UPDATE  | Id={id} | Type={alarm.MessageType} | State={alarm.AlarmState} | Text={GetAlarmText(alarm, eAlarmTextType.AlarmText)}");
                    }

                    break;
                }

            case eAlarmMessageType.InformationNotification:
                {
                    // Information notifications are typically not "active alarms" to be acknowledged.
                    // We print them and keep a small bounded history.
                    EnqueueInfo(alarm);

                    SafeWriteLine(
                        $"[{NowTime()}] INFO          | Id={id} | TS={FormatPlcTimestampLocal(alarm.TimeStampComing)} | Text={GetAlarmText(alarm, eAlarmTextType.AlarmText)}");
                    break;
                }

            default:
                {
                    // Defensive: if PLCcom introduces new message types, this sample won't silently ignore them.
                    SafeWriteLine($"[{NowTime()}] UNKNOWN MSG   | Id={id} | MessageType={alarm.MessageType}");
                    break;
                }
        }
    }

    private void EnqueueInfo(AlarmNotification info)
    {
        _infoHistory.Enqueue(info);

        // Simple bounded queue: keep only the last N info notifications.
        while (_infoHistory.Count > MaxInfoHistory)
            _infoHistory.TryDequeue(out _);
    }

    private static string NowTime()
        => DateTime.Now.ToString("HH:mm:ss");

    private static string FormatPlcTimestampLocal(object? plcTimestamp)
    {
        // PLCcom timestamps in your WinForms sample expose GetDateTime().
        // We keep the call explicit so customers see the intended API usage. :contentReference[oaicite:7]{index=7}
        if (plcTimestamp is null)
            return string.Empty;

        // We cannot strongly type plcTimestamp here without the concrete PLCcom timestamp type,
        // but dynamic is still readable for a demo and avoids reflection noise.
        try
        {
            dynamic ts = plcTimestamp;
            DateTime dt = (DateTime)ts.GetDateTime();
            return dt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }
        catch
        {
            // If GetDateTime() is not available (or fails), fall back to ToString().
            return plcTimestamp.ToString() ?? string.Empty;
        }
    }

    private static CultureInfo ChooseBestTextCulture(AlarmNotification alarm)
    {
        // This is identical to the WinForms decision logic:
        //  1) If CurrentUICulture LCID exists in TextCultureInfos -> use it
        //  2) otherwise use the first available culture in TextCultureInfos
        //  3) if anything is missing -> fall back to CurrentUICulture :contentReference[oaicite:8]{index=8}
        var ui = Thread.CurrentThread.CurrentUICulture;

        try
        {
            if (alarm.TextCultureInfos != null)
            {
                if (alarm.TextCultureInfos.ContainsKey(ui.LCID))
                    return ui;

                var first = alarm.TextCultureInfos.FirstOrDefault().Value;
                if (first != null)
                    return first;
            }
        }
        catch
        {
            // Ignore and fall back.
        }

        return ui;
    }

    private static string GetAlarmText(AlarmNotification alarm, eAlarmTextType textType)
    {
        // Convenience overload: choose best culture automatically.
        var culture = ChooseBestTextCulture(alarm);
        return GetAlarmText(alarm, textType, culture);
    }

    private static string GetAlarmText(AlarmNotification alarm, eAlarmTextType textType, CultureInfo culture)
    {
        // AlarmTextEntries contains multiple items:
        //  - per culture (LCID)
        //  - per text type (InfoText / AlarmText / AdditionalTextX)
        //
        // WinForms filters by culture and picks the requested AlarmTextType. :contentReference[oaicite:9]{index=9}
        try
        {
            var entries = alarm.AlarmTextEntries?
                .Where(a => a.Culture != null && a.Culture.LCID == culture.LCID)
                .ToList();

            if (entries == null || entries.Count == 0)
                return string.Empty;

            return entries.FirstOrDefault(a => a.AlarmTextType == textType)?.Text ?? string.Empty;
        }
        catch
        {
            // Keep demo resilient: never throw from a helper used in event callbacks.
            return string.Empty;
        }
    }

    private void SafeWriteLine(string message)
    {
        lock (_consoleSync)
        {
            Console.WriteLine(message);
        }
    }

    public void Dispose()
    {
        // Ensure we detach from events when the program exits.
        Unsubscribe();
    }
}
