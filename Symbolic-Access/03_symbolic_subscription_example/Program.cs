using PLCcom;
using PLCcom.Core.S7Plus.AddressSpace;
using PLCcom.Core.S7Plus.Subscription;
using PLCcom.Core.S7Plus.Variables;
using PLCcom.Requests.S7Plus;
using PLCcom.Results.S7Plus;

internal class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.start();
    }

    private void start()
    {
        try
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

            try
            {

                // Register project import progress event
                mySymbolicDevice.OnProjectImportProgressChanged += SymbolicDevice_OnProjectImportProgressChanged;

                ConnectResult connectResult = mySymbolicDevice.Connect();

                if (connectResult.Quality == OperationResult.eQuality.GOOD)
                {
                    Console.WriteLine($"Connected to PLC {mySymbolicDevice.IPAdress}");
                }
                else
                {
                    Console.WriteLine($"Connect not successfull! Quality:  {connectResult.Quality} Message: {connectResult.Message}");
                    return;
                }
            }
            finally
            {
                // Deregister project import progress event
                mySymbolicDevice.OnProjectImportProgressChanged -= SymbolicDevice_OnProjectImportProgressChanged;
            }

            //Create a new non activated subscription with a 300ms cyling period
            CreateSubscriptionRequest createSubscriptionRequest = new("TestSubscription", 300);

            // Which variables do you want to subcribe?
            createSubscriptionRequest.AddFullVariableName("DataBlock_1.ByteValue");
            createSubscriptionRequest.AddFullVariableName("DataBlock_1.RealValue");
            createSubscriptionRequest.AddFullVariableName("DataBlock_1.SIntValue");
            createSubscriptionRequest.AddFullVariableName("DataBlock_1.UDIntValue");

            CreateSubscriptionResult createSubResult = mySymbolicDevice.CreateSubscription(createSubscriptionRequest);

            if (createSubResult.Quality == OperationResult.eQuality.GOOD)
            {

                PlcSubscription subscription = createSubResult.GetSubscription();

                if (subscription != null)
                {
                    Console.WriteLine($"Subscription {subscription.SubscriptionName} created!");

                    //register variable change handler
                    subscription.VariableChange += Subscription_VariableChange;

                    RegisterSubscriptionResult registerSubscriptionResult = mySymbolicDevice.RegisterSubscription(new RegisterSubscriptionRequest(subscription));
                    if (registerSubscriptionResult.Quality == OperationResult.eQuality.GOOD)
                    {
                        Console.WriteLine($"Subscription {subscription.SubscriptionName} registered!");
                    }
                    else
                    {
                        Console.WriteLine($"Error while register subscription! Message: {createSubResult.Message}");
                    }

                    Console.WriteLine("Please enter any key for exit!");
                    Console.ReadKey();

                    #region Cleanup

                    //Deregister variable change handler
                    subscription.VariableChange -= Subscription_VariableChange;

                    //Drop subscription
                    var dropSubcriptionResult = mySymbolicDevice.DropSubscription(subscription);
                    if (dropSubcriptionResult.Quality == OperationResult.eQuality.GOOD)
                    {
                        Console.WriteLine($"Subscription {subscription.SubscriptionName} dropped!");
                    }
                    else
                    {
                        Console.WriteLine($"Error while dropping subscription! Message: {dropSubcriptionResult.Message}");
                    }

                    #endregion
                }
                else
                {
                    Console.WriteLine($"Error while creating subscription! Message: {createSubResult.Message}");
                }

            }
            else
            {
                Console.WriteLine($"Error while creating subscription! Message: {createSubResult.Message}");
            }


            // Disconnect
            mySymbolicDevice.DisConnect();
            Console.WriteLine($"DisConnected from PLC {mySymbolicDevice.IPAdress}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void Subscription_VariableChange(object sender, SubscriptionChangeVariableValueEventArgs e)
    {
        PlcSubscription? subscription = sender as PlcSubscription;
        if (subscription != null)
        {
            Console.WriteLine($"Incoming variable change notification for subscription: {subscription.SubscriptionName}");
            foreach (var variable in e.Variables)
            {
                Console.WriteLine($"Variable: {variable.VariableDetails.FullVariableName} Value: {variable.Value}");
            }
        }
    }

    private void SymbolicDevice_OnProjectImportProgressChanged(object? sender, int e)
    {
        // Print project import progress
        Console.WriteLine($"Import Project {e}% done");
    }
}

