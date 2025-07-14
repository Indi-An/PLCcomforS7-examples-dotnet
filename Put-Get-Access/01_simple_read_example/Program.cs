using System;
using PLCcom;


class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Important !!!!!!!!!!!!!!!!!!
            // Enter your Username + Serial here! Please note: Without a license key (empty fields), the runtime is limited to 15 minutes
            authentication.User = ""; //Please enter your user name
            authentication.Serial = ""; // Please enter your user serial key

            Console.WriteLine("Start Connect to TCPIP device...");
            Console.WriteLine(Environment.NewLine);
            //Declare Device and
            //create TCP_ISO_Device instance from PLCcomDevice
            PLCcomDevice Device = new TCP_ISO_Device("192.168.1.100", 0, 2, ePLCType.S7_300_400_compatibel);
            //or create MPI_Device instance from PLCcomDevice
            //PLCcomDevice Device = new MPI_Device("COM1", 0, 2, eBaudrate.b38400, eSpeed.Speed187k, ePLCType.S7_300_400_compatibel);
            //or create PPI_Device instance from PLCcomDevice
            //PLCcomDevice Device = new PPI_Device("COM1", 0, 2, eBaudrate.b9600, ePLCType.S7_200_compatibel);

            //set autoconnect to true and idle time till disconnect to 10000 milliseconds
            Device.setAutoConnect(true, 10000);

            //set the request parameters
            //in this case => read 10 Bytes from DB1
            ReadDataRequest myReadDataRequest = new ReadDataRequest(eRegion.DataBlock,  //Region
                                                                   1,                   //DB / only for datablock operations otherwise 0
                                                                   0,                   //read start adress
                                                                   eDataType.BYTE,      //desired datatype
                                                                   10);                //Quantity of reading values

            //read from device
            Console.WriteLine("begin Read...");
            ReadDataResult res = Device.ReadData(myReadDataRequest);

            //evaluate results
            if (res.Quality == OperationResult.eQuality.GOOD)
            {
                int Position = 0;
                foreach (Object item in res.GetValues())
                {
                    Console.WriteLine("read Byte " + Position++.ToString() + " " + item.ToString());
                }
            }
            else
            {
                Console.WriteLine("read not successfull! Message: " + res.Message);
            }
        }
        finally
        {
            Console.WriteLine("Please enter any key for exit!");
            Console.ReadLine();
        }

    }
}