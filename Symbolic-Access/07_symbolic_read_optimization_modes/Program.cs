using System;
using PLCcom;
using PLCcom.Core.S7Plus.Variables;
using PLCcom.Requests.S7Plus;

internal class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.start(args);
    }

    private void start(string[] args)
    {
        // Important !!!!!!!!!!!!!!!!!! (License)
        // Enter your Username + Serial here!
        // Please note: Without a license key (empty fields), the runtime is limited to 10 minutes.
        authentication.User = "";   // Please enter your user name
        authentication.Serial = ""; // Please enter your user serial key

        // Create a device object for the modern TLS access (TIA Version 17 or higher).
        // Note: You can pass user and/or password information with:
        //   new Tls13Device("192.168.1.100", "user", "password");
        SymbolicDevice mySymbolicDevice = new Tls13Device("192.168.1.100");

        // Or, if you want to use the legacy access for older TIA / firmware versions:
        // SymbolicDevice mySymbolicDevice = new LegacySymbolicDevice("192.168.1.100");

        // Register project import progress event (useful for large projects).
        mySymbolicDevice.OnProjectImportProgressChanged += SymbolicDevice_OnProjectImportProgressChanged;

        ConnectResult connectResult = mySymbolicDevice.Connect();
        if (connectResult.Quality != OperationResult.eQuality.GOOD)
        {
            Console.WriteLine($"Connect not successfull! Quality: {connectResult.Quality} Message: {connectResult.Message}");
            return;
        }

        // =========================================================================
        // Symbolic Read Optimization (IMPORTANT)
        // =========================================================================
        //
        // PLCcom can optimize symbolic read operations by reducing the number of PLC read
        // operations needed to fetch many variables.
        //
        // Why this matters:
        // - Reading many variables individually can create many round-trips and overhead.
        // - Optimization modes allow PLCcom to group variables into fewer requests when beneficial.
        // - Result: usually lower latency and higher throughput, especially for larger variable sets.
        //
        // Trade-off / guidance:
        // - NONE provides maximum transparency and is the best choice for troubleshooting because
        //   every variable is read individually (deterministic behavior).
        // - Higher modes generally mean "more aggressive grouping" (fewer read operations), which
        //   can improve performance but makes the internal request breakdown less transparent.
        //
        // Available modes (in increasing optimization strength):
        //   0 = NONE         -> No optimization (each variable read individually)
        //   1 = OBJECT_BASED -> PLCcom may group variables within ONE root object (e.g., same DB/struct/array)
        //   2 = CROSS_OBJECT -> PLCcom may also group across MULTIPLE root objects (e.g., multiple DBs)
        //   3 = SMART        -> Smart execution plan (TLS connections only)
        //
        // Important note about SMART:
        // - SMART is only supported when you use a TLS-based device (Tls13Device).
        // - Do NOT use SMART with LegacySymbolicDevice. Use NONE / OBJECT_BASED / CROSS_OBJECT instead.
        //
        // How to apply:
        // - The optimization mode is passed when creating the ReadSymbolicRequest:
        //     new ReadSymbolicRequest(eSymbolicReadOptimizationMode.CROSS_OBJECT)
        // - This setting affects symbolic READ operations only (writes are NOT affected).
        //
        // Tip for customers:
        // - Start with NONE while developing/debugging.
        // - Switch to OBJECT_BASED or CROSS_OBJECT once everything works, to reduce cycle time.
        // - Use SMART (Tls13Device only) for best "hands-off" performance on TLS connections.
        // =========================================================================

        // Choose an optimization mode.
        // You can change this single line to test the impact on performance.
        eSymbolicReadOptimizationMode optimizationMode = eSymbolicReadOptimizationMode.NONE;

        // Enforce the SMART constraint: SMART must only be used with Tls13Device.
        // This keeps the sample unambiguous and avoids confusion for customers using legacy connections.
        if (optimizationMode == eSymbolicReadOptimizationMode.SMART && mySymbolicDevice is not Tls13Device)
        {
            Console.WriteLine("WARNING: SMART optimization is only available with Tls13Device (TLS). Falling back to CROSS_OBJECT.");
            optimizationMode = eSymbolicReadOptimizationMode.CROSS_OBJECT;
        }

        Console.WriteLine($"Using symbolic read optimization mode: {optimizationMode}");

        // Which variables do you want to read?
        // Pass the optimization mode directly into the request constructor:
        //   - higher mode => more aggressive grouping => usually fewer PLC read operations.
        ReadSymbolicRequest readRequest = new ReadSymbolicRequest(optimizationMode);
        readRequest.AddFullVariableName("DataBlock_1.ByteValue");
        readRequest.AddFullVariableName("DataBlock_1.RealValue");
        readRequest.AddFullVariableName("DataBlock_1.SIntValue");
        readRequest.AddFullVariableName("DataBlock_1.UDIntValue");

        // Read from device
        Console.WriteLine("Begin Read...");
        var readResult = mySymbolicDevice.ReadData(readRequest);

        // Evaluate results
        if (readResult.Quality == OperationResult.eQuality.GOOD ||
            readResult.Quality == OperationResult.eQuality.WARNING_PARTITIAL_BAD)
        {
            foreach (PlcCoreVariable variable in readResult.Variables)
            {
                if (variable is PlcErrorValue error)
                {
                    Console.WriteLine($"Error can not read: {error.VariableDetails.FullVariableName} {error}");
                }
                else
                {
                    Console.WriteLine($"{variable.VariableDetails.FullVariableName} Value: {variable.Value}");
                }
            }
        }
        else
        {
            Console.WriteLine($"Read not successfull! Message: {readResult.Message}");
        }

        // Deregister project import progress event
        mySymbolicDevice.OnProjectImportProgressChanged -= SymbolicDevice_OnProjectImportProgressChanged;

        // Disconnect
        mySymbolicDevice.DisConnect();

        Console.WriteLine("Please enter any key for exit!");
        Console.ReadKey();
    }

    private void SymbolicDevice_OnProjectImportProgressChanged(object? sender, int e)
    {
        // Print project import progress
        Console.WriteLine($"Import Project {e}% done");
    }
}
