using PLCcom;
using PLCcom.Core.S7Plus.Variables;
using PLCcom.Requests.S7Plus;

internal class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.start();
    }

    private void start()
    {
        // Important !!!!!!!!!!!!!!!!!!
        // Enter your Username + Serial here! Please note: Without a license key (empty fields), the runtime is limited to 10 minutes
        authentication.User = ""; //Please enter your user name
        authentication.Serial = ""; // Please enter your user serial key

        //create a device object for the modern tls access (TIA Version 17 or higher)
        //Note, you can pass user and/or password information with the constuctor new Tls13Device("192.168.1.100", "user", "password");
        Tls13Device mySymbolicDevice = new Tls13Device("192.168.1.100");
        //or if you want to use the legacy access for older TIA or firmware versions
        //LegacySymbolicDevice mySymbolicDevice = new LegacySymbolicDevice("192.168.1.100");

        // Register project import progress event
        mySymbolicDevice.OnProjectImportProgressChanged += SymbolicDevice_OnProjectImportProgressChanged;

        ConnectResult connectResult = mySymbolicDevice.Connect();

        if (connectResult.Quality != OperationResult.eQuality.GOOD)
        {
            Console.WriteLine($"Connect not successfull! Quality:  {connectResult.Quality} Message: {connectResult.Message}");
            return;
        }

        // Which variables do you want to read?
        ReadSymbolicRequest readRequest = new ReadSymbolicRequest();
        readRequest.AddFullVariableName("DataBlock_1.ByteValue");
        readRequest.AddFullVariableName("DataBlock_1.RealValue");
        readRequest.AddFullVariableName("DataBlock_1.SIntValue");
        readRequest.AddFullVariableName("DataBlock_1.UDIntValue");

        // Read from device
        Console.WriteLine("begin Read...");
        var readResult = mySymbolicDevice.ReadData(readRequest);

        // Evaluate results
        if (readResult.Quality == OperationResult.eQuality.GOOD || readResult.Quality == OperationResult.eQuality.WARNING_PARTITIAL_BAD)
        {
            foreach (PlcCoreVariable variable in readResult.Variables)
            {
                if (variable is PlcErrorValue error)
                {
                    Console.WriteLine($"Error can not read: {error.VariableDetails.FullVariableName} {error.ToString()}");
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
