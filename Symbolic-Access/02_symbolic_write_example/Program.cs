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
        // Enter your Username + Serial here! Please note: Without a license key (empty fields), the runtime is limited to 15 minutes
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

        List<PlcCoreVariable> writeVariables = new List<PlcCoreVariable>();

        /*
         * IMPORTANT TODO FOR YOU!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
         * Before you can write, you need the imported variable. Either you have
         * determined it by a read operation or you have PLCCom output the empty
         * variable (without values)
         */
        var variableBody = GetEmptyVariableBody(mySymbolicDevice, "DataBlock_1.ByteValue");
        // Set the value and add the variable to the write list
        if (variableBody != null)
        {
            variableBody.Value = 1;
            writeVariables.Add(variableBody);
        }

        variableBody = GetEmptyVariableBody(mySymbolicDevice, "DataBlock_1.RealValue");
        // Set the value and add the variable to the write list
        if (variableBody != null)
        {
            variableBody.Value = 123.456f;
            writeVariables.Add(variableBody);
        }

        variableBody = GetEmptyVariableBody(mySymbolicDevice, "DataBlock_1.SIntValue");
        // Set the value and add the variable to the write list
        if (variableBody != null)
        {
            variableBody.Value = -123;
            writeVariables.Add(variableBody);
        }

        variableBody = GetEmptyVariableBody(mySymbolicDevice, "DataBlock_1.UDIntValue");
        // Set the value and add the variable to the write list
        if (variableBody != null)
        {
            variableBody.Value = 123456;
            writeVariables.Add(variableBody);
        }

        // create a write request
        WriteSymbolicRequest writeRequest = new WriteSymbolicRequest(writeVariables);

        // write to device
        Console.WriteLine("write...");
        var writeResult = mySymbolicDevice.WriteData(writeRequest);

        // evaluate results
        if (writeResult.Quality == OperationResult.eQuality.GOOD)
            Console.WriteLine("write successfull!");

        else if (writeResult.Quality == OperationResult.eQuality.WARNING_PARTITIAL_BAD)
        {
            Console.WriteLine("write partialy not successfull!");
            foreach (var singleResult in writeResult.WriteOperationResults)
            {
                if (singleResult.IsQualityGood())
                    Console.WriteLine("write " + singleResult.FullVariableName + " successfull!");

                else
                    Console.WriteLine("write " + singleResult.FullVariableName + " not successfull!");
            }
        }
        else
        {
            Console.WriteLine("write not successfull! Message: " + writeResult.Message);
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

    private PlcCoreVariable GetEmptyVariableBody(Tls13Device tlsDevice, string fullVariableName)
    {
        try
        {
            return tlsDevice.GetEmptyVariableBody(fullVariableName);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine($"cannot found variable {fullVariableName}");
            return null; // return null if error occur
        }

    }
}

