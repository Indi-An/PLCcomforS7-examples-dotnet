using System;
using PLCcom;

namespace Optimized_reading_and_writing_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region init device

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

                #endregion

                #region create a requestset

                ReadWriteRequestSet myRequestSet = new ReadWriteRequestSet();
                //set operation order to RequestSet
                myRequestSet.SetOperationOrder(eOperationOrder.WRITE_BEVOR_READ);

                //choose your optimation mode for read and write operations
                //Explanation of the optimation mode

                //NONE:
                //No optimization, all read requests are read one after the other. Safe but slow.

                //CROSS_AREAS: 
                //In CROSS_AREAS mode, the requests are merged across areas. Advantage: fragmented areas(e.g., data across multiple datablocks) can be read and written simultaneously

                //COMBINE_AREAS:
                //In COMBINE_AREAS mode, read requests from the same areas are combined. Advantage: Fast and high - performance access to data of the same areas(for example, data in the same datablock)

                //AUTO:
                //PLCcom automatically selects the best optimization method. Only the minimum required PLC read accesses are carried out.
                //Only in Expert edition available

                //Set read optimation mode, recommended eReadOptimizationMode.AUTO
                myRequestSet.SetReadOptimizationMode(eReadOptimizationMode.AUTO);
                //Set write optimation mode, recommended eWriteOptimizationMode.CROSS_AREAS
                myRequestSet.SetWriteOptimizationMode(eWriteOptimizationMode.CROSS_AREAS);

                #endregion

                #region create requests

                //declare a ReadRequest object set the request parameters
                //in this case => read 10 Bytes from DB1 at Byte 0
                ReadDataRequest myReadDataRequest = new ReadDataRequest(eRegion.DataBlock,  //Region
                                                                       1,                   //DB / only for datablock operations otherwise 0
                                                                       0,                   //read start adress
                                                                       eDataType.BYTE,      //desired datatype
                                                                       10);                //Quantity of reading values

                //add the read request to the requestset
                myRequestSet.AddRequest(myReadDataRequest);

                //set new request parameters
                //in this case => read 78 Bytes from DB1 at address 45
                myReadDataRequest = new ReadDataRequest(eRegion.DataBlock,  //Region
                                                        1,                   //DB / only for datablock operations otherwise 0
                                                        45,                   //read start adress
                                                        eDataType.BYTE,      //desired datatype
                                                        78);                //Quantity of reading values

                //add the read request to the requestset
                myRequestSet.AddRequest(myReadDataRequest);


                //set new request parameters
                //in this case => read 20 DWord from marker at address 0
                myReadDataRequest = new ReadDataRequest(eRegion.Flags_Markers,  //Region
                                                        1,                   //DB / only for datablock operations otherwise 0
                                                        0,                   //read start adress
                                                        eDataType.DWORD,     //desired datatype
                                                        20);                 //Quantity of reading values

                //add the read request to the requestset
                myRequestSet.AddRequest(myReadDataRequest);

                //....... add or more requests to request set


                //declare a WriteRequest object and set the request parameters
                WriteDataRequest myWriteRequest = new WriteDataRequest(eRegion.DataBlock,   //Region
                                                                       100,                 //DB / only for datablock operations otherwise 0
                                                                       0);                  //write start adress
                //add writable Data here
                //in  this case => write 4 bytes to DB100 at address 0
                myWriteRequest.AddByteToBuffer(new byte[] { 11, 12, 13, 14 });
                //add the read request to the requestset
                myRequestSet.AddRequest(myWriteRequest);

                //declare a WriteRequest object and
                //set the request parameters
                myWriteRequest = new WriteDataRequest(eRegion.Flags_Markers,    //Region
                                                        0,                      //DB / only for datablock operations otherwise 0
                                                        95);                    //write start adress
                //add writable Data here
                //in  this case => write 2 Word to Marker at address 95
                myWriteRequest.AddWordToBuffer(new ushort[] { 1111, 2222 });
                //add the read request to the requestset
                myRequestSet.AddRequest(myWriteRequest);

                //declare a WriteRequest object and
                //set the request parameters
                myWriteRequest = new WriteDataRequest(eRegion.Flags_Markers,    //Region
                                                        0,                      //DB / only for datablock operations otherwise 0
                                                        105,                    //write start adress
                                                        0);                     //start bit 
                //add writable Data here
                //in  this case => set bit at address M105.0 
                myWriteRequest.AddBitToBuffer(true);
                //add the read request to the requestset
                myRequestSet.AddRequest(myWriteRequest);

                #endregion

                #region execute

                //start optimized reading and writing
                Console.WriteLine("begin optimized reading and writing...");
                ReadWriteResultSet results = Device.ReadWriteData(myRequestSet);

                #endregion

                #region evaluate results
                //evaluate the results of read operations...
                foreach (ReadDataResult res in results.GetReadDataResults())
                {
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

                //...and evaluate the results of write operations
                foreach (WriteDataResult res in results.GetWriteDataResults())
                {
                    if (res.Quality.Equals(OperationResult.eQuality.GOOD))
                    {
                        Console.WriteLine("Write successfull! Message: " + res.Message);
                    }
                    else
                    {
                        Console.WriteLine("Write not successfull! Message: " + res.Message);
                    }
                }

                #endregion

            }
            finally
            {
                Console.WriteLine("Please enter any key for exit!");
                Console.ReadLine();
            }

        }
    }
}
