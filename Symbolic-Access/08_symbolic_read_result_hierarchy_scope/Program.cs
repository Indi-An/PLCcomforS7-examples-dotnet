using System;
using PLCcom;
using PLCcom.Core.S7Plus.Variables;
using PLCcom.Enums.S7Plus;
using PLCcom.Requests.S7Plus;

internal class Program
{
    static void Main(string[] args)
    {
        new Program().Start(args);
    }

    private void Start(string[] args)
    {
        // Important !!!!!!!!!!!!!!!!!! (License)
        // Enter your Username + Serial here!
        // Please note: Without a license key (empty fields), the runtime is limited to 10 minutes.
        authentication.User = "";   // Please enter your user name
        authentication.Serial = ""; // Please enter your user serial key

        // Create a device object for the modern TLS access (TIA Version 17 or higher).
        SymbolicDevice device = new Tls13Device("192.168.1.100");
        // SymbolicDevice device = new LegacySymbolicDevice("192.168.1.100");

        device.OnProjectImportProgressChanged += Device_OnProjectImportProgressChanged;

        var connectResult = device.Connect();
        if (connectResult.Quality != OperationResult.eQuality.GOOD)
        {
            Console.WriteLine($"Connect failed! Quality: {connectResult.Quality} Message: {connectResult.Message}");
            return;
        }

        // =========================================================================
        // Result Hierarchy Scope (AUTO)
        // =========================================================================
        //
        // Goal:
        // - We request only the container/root: "DataBlock_1"
        // - Then we try to access child members by full variable name via TryGetVariableByFullVariableName,
        //   e.g. "DataBlock_1.ByteValue".
        //
        // IMPORTANT LICENSE BEHAVIOR:
        //
        // 1) Auto (recommended default):
        //    - With an Expert license:
        //        Auto is resolved to RequestedAndChildMembers -> child lookup works.
        //    - With a Standard license:
        //        Auto is resolved to RequestedOnly -> child lookup is NOT available.
        //        In this case TryGetVariableByFullVariableName(...) returns false (and Get... returns null).
        //
        // 2) Explicit RequestedAndChildMembers:
        //    - If you explicitly request RequestedAndChildMembers without an appropriate license,
        //      ReadData(...) throws an exception (license restriction).
        //
        // IMPORTANT TECHNICAL NOTE:
        // - The scope does NOT change what is read from the PLC.
        // - It only changes what the result may expose via Get/TryGet and internal indexing.
        // =========================================================================


        var request = new ReadSymbolicRequest(eResultHierarchyScope.Auto);
        request.AddFullVariableName("DataBlock_1"); // request only the container/root

        Console.WriteLine("Begin Read...");
        var result = device.ReadData(request);

        if (result.Quality == OperationResult.eQuality.GOOD ||
            result.Quality == OperationResult.eQuality.WARNING_PARTITIAL_BAD)
        {
            foreach (PlcCoreVariable variable in result.Variables)
            {
                if (variable is PlcErrorValue error)
                    Console.WriteLine($"Error: {error.VariableDetails.FullVariableName} {error}");
                else
                    Console.WriteLine($"Root returned: {variable.VariableDetails.FullVariableName}");
            }

            Console.WriteLine("TryGet child members:");

            if (result.TryGetVariableByFullVariableName("DataBlock_1.ByteValue", out var b) && b != null)
                Console.WriteLine($"DataBlock_1.ByteValue Value: {b.Value}");
            else
                Console.WriteLine("Child lookup failed: DataBlock_1.ByteValue");

            if (result.TryGetVariableByFullVariableName("DataBlock_1.RealValue", out var r) && r != null)
                Console.WriteLine($"DataBlock_1.RealValue Value: {r.Value}");
            else
                Console.WriteLine("Child lookup failed: DataBlock_1.RealValue");

            if (result.TryGetVariableByFullVariableName("DataBlock_1.SIntValue", out var s) && s != null)
                Console.WriteLine($"DataBlock_1.SIntValue Value: {s.Value}");
            else
                Console.WriteLine("Child lookup failed: DataBlock_1.SIntValue");

            if (result.TryGetVariableByFullVariableName("DataBlock_1.UDIntValue", out var u) && u != null)
                Console.WriteLine($"DataBlock_1.UDIntValue Value: {u.Value}");
            else
                Console.WriteLine("Child lookup failed: DataBlock_1.UDIntValue");
        }
        else
        {
            Console.WriteLine($"Read failed! Quality: {result.Quality} Message: {result.Message}");
        }

        device.OnProjectImportProgressChanged -= Device_OnProjectImportProgressChanged;
        device.DisConnect();

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private void Device_OnProjectImportProgressChanged(object? sender, int e)
    {
        Console.WriteLine($"Import Project {e}% done");
    }
}
