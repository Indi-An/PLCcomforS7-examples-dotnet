using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLCcom;

namespace Simple_Dataserver_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            PLCcom.PLCComDataServer.PLCComDataServer myDataServer = null;
            PLCcomDevice Device = null;
            try
            {
                // Important !!!!!!!!!!!!!!!!!!
                // Enter your Username + Serial here! Please note: Without a license key (empty fields), the runtime is limited to 15 minutes
                authentication.User = ""; //Please enter your user name
                authentication.Serial = ""; // Please enter your user serial key

                Console.WriteLine("Start Connect to TCPIP device...");
                //Create an PLCcom-Device instance
                Device = new TCP_ISO_Device("192.168.1.2", 0, 2, ePLCType.S7_300_400_compatibel);

                //set autoconnect to true and idle time till disconnect to 10000 milliseconds
                Device.setAutoConnect(true, 10000);

                //Create an instance depending on the device type
                Console.WriteLine("Create DataServer PLCDataServerTCP1...");
                myDataServer = new PLCcom.PLCComDataServer.PLCComDataServer_TCP("PLCDataServerTCP1", (TCP_ISO_Device)Device, 500);

                //register incoming events
                //register events                
                myDataServer.OnConnectionStateChange += new PLCcom.PLCComDataServer.PLCComDataServer.ConnectionStateChangeEventHandler(myDataServer_OnConnectionStateChange);
                myDataServer.OnReadDataResultChange += new PLCcom.PLCComDataServer.PLCComDataServer.ReadDataResultChangeEventHandler(myDataServer_OnReadDataResultChange);
                myDataServer.OnIncomingLogEntry += new PLCcom.PLCComDataServer.PLCComDataServer.OnIncomingLogEntryDelegate(myDataServer_OnIncomingLogEntry);


                //define new request
                Console.WriteLine("Create new Request Read 4 Bytes from DB1 at address 0 ...");
                ReadDataRequest RequestItem1 = new ReadDataRequest(eRegion.DataBlock,            //Region
                                                                    1,                          //datablock
                                                                    0,                          //startAdress
                                                                    eDataType.BYTE,             //target data type
                                                                    4);                         //Quantity

                //add new request to plccom data server
                myDataServer.AddReadDataRequest(RequestItem1);

                //define new request
                Console.WriteLine("Create new Request Read 10 DWords from Flags_Markers at address 4 ...");
                ReadDataRequest RequestItem2 = new ReadDataRequest(eRegion.Flags_Markers,       //Region
                                                                    0,                          //datablock
                                                                    4,                          //startAdress
                                                                    eDataType.DWORD,            //target data type
                                                                    10);                        //Quantity

                //add new request to plccom data server
                myDataServer.AddReadDataRequest(RequestItem2);


                //add on or more Loggingkonnektoren with logging and writing of a data image into filesystem or database
                //in this case create a new FileSystemConnector instance
                PLCcom.ExternalLogging.LoggingConnector con = new PLCcom.ExternalLogging.FileSystemConnector(System.Threading.Thread.GetDomain().BaseDirectory, //Target folder
                                                                                                            "FileSystemConnector1",                             //unique connector name
                                                                                                            ';',                                                //text separator recommendation ';'
                                                                                                            true,                                               //activate progressive logging
                                                                                                            true,                                               //activate immage writing
                                                                                                            PLCcom.ExternalLogging.eImageOutputFormat.dat,      //output format .dat or .xml
                                                                                                            10,                                                 //restrict the maximum number of files. When the value is exceeded the old files are automatically deleted. -1 = Disabled.
                                                                                                            24,                                                 //restrict the maximum age of files. When the value is exceeded the old files are automatically deleted. -1 = Disabled.
                                                                                                            30,                                                 //You can restrict the maximum size of files. When the value is exceeded the old files are automatically deleted. -1 = Disabled.
                                                                                                            string.Empty);                                      //If you enter an encryption password, the data is stored in encrypted form. You can read the data using the supplied decryption tool again.
                //add Connector to Dataserver
                myDataServer.AddOrReplaceLoggingConnector(con);

                //start PLCcom data server
                myDataServer.StartServer();
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //stop PLCcom data server
                myDataServer.StopServer();
            }
        }

        static void myDataServer_OnConnectionStateChange(object sender, eConnectionState e)
        {
            Console.WriteLine("Connectionstate changed to: " + e.ToString());
        }

        static void myDataServer_OnReadDataResultChange(object sender, ReadDataResult Result)
        {
            Console.WriteLine(DateTime.Now.ToString() + " ItemKey: " + Result.Itemkey + " Quality: " + Result.Quality.ToString() + " Values: " + ArrayToString(Result.GetValues()));
        }

        private static string ArrayToString(Array value)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                sb.Append(value.GetValue(i).ToString());
                if (i < value.Length - 1)
                {
                    sb.Append(",");
                }
            }
            return sb.ToString();
        }

        static void myDataServer_OnIncomingLogEntry(LogEntry[] e)
        {
            //incoming OnIncomingLogEntry event
            //loading Logentrys in ListView
            //write LogEntry into listview
            foreach (LogEntry le in e)
            {
                if (le.getLogLevel().Equals(eLogLevel.Error)) Console.WriteLine(le.ToString());
            }
        }
    }
}
