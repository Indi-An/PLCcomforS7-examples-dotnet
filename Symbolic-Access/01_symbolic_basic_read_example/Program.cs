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
        // Note: You can pass user and/or password information with:
        //   new Tls13Device("192.168.1.100", "user", "password");
        SymbolicDevice device = new Tls13Device("192.168.1.100");

        // Or, if you want to use the legacy access for older TIA / firmware versions:
        // SymbolicDevice device = new LegacySymbolicDevice("192.168.1.100");

        device.OnProjectImportProgressChanged += Device_OnProjectImportProgressChanged;

        var connectResult = device.Connect();
        if (connectResult.Quality != OperationResult.eQuality.GOOD)
        {
            Console.WriteLine($"Connect failed! Quality: {connectResult.Quality} Message: {connectResult.Message}");
            return;
        }


        var request = new ReadSymbolicRequest();
        request.AddFullVariableName("DataBlock_1.ByteValue");
        request.AddFullVariableName("DataBlock_1.RealValue");
        request.AddFullVariableName("DataBlock_1.SIntValue");
        request.AddFullVariableName("DataBlock_1.UDIntValue");

        Console.WriteLine("Begin Read...");
        var readResult = device.ReadData(request);

        if (readResult.Quality == OperationResult.eQuality.GOOD ||
            readResult.Quality == OperationResult.eQuality.WARNING_PARTITIAL_BAD)
        {
            foreach (PlcCoreVariable variable in readResult.Variables)
            {
                if (variable is PlcErrorValue error)
                    Console.WriteLine($"Error: {error.VariableDetails.FullVariableName} {error}");
                else
                    Console.WriteLine($"{variable.VariableDetails.FullVariableName} Value: {variable.Value}");
            }
        }
        else
        {
            Console.WriteLine($"Read failed! Quality: {readResult.Quality} Message: {readResult.Message}");
        }

        device.OnProjectImportProgressChanged -= Device_OnProjectImportProgressChanged;
        device.DisConnect();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private void Device_OnProjectImportProgressChanged(object? sender, int e)
    {
        Console.WriteLine($"Import Project {e}% done");
    }
}
