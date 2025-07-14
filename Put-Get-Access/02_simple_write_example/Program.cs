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

            Console.WriteLine("Start Connect to TCP device...");
            Console.WriteLine(Environment.NewLine);
            //Declare Device and
            //create TCP_ISO_Device instance from PLCcomDevice
            PLCcomDevice Device = new TCP_ISO_Device("192.168.1.2", 0, 2, ePLCType.S7_300_400_compatibel);
            //or create MPI_Device instance from PLCcomDevice
            //PLCcomDevice Device = new MPI_Device("COM1", 0, 2, eBaudrate.b38400, eSpeed.Speed187k, ePLCType.S7_300_400_compatibel);
            //or create PPI_Device instance from PLCcomDevice
            //PLCcomDevice Device = new PPI_Device("COM1", 0, 2, eBaudrate.b9600, ePLCType.S7_200_compatibel);

            //set autoconnect to true and idle time till disconnect to 10000 milliseconds
            Device.setAutoConnect(true, 10000);

            //declare a WriteRequest object and
            //set the request parameters
            WriteDataRequest myWriteRequest = new WriteDataRequest(eRegion.DataBlock,   //Region
                                                                   100,                 //DB / only for datablock operations otherwise 0
                                                                   0);                  //write start adress
                                                                                        //add writable Data here
                                                                                        //in  this case => write 4 bytes in DB100
            myWriteRequest.AddByteToBuffer(new byte[] { 11, 12, 13, 14 });


            //write
            Console.WriteLine("begin write...");
            WriteDataResult res = Device.WriteData(myWriteRequest);

            //evaluate results
            if (res.Quality.Equals(OperationResult.eQuality.GOOD))
            {
                Console.WriteLine("Write successfull! Message: " + res.Message);
            }
            else
            {
                Console.WriteLine("Write not successfull! Message: " + res.Message);
            }

        }
        finally
        {
            Console.WriteLine("Please enter any key for exit!");
            Console.ReadLine();
        }

    }
}