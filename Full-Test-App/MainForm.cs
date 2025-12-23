using System;
using System.Drawing;
using System.Windows.Forms;
using PLCcom;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using PLCCom_Full_Test_App.Classic;
using PLCCom_Full_Test_App.Symbolic;
using System.Linq;
using PLCcom.Core;
using PLCcom.Enums.S7Plus;
using System.Threading.Tasks;
using System.Text;
using System.Globalization;

namespace PLCCom_Full_Test_App
{
    public partial class MainForm : Form
    {

        #region Private member
        PLCcomCoreDevice mDevice = new TCP_ISO_Device();
        System.Resources.ResourceManager resources;
        private delegate void dlgtOnConnectionStateChange(object sender, eConnectionState e);

        #endregion

        #region Internal member
        internal static int CountOpenDialogs = 0;
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void Device_OnConnectionStateChange(object sender, eConnectionState e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new dlgtOnConnectionStateChange(Device_OnConnectionStateChange), new object[] { sender, e });
            }
            else
            {
                if (!mDevice.getAutoConnectState())
                {

                    grbAccess.Enabled = mDevice.IsConnected;
                    grbParams.Enabled = !mDevice.IsConnected;
                    btnReadWriteSymbolic.Visible = mDevice.PLCType == ePLCType.Symbolic_Tls13 || mDevice.PLCType == ePLCType.Symbolic_Legacy;
                    btnAlarmMessages.Enabled = mDevice.PLCType == ePLCType.Symbolic_Tls13 || mDevice.PLCType == ePLCType.Symbolic_Legacy;
                    btnReadWriteFunctions.Visible = mDevice.PLCType != ePLCType.Symbolic_Tls13 && mDevice.PLCType != ePLCType.Symbolic_Legacy;
                    btnOptimizedReadWrite.Enabled = mDevice.PLCType != ePLCType.Symbolic_Tls13 && mDevice.PLCType != ePLCType.Symbolic_Legacy;
                    btnDataServer.Enabled = mDevice.PLCType != ePLCType.Symbolic_Tls13 && mDevice.PLCType != ePLCType.Symbolic_Legacy;
                    btnBlockFunctions.Enabled = mDevice.PLCType != ePLCType.Symbolic_Tls13 && mDevice.PLCType != ePLCType.Symbolic_Legacy;

                }

                txtDeviceState.Text = resources.GetString("State_" + e.ToString()) + (mDevice != null ? " " + mDevice.DeviceInfo.Name : string.Empty);
                txtDeviceState.BackColor = mDevice.IsConnected ? Color.Green : Color.White;
                txtDeviceState.ForeColor = mDevice.IsConnected ? Color.White : Color.Black;
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            //set language combobox
            List<CultureInfo> lisCultureInfo = new List<System.Globalization.CultureInfo>();
            if (Thread.CurrentThread.CurrentCulture.Parent.TwoLetterISOLanguageName == "de")
            {
                lisCultureInfo.Add(CultureInfo.CreateSpecificCulture("de").Parent);
                lisCultureInfo.Add(CultureInfo.CreateSpecificCulture("en").Parent);
            }
            else
            {
                lisCultureInfo.Add(CultureInfo.CreateSpecificCulture("en").Parent);
                lisCultureInfo.Add(CultureInfo.CreateSpecificCulture("de").Parent);
            }
            cmbLanguage.DataSource = lisCultureInfo;

            //set UI language
            SetLanguage(System.Threading.Thread.CurrentThread.CurrentCulture);

            cmbPLCType.DataSource = Enum.GetValues(typeof(ePLCType));
            cmbConnectionType.DataSource = Enum.GetValues(typeof(eTypeOfCommunication));
            cmbBusspeed.DataSource = Enum.GetValues(typeof(eSpeed));
            cmbBaudrate.DataSource = Enum.GetValues(typeof(eBaudrate));

            LoadSettingsFromFile();

            btnEditConnectionSettings.Select();
        }


        private void SetLanguage(System.Globalization.CultureInfo culture)
        {
            //set UI-Controls with actual CultureInfo information

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture.TwoLetterISOLanguageName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture.TwoLetterISOLanguageName);

            //init ResourceManager
            if (resources == null)
            {
                resources = new System.Resources.ResourceManager(this.GetType().Namespace + ".Properties.Resources", this.GetType().Assembly);
            }

            //set controls 
            this.txtWarning.Text = resources.GetString("txtWarning_Text");
            this.Text = resources.GetString("main_Text");
            this.lblAutoConnect2.Text = resources.GetString("lblAutoConnect2");
            this.lblmaxIdleTime.Text = resources.GetString("lblmaxIdleTime_Text");
            this.btnConnect.Text = resources.GetString("btnConnect_Text");
            this.btnDisconnect.Text = resources.GetString("btnDisconnect_Text");
            this.lblPLCType.Text = resources.GetString("lblPLCType_Text");
            this.grbAddress.Text = resources.GetString("grpAdress_Text");
            this.grbAccess.Text = resources.GetString("grpAccess_Text");
            this.btnReadWriteFunctions.Text = resources.GetString("btnReadWriteFunctions_Text");
            this.btnOptimizedReadWrite.Text = resources.GetString("btnOptimizedReadWrite_Text");
            this.grbConnectionSettings.Text = resources.GetString("grbConnection_Text");
            this.btnDataServer.Text = resources.GetString("btnDataServer_Text");
            this.btnOtherFunctions.Text = resources.GetString("btnOtherFunctions_Text");
            this.btnBlockFunctions.Text = resources.GetString("btnBlockFunctions_Text");
            this.lblSerialCode.Text = resources.GetString("lblSerialCode_Text");
            this.lblLanguage.Text = resources.GetString("lblLanguage_Text");
            this.btnAlarmMessages.Text = resources.GetString("btnAlarm_Text");

            this.lblBaudrate.Text = resources.GetString("lblBaudrate_Text");
            this.lblBusSpeed.Text = resources.GetString("lblBusSpeed_Text");
            this.lblAdress1.Text = resources.GetString("lblPLCPort_Text");
            this.lblAdress2.Text = resources.GetString("lblLocalPort_Text");
            this.lblAdress3.Text = resources.GetString("lblRack_Text");
            this.lblAdress4.Text = resources.GetString("lblSlot_Text");
            this.btnClose.Text = resources.GetString("btnClose_Text");
            this.btnEditConnectionSettings.Text = resources.GetString("btnEditConnectionSettings_Text");
            this.btnSaveConnectionSettings.Text = resources.GetString("btnSaveConnectionSettings_Text");
            this.lblConnectionType.Text = resources.GetString("lblConnectionType_Text");
            this.lblAsyncConnect.Text = resources.GetString("chkAsyncConnect_TextAsync");
            this.lblProtectionPassword.Text = resources.GetString("lblPlcPassword_Text");

        }

        [DebuggerStepThrough()]
        private void LoadSettingsFromFile()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

            // Check if the directory exists, if not, create it
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (File.Exists(Path.Combine(path, "PlccomExSettings.xml")))
            {
                try
                {
                    using (XmlTextReader reader = new XmlTextReader(Path.Combine(path, "PlccomExSettings.xml")))
                    {
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element: // The node is an element.
                                    switch (reader.Name)
                                    {
                                        case "Authentication":
                                            txtUser.Text = reader.GetAttribute("user");
                                            txtSerial.Text = reader.GetAttribute("serial");
                                            break;
                                        case "Communication":
                                            if (cmbConnectionType.FindString(reader.GetAttribute("eTypeOfCommunication")) > -1) cmbConnectionType.Text = reader.GetAttribute("eTypeOfCommunication");
                                            if (cmbPLCType.FindString(reader.GetAttribute("ePLCtype")) > -1) cmbPLCType.Text = reader.GetAttribute("ePLCtype");
                                            if (cmbBaudrate.FindString(reader.GetAttribute("eBaudrate")) > -1) cmbBaudrate.Text = reader.GetAttribute("eBaudrate");
                                            if (cmbBusspeed.FindString(reader.GetAttribute("eSpeed")) > -1) cmbBusspeed.Text = reader.GetAttribute("eSpeed");

                                            txtAdress0.Text = reader.GetAttribute("Adress0");
                                            txtAdress1.Text = reader.GetAttribute("Adress1");
                                            txtAdress2.Text = reader.GetAttribute("Adress2");
                                            txtAdress3.Text = reader.GetAttribute("Adress3");
                                            txtAdress4.Text = reader.GetAttribute("Adress4");

                                            txtProtectionUser.Text = reader.GetAttribute("ProtectionUser") == null ? string.Empty : reader.GetAttribute("ProtectionUser");

                                            string encryptedPassword = reader.GetAttribute("Password") == null ? string.Empty : reader.GetAttribute("Password");
                                            if (!string.IsNullOrEmpty(encryptedPassword))
                                                txtProtectionPassword.Text = AesEncryption.DecryptString(encryptedPassword);
                                            else
                                                txtProtectionPassword.Text = string.Empty;

                                            txtIdleTimeSpan.Text = reader.GetAttribute("txtIdeleTimeSpan");
                                            chkAsyncConnect.Checked = Boolean.Parse(reader.GetAttribute("chkAsyncConnect"));
                                            chkAutoConnect.Checked = Boolean.Parse(reader.GetAttribute("AutoConnect"));
                                            break;
                                    }

                                    break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    grbConnection.Enabled = !chkAutoConnect.Checked;
                    grbAccess.Enabled = chkAutoConnect.Checked;
                }
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            SetupDevice();


            //Special settings for Tls13Device project import settings
            if (mDevice is SymbolicDevice)
            {

                // set progressbar for showing progress of project import 
                progbarStatusText.Text = resources.GetString("project_import_starts");
                progbarStatusText.Visible = true;
                ProgressBarProjectImport.Value = 0;
                ProgressBarProjectImport.Visible = true;

                //Register event for showing project import progress
                ((SymbolicDevice)mDevice).OnProjectImportProgressChanged += Main_OnProjectImportProgressChanged;
            }

            //Example asynchronous/ synchronous Connect
            if (chkAsyncConnect.Checked)
            {
                // asynchronous call (Standard)
                mDevice.ConnectCallback += new PLCcomDevice.BeginConnectCallback(Device_ConnectCallback);
                mDevice.BeginConnect();
            }
            else
            {
                //synchronous call
                txtDeviceState.Text = resources.GetString("State_connecting" + mDevice.DeviceInfo.Name);
                ConnectResult res = mDevice.Connect();
                if (!res.Quality.Equals(OperationResult.eQuality.GOOD))
                {
                    string message = resources.GetString("connect_unsuccessful") + Environment.NewLine + resources.GetString("MessageText") + res.Message;

                    if (res.InnerException != null)
                    {
                        message += Environment.NewLine + "InnerException: " + res.InnerException.Message;
                    }

                    MessageBox.Show(this, message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ((SymbolicDevice)mDevice).OnProjectImportProgressChanged -= Main_OnProjectImportProgressChanged;
                progbarStatusText.Visible = false;
                ProgressBarProjectImport.Visible = false;
            }

        }

        private void Main_OnProjectImportProgressChanged(object sender, int e)
        {

            //Callback for the project import progress

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    progbarStatusText.Text = $"Project Import {e}%";
                    ProgressBarProjectImport.Value = e;
                }));
            }
            else
            {
                progbarStatusText.Text = $"Project Import {e}%";
                ProgressBarProjectImport.Value = e;
            }
        }

        private void Device_ConnectCallback(object sender, ConnectResult res)
        {
            if (!res.Quality.Equals(OperationResult.eQuality.GOOD))
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        string message = resources.GetString("connect_unsuccessful") + Environment.NewLine + resources.GetString("MessageText") + res.Message;

                        if (res.InnerException != null)
                            message += Environment.NewLine + "InnerException: " + res.InnerException.Message;

                        MessageBox.Show(this, message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }));

                }
                else
                {
                    string message = resources.GetString("connect_unsuccessful") + Environment.NewLine + resources.GetString("MessageText") + res.Message;

                    if (res.InnerException != null)
                        message += Environment.NewLine + "InnerException: " + res.InnerException.Message;

                    MessageBox.Show(this, message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            mDevice.ConnectCallback -= new PLCcomDevice.BeginConnectCallback(Device_ConnectCallback);

            //DeRegister event for showing prject import progress
            if (mDevice is SymbolicDevice)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {

                        if (mDevice is SymbolicDevice)
                        {
                            ((SymbolicDevice)mDevice).OnProjectImportProgressChanged -= Main_OnProjectImportProgressChanged;
                            progbarStatusText.Visible = false;
                            ProgressBarProjectImport.Visible = false;
                        }
                    }));

                }
                else
                {
                    ((SymbolicDevice)mDevice).OnProjectImportProgressChanged -= Main_OnProjectImportProgressChanged;
                    progbarStatusText.Visible = false;
                    ProgressBarProjectImport.Visible = false;
                }
            }
        }


        private void cmbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.cmbConnectionType.SelectedValue.ToString())
                {
                    case "TCP":
                        this.lblAdress0.Text = "IP";
                        this.txtAdress0.Text = string.Empty;
                        if ((ePLCType)cmbPLCType.SelectedValue == ePLCType.Logo0BA7_compatibel)
                        {
                            this.lblAdress3.Text = resources.GetString("Serviceport_Text");
                            this.lblAdress4.Text = resources.GetString("Local_Serviceport_Text");
                            this.txtAdress3.Text = 10001.ToString();
                            this.txtAdress4.Text = 0.ToString();
                        }
                        else if ((ePLCType)cmbPLCType.SelectedValue == ePLCType.Logo0BA8_compatibel ||
                                (ePLCType)cmbPLCType.SelectedValue == ePLCType.Logo0BA0_compatibel ||
                                (ePLCType)cmbPLCType.SelectedValue == ePLCType.Logo0BA1_compatibel ||
                                (ePLCType)cmbPLCType.SelectedValue == ePLCType.Logo0BA2_compatibel)
                        {
                            this.lblAdress3.Text = resources.GetString("Serviceport_Text");
                            this.lblAdress4.Text = resources.GetString("Local_Serviceport_Text");
                            this.txtAdress3.Text = 10005.ToString();
                            this.txtAdress4.Text = 0.ToString();
                        }
                        else if ((ePLCType)cmbPLCType.SelectedValue == ePLCType.Symbolic_Tls13)
                        {
                            this.lblAdress3.Text = resources.GetString("lblRack_Text");
                            this.lblAdress4.Text = resources.GetString("lblSlot_Text");
                            this.txtAdress3.Text = string.Empty;
                            this.txtAdress4.Text = string.Empty;
                        }
                        else if ((ePLCType)cmbPLCType.SelectedValue == ePLCType.Symbolic_Legacy)
                        {
                            this.lblAdress3.Text = resources.GetString("lblRack_Text");
                            this.lblAdress4.Text = resources.GetString("lblSlot_Text");
                            this.txtAdress3.Text = string.Empty;
                            this.txtAdress4.Text = string.Empty;
                        }
                        else
                        {
                            this.lblAdress3.Text = resources.GetString("lblRack_Text");
                            this.lblAdress4.Text = resources.GetString("lblSlot_Text");
                            this.txtAdress3.Text = 0.ToString();
                            this.txtAdress4.Text = 2.ToString();
                        }
                        break;
                    case "MPI":
                    case "PPI":
                        this.lblAdress0.Text = "ComPort";
                        this.lblAdress3.Text = resources.GetString("lblBusAdressLocal_Text");
                        this.lblAdress4.Text = resources.GetString("lblBusAdressPLC_Text");
                        string[] ports = System.IO.Ports.SerialPort.GetPortNames();
                        if (ports.Length > 0)
                        {
                            this.txtAdress0.Text = ports[0];
                        }
                        else
                        {
                            this.txtAdress0.Text = "No serial ports detected";
                        }
                        this.txtAdress3.Text = 0.ToString();
                        this.txtAdress4.Text = 2.ToString();
                        break;
                    default:

                        break;
                }

                switch (this.cmbConnectionType.SelectedValue.ToString())
                {
                    case "TCP":
                        this.cmbBaudrate.Enabled = false;
                        this.cmbBusspeed.Enabled = false;
                        this.cmbBaudrate.Visible = false;
                        this.cmbBusspeed.Visible = false;
                        this.lblBaudrate.Visible = false;
                        this.lblBusSpeed.Visible = false;
                        this.txtAdress2.Text = "0";
                        this.txtAdress1.Text = "102";
                        if ((ePLCType)cmbPLCType.SelectedValue == ePLCType.Symbolic_Tls13)
                        {
                            this.txtAdress2.Enabled = false;
                            this.txtAdress1.Enabled = false;
                        }
                        else if ((ePLCType)cmbPLCType.SelectedValue == ePLCType.Symbolic_Legacy)
                        {
                            this.txtAdress2.Enabled = false;
                            this.txtAdress1.Enabled = false;
                        }
                        else
                        {
                            this.txtAdress2.Enabled = true;
                            this.txtAdress1.Enabled = true;
                        }
                        break;
                    case "MPI":
                        this.cmbBusspeed.Text = eSpeed.Speed187k.ToString();
                        this.cmbBaudrate.Text = eBaudrate.b38400.ToString();
                        this.cmbBaudrate.Enabled = true;
                        this.cmbBusspeed.Enabled = true;
                        this.cmbBaudrate.Visible = true;
                        this.cmbBusspeed.Visible = true;
                        this.lblBaudrate.Visible = true;
                        this.lblBusSpeed.Visible = true;
                        this.txtAdress2.Enabled = false;
                        this.txtAdress1.Enabled = false;
                        break;
                    case "PPI":
                        this.cmbBaudrate.Text = eBaudrate.b9600.ToString();
                        this.cmbBaudrate.Enabled = true;
                        this.cmbBusspeed.Enabled = false;
                        this.cmbBaudrate.Visible = true;
                        this.cmbBusspeed.Visible = true;
                        this.lblBaudrate.Visible = true;
                        this.lblBusSpeed.Visible = true;
                        this.txtAdress2.Enabled = false;
                        this.txtAdress1.Enabled = false;
                        break;
                    default:
                        MessageBox.Show(resources.GetString("undefinend_Connectiontype"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, resources.GetString("undefinend_Connectiontype"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void cmbPLCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPLCType.SelectedValue.ToString().ToUpper().Equals("LOGO_COMPATIBEL"))
                {
                    MessageBox.Show(resources.GetString("logo_compatibel_is_obsolete"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                switch ((ePLCType)cmbPLCType.SelectedValue)
                {
                    case ePLCType.S7_200_compatibel:
                        if (cmbConnectionType.SelectedValue == null || (eTypeOfCommunication)cmbConnectionType.SelectedValue == eTypeOfCommunication.TCP)
                        {
                            this.lblAdress3.Text = resources.GetString("lblRack_Text");
                            this.lblAdress4.Text = resources.GetString("lblSlot_Text");
                            this.txtAdress3.Text = "0";
                            this.txtAdress4.Text = "0";
                        }
                        else
                        {
                            this.lblAdress3.Text = resources.GetString("lblBusAdressLocal_Text");
                            this.lblAdress4.Text = resources.GetString("lblBusAdressPLC_Text");
                            this.txtAdress3.Text = "0";
                            this.txtAdress4.Text = "2";
                        }

                        this.lblAdress1.Visible = true;
                        this.lblAdress2.Visible = true;
                        this.lblAdress3.Visible = true;
                        this.lblAdress4.Visible = true;
                        this.txtAdress1.Visible = true;
                        this.txtAdress2.Visible = true;
                        this.txtAdress3.Visible = true;
                        this.txtAdress4.Visible = true;

                        this.lblProtectionUser.Visible = false;
                        this.lblProtectionPassword.Visible = false;
                        this.txtProtectionUser.Visible = false;
                        this.txtProtectionPassword.Visible = false;

                        this.txtIdleTimeSpan.Enabled = true;
                        this.chkAutoConnect.Enabled = true;
                        break;
                    case ePLCType.S7_300_400_compatibel:
                    case ePLCType.WinAC_RTX_2010_compatibel:
                        if (cmbConnectionType.SelectedValue == null || (eTypeOfCommunication)cmbConnectionType.SelectedValue == eTypeOfCommunication.TCP)
                        {
                            this.lblAdress3.Text = resources.GetString("lblRack_Text");
                            this.lblAdress4.Text = resources.GetString("lblSlot_Text");
                        }
                        else
                        {
                            this.lblAdress3.Text = resources.GetString("lblBusAdressLocal_Text");
                            this.lblAdress4.Text = resources.GetString("lblBusAdressPLC_Text");
                        }
                        this.txtAdress3.Text = "0";
                        this.txtAdress4.Text = "2";

                        this.lblAdress1.Visible = true;
                        this.lblAdress2.Visible = true;
                        this.lblAdress3.Visible = true;
                        this.lblAdress4.Visible = true;
                        this.txtAdress1.Visible = true;
                        this.txtAdress2.Visible = true;
                        this.txtAdress3.Visible = true;
                        this.txtAdress4.Visible = true;

                        this.lblProtectionUser.Visible = false;
                        this.lblProtectionPassword.Visible = false;
                        this.txtProtectionUser.Visible = false;
                        this.txtProtectionPassword.Visible = false;

                        this.txtIdleTimeSpan.Enabled = true;
                        this.chkAutoConnect.Enabled = true;
                        break;
                    case ePLCType.S7_1200_compatibel:
                    case ePLCType.S7_1500_compatibel:
                        if (cmbConnectionType.SelectedValue == null || (eTypeOfCommunication)cmbConnectionType.SelectedValue == eTypeOfCommunication.TCP)
                        {
                            this.lblAdress3.Text = resources.GetString("lblRack_Text");
                            this.lblAdress4.Text = resources.GetString("lblSlot_Text");
                        }
                        else
                        {
                            this.lblAdress3.Text = resources.GetString("lblBusAdressLocal_Text");
                            this.lblAdress4.Text = resources.GetString("lblBusAdressPLC_Text");
                        }
                        this.txtAdress3.Text = "0";
                        this.txtAdress4.Text = "0";

                        this.lblAdress1.Visible = true;
                        this.lblAdress2.Visible = true;
                        this.lblAdress3.Visible = true;
                        this.lblAdress4.Visible = true;
                        this.txtAdress1.Visible = true;
                        this.txtAdress2.Visible = true;
                        this.txtAdress3.Visible = true;
                        this.txtAdress4.Visible = true;

                        this.lblProtectionUser.Visible = false;
                        this.lblProtectionPassword.Visible = false;
                        this.txtProtectionUser.Visible = false;
                        this.txtProtectionPassword.Visible = false;

                        this.txtIdleTimeSpan.Enabled = true;
                        this.chkAutoConnect.Enabled = true;
                        break;
                    case ePLCType.Symbolic_Tls13:
                    case ePLCType.Symbolic_Legacy:
                        if (cmbConnectionType.SelectedValue == null || (eTypeOfCommunication)cmbConnectionType.SelectedValue == eTypeOfCommunication.TCP)
                        {
                            this.lblAdress3.Text = resources.GetString("lblRack_Text");
                            this.lblAdress4.Text = resources.GetString("lblSlot_Text");
                        }
                        else
                        {
                            this.lblAdress3.Text = resources.GetString("lblBusAdressLocal_Text");
                            this.lblAdress4.Text = resources.GetString("lblBusAdressPLC_Text");
                        }

                        this.txtAdress1.Text = "102";
                        this.txtAdress2.Text = "0";

                        this.lblAdress1.Visible = false;
                        this.lblAdress2.Visible = false;
                        this.lblAdress3.Visible = false;
                        this.lblAdress4.Visible = false;
                        this.txtAdress1.Visible = false;
                        this.txtAdress2.Visible = false;
                        this.txtAdress3.Visible = false;
                        this.txtAdress4.Visible = false;

                        this.lblProtectionUser.Visible = true;
                        this.lblProtectionPassword.Visible = true;
                        this.txtProtectionUser.Visible = true;

                        if ((ePLCType)cmbPLCType.SelectedValue == ePLCType.Symbolic_Legacy)
                        {
                            this.txtProtectionUser.Text = string.Empty;
                            this.txtProtectionUser.Enabled = false;
                        }
                        else
                            this.txtProtectionUser.Enabled = true;

                        this.txtProtectionPassword.Visible = true;
                        this.txtProtectionPassword.Enabled = true;

                        this.chkAutoConnect.Checked = false;
                        this.txtIdleTimeSpan.Enabled = false;
                        this.chkAutoConnect.Enabled = false;
                        break;
                    case ePLCType.Logo0BA7_compatibel:
                        if (cmbConnectionType.SelectedValue == null || (eTypeOfCommunication)cmbConnectionType.SelectedValue == eTypeOfCommunication.TCP)
                        {
                            this.lblAdress3.Text = resources.GetString("Serviceport_Text");
                            this.lblAdress4.Text = resources.GetString("Local_Serviceport_Text");
                            this.txtAdress3.Text = 10001.ToString();
                            this.txtAdress4.Text = 0.ToString();
                        }
                        else
                        {
                            this.lblAdress3.Text = resources.GetString("lblBusAdressLocal_Text");
                            this.lblAdress4.Text = resources.GetString("lblBusAdressPLC_Text");
                            this.txtAdress3.Text = "0";
                            this.txtAdress4.Text = "0";
                        }

                        this.lblAdress1.Visible = true;
                        this.lblAdress2.Visible = true;
                        this.lblAdress3.Visible = true;
                        this.lblAdress4.Visible = true;
                        this.txtAdress1.Visible = true;
                        this.txtAdress2.Visible = true;
                        this.txtAdress3.Visible = true;
                        this.txtAdress4.Visible = true;

                        this.lblProtectionUser.Visible = false;
                        this.lblProtectionPassword.Visible = false;
                        this.txtProtectionUser.Visible = false;
                        this.txtProtectionPassword.Visible = false;

                        this.txtIdleTimeSpan.Enabled = true;
                        this.chkAutoConnect.Enabled = true;
                        break;
                    case ePLCType.Logo0BA8_compatibel:
                    case ePLCType.Logo0BA0_compatibel:
                    case ePLCType.Logo0BA1_compatibel:
                    case ePLCType.Logo0BA2_compatibel:
                        if (cmbConnectionType.SelectedValue == null || (eTypeOfCommunication)cmbConnectionType.SelectedValue == eTypeOfCommunication.TCP)
                        {
                            this.lblAdress3.Text = resources.GetString("Serviceport_Text");
                            this.lblAdress4.Text = resources.GetString("Local_Serviceport_Text");
                            this.txtAdress3.Text = 10005.ToString();
                            this.txtAdress4.Text = 0.ToString();
                        }
                        else
                        {
                            this.lblAdress3.Text = resources.GetString("lblBusAdressLocal_Text");
                            this.lblAdress4.Text = resources.GetString("lblBusAdressPLC_Text");
                            this.txtAdress3.Text = "0";
                            this.txtAdress4.Text = "0";
                        }

                        this.lblAdress1.Visible = true;
                        this.lblAdress2.Visible = true;
                        this.lblAdress3.Visible = true;
                        this.lblAdress4.Visible = true;
                        this.txtAdress1.Visible = true;
                        this.txtAdress2.Visible = true;
                        this.txtAdress3.Visible = true;
                        this.txtAdress4.Visible = true;

                        this.lblProtectionUser.Visible = false;
                        this.lblProtectionPassword.Visible = false;
                        this.txtProtectionUser.Visible = false;
                        this.txtProtectionPassword.Visible = false;

                        this.txtIdleTimeSpan.Enabled = true;
                        this.chkAutoConnect.Enabled = true;
                        break;
                    case ePLCType.Other:
                        if (cmbConnectionType.SelectedValue == null || (eTypeOfCommunication)cmbConnectionType.SelectedValue == eTypeOfCommunication.TCP)
                        {
                            this.lblAdress3.Text = resources.GetString("lblRack_Text");
                            this.lblAdress4.Text = resources.GetString("lblSlot_Text");
                        }
                        else
                        {
                            this.lblAdress3.Text = resources.GetString("lblBusAdressLocal_Text");
                            this.lblAdress4.Text = resources.GetString("lblBusAdressPLC_Text");
                        }
                        this.txtAdress4.Text = "";
                        this.txtAdress3.Text = "";

                        this.lblAdress1.Visible = true;
                        this.lblAdress2.Visible = true;
                        this.lblAdress3.Visible = true;
                        this.lblAdress4.Visible = true;
                        this.txtAdress1.Visible = true;
                        this.txtAdress2.Visible = true;
                        this.txtAdress3.Visible = true;
                        this.txtAdress4.Visible = true;

                        this.lblProtectionUser.Visible = false;
                        this.lblProtectionPassword.Visible = false;
                        this.txtProtectionUser.Visible = false;
                        this.txtProtectionPassword.Visible = false;

                        this.txtIdleTimeSpan.Enabled = true;
                        this.chkAutoConnect.Enabled = true;
                        break;

                    default:
                        MessageBox.Show(this, resources.GetString("undefinend_PLCType"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, resources.GetString("undefinend_PLCType"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            progbarStatusText.Visible = false;
            ProgressBarProjectImport.Visible = false;

            if (mDevice != null)
                mDevice.DisConnect();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            mDevice.DisConnect();
            this.Close();
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mDevice.IsConnected)
            {
                mDevice.DisConnect();
            }
        }

        private void chkAutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            txtIdleTimeSpan.Enabled = chkAutoConnect.Checked;

            SetupDevice();
        }

        private void SetupDevice()
        {
            authentication.Serial = txtSerial.Text;
            authentication.User = txtUser.Text;

            string TypeOfCommunication = string.Empty;
            try
            {
                if (mDevice.IsConnected) mDevice.DisConnect();
                TypeOfCommunication = cmbConnectionType.SelectedValue.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show(this, resources.GetString("undefinend_Connectiontype"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                switch (TypeOfCommunication)
                {
                    case "TLS":
                        mDevice = new Tls13Device(txtAdress0.Text);
                        break;
                    case "TCP":
                        if ((ePLCType)cmbPLCType.SelectedValue == ePLCType.Symbolic_Tls13)
                        {
                            mDevice = new Tls13Device(txtAdress0.Text, txtProtectionUser.Text, txtProtectionPassword.Text);
                        }
                        else if ((ePLCType)cmbPLCType.SelectedValue == ePLCType.Symbolic_Legacy)
                        {
                            mDevice = new LegacySymbolicDevice(txtAdress0.Text, txtProtectionPassword.Text);
                        }
                        else
                        {
                            mDevice = new TCP_ISO_Device(txtAdress0.Text, Convert.ToInt16(txtAdress3.Text), Convert.ToInt16(txtAdress4.Text), (ePLCType)cmbPLCType.SelectedValue);
                            TCP_ISO_Device _device = mDevice as TCP_ISO_Device;
                            _device.TCP_Port_PLC = int.Parse(txtAdress1.Text);
                            _device.TCP_Port_Local = int.Parse(txtAdress2.Text);
                            if ((ePLCType)cmbPLCType.SelectedValue == ePLCType.Logo0BA7_compatibel || (ePLCType)cmbPLCType.SelectedValue == ePLCType.Logo0BA8_compatibel || (ePLCType)cmbPLCType.SelectedValue == ePLCType.Logo0BA0_compatibel || (ePLCType)cmbPLCType.SelectedValue == ePLCType.Logo0BA1_compatibel || (ePLCType)cmbPLCType.SelectedValue == ePLCType.Logo0BA2_compatibel)
                            {
                                _device.TCP_LOGO_ServicePort_PLC = int.Parse(txtAdress3.Text);
                                _device.TCP_LOGO_ServicePort_Local = int.Parse(txtAdress4.Text);
                            }
                        }
                        break;
                    case "MPI":
                        mDevice = new MPI_Device(txtAdress0.Text, int.Parse(txtAdress3.Text), int.Parse(txtAdress4.Text), (eBaudrate)cmbBaudrate.SelectedValue, (eSpeed)cmbBusspeed.SelectedValue, (ePLCType)cmbPLCType.SelectedValue);
                        break;
                    case "PPI":
                        mDevice = new PPI_Device(txtAdress0.Text, int.Parse(txtAdress3.Text), int.Parse(txtAdress4.Text), (eBaudrate)cmbBaudrate.SelectedValue, ePLCType.S7_200_compatibel);
                        break;
                    default:
                        MessageBox.Show(resources.GetString("undefinend_Connectiontype"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                }

                mDevice.OnConnectionStateChange += new PLCcom.PLCcomDevice.ConnectionStateChangeEventHandler(Device_OnConnectionStateChange);

                //Set Auto Connect State
                if (mDevice is SymbolicDevice)
                mDevice.setAutoConnect(chkAutoConnect.Checked);
                else
                    mDevice.setAutoConnect(chkAutoConnect.Checked, uint.Parse(txtIdleTimeSpan.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            authentication.User = txtUser.Text;
        }

        private void txtSerial_TextChanged(object sender, EventArgs e)
        {
            authentication.Serial = txtSerial.Text;
        }

        private void txtIdeleTimeSpan_TextChanged(object sender, EventArgs e)
        {
            ushort us = 0;
            if (!ushort.TryParse(txtIdleTimeSpan.Text, out us))
            {
                txtIdleTimeSpan.Text = us.ToString();
            }
        }


        [DebuggerStepThrough()]
        private void btnSaveConnectionSettings_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

                // Check if the directory exists, if not, create it
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                //Write Settings in PlccomExSettings.xml
                using (XmlTextWriter myXmlTextWriter = new XmlTextWriter(Path.Combine(path, "PlccomExSettings.xml"), System.Text.Encoding.UTF8))
                {

                    myXmlTextWriter.Formatting = Formatting.Indented;
                    myXmlTextWriter.WriteStartDocument(false);
                    myXmlTextWriter.WriteStartElement("Settings");
                    myXmlTextWriter.WriteStartElement("Authentication");
                    myXmlTextWriter.WriteAttributeString("user", txtUser.Text);
                    myXmlTextWriter.WriteAttributeString("serial", txtSerial.Text);
                    myXmlTextWriter.WriteEndElement();

                    myXmlTextWriter.WriteStartElement("Communication");
                    if (cmbConnectionType.SelectedItem != null) myXmlTextWriter.WriteAttributeString("eTypeOfCommunication", cmbConnectionType.SelectedItem.ToString());
                    if (cmbPLCType.SelectedItem != null) myXmlTextWriter.WriteAttributeString("ePLCtype", cmbPLCType.SelectedItem.ToString());
                    if (cmbBaudrate.SelectedItem != null) myXmlTextWriter.WriteAttributeString("eBaudrate", cmbBaudrate.SelectedItem.ToString());
                    if (cmbBusspeed.SelectedItem != null) myXmlTextWriter.WriteAttributeString("eSpeed", cmbBusspeed.SelectedItem.ToString());
                    myXmlTextWriter.WriteAttributeString("Adress0", txtAdress0.Text);
                    myXmlTextWriter.WriteAttributeString("Adress1", txtAdress1.Text);
                    myXmlTextWriter.WriteAttributeString("Adress2", txtAdress2.Text);
                    myXmlTextWriter.WriteAttributeString("Adress3", txtAdress3.Text);
                    myXmlTextWriter.WriteAttributeString("Adress4", txtAdress4.Text);

                    myXmlTextWriter.WriteAttributeString("ProtectionUser", txtProtectionUser.Text);

                    if (!string.IsNullOrEmpty(txtProtectionPassword.Text))
                    {
                        string encryptedPassword = AesEncryption.EncryptString(txtProtectionPassword.Text);
                        myXmlTextWriter.WriteAttributeString("Password", encryptedPassword);
                    }
                    else
                        myXmlTextWriter.WriteAttributeString("Password", string.Empty);


                    myXmlTextWriter.WriteAttributeString("txtIdeleTimeSpan", txtIdleTimeSpan.Text);
                    myXmlTextWriter.WriteAttributeString("AutoConnect", chkAutoConnect.Checked.ToString());
                    myXmlTextWriter.WriteAttributeString("chkAsyncConnect", chkAsyncConnect.Checked.ToString());
                    myXmlTextWriter.WriteEndElement();

                    myXmlTextWriter.WriteEndElement();
                    myXmlTextWriter.WriteEndDocument();
                    myXmlTextWriter.Flush();
                    myXmlTextWriter.Close();
                    MessageBox.Show(resources.GetString("successfully_saved") + Environment.NewLine +
                                    "File: " + Path.Combine(path, "PlccomExSettings.xml"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                grbSerial.Enabled = false;
                btnEditConnectionSettings.Enabled = true;
                grbAccess.Enabled = chkAutoConnect.Checked;
                grbConnectionSettings.Enabled = false;
                grbConnection.Enabled = !chkAutoConnect.Checked;
                SetupDevice();
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change UI language
            SetLanguage((System.Globalization.CultureInfo)cmbLanguage.SelectedItem);
        }

        private void btnEditConnectionSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (CountOpenDialogs > 0)
                {
                    MessageBox.Show(resources.GetString("to_many_windows"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                grbSerial.Enabled = true;
                mDevice.DisConnect();
                btnEditConnectionSettings.Enabled = false;
                grbAccess.Enabled = false;
                grbConnectionSettings.Enabled = true;
                grbConnection.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReadWriteFunctions_Click(object sender, EventArgs e)
        {
            ShowDialogOnNewThread(() =>
                new ReadWriteBox((PLCcomDevice)mDevice)
            );
        }

        private void btnDataServer_Click(object sender, EventArgs e)
        {
            ShowDialogOnNewThread(() =>
                new DataServerFunctions((PLCcomDevice)mDevice)
            );
        }

        private void btnOtherFunctions_Click(object sender, EventArgs e)
        {
            ShowDialogOnNewThread(() =>
                new OtherFunctions((PLCcomCoreDevice)mDevice)
            );
        }

        private void btnBlockFunctions_Click(object sender, EventArgs e)
        {
            ShowDialogOnNewThread(() =>
                new BlockFunctions((PLCcomDevice)mDevice)
            );
        }

        private void btnOptimizedReadWriteBox_Click(object sender, EventArgs e)
        {
            ShowDialogOnNewThread(() =>
                new OptimizedReadWriteBox((PLCcomDevice)mDevice)
            );
        }

        private void btnReadWriteSymbolic_Click(object sender, EventArgs e)
        {
            ShowDialogOnNewThread(() =>
                new ReadWriteSymbolic((SymbolicDevice)mDevice)
            );
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            ShowDialogOnNewThread(() =>
                new AlarmFunctions((SymbolicDevice)mDevice)
            );
        }


        private void btnPlcTypeHelp_Click(object sender, EventArgs e)
        {
            string caption = resources.GetString("captionPlcTypeHelp");
            string message = resources.GetString("messagePlcTypeHelp");
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Opens a WinForms Form on its own STA thread, isolating its UI and message loop from the main window.
        /// This ensures that heavy operations (e.g., loading or disposing large controls) don't block the primary UI thread.
        /// </summary>
        /// <param name="createForm">
        /// A factory delegate that constructs and returns the Form instance to display. 
        /// Use this to pass any Form type along with its required constructor parameters.
        /// </param>
        private void ShowDialogOnNewThread(Func<Form> createForm)
        {
            // 1. Increment the global counter of open dialogs in the main form
            CountOpenDialogs++;

            // 2. Create a new thread dedicated to running the dialog
            var thread = new Thread(() =>
            {
                // 2.1 Instantiate the dialog Form
                Form dialog = createForm();

                // 2.2 When the form closes, exit the message loop on this thread
                dialog.FormClosed += (sender, args) => Application.ExitThread();

                // 2.3 Start a new WinForms message loop on this STA thread
                Application.Run(dialog);
            });

            // 3. WinForms requires STA (single-threaded apartment) model
            thread.SetApartmentState(ApartmentState.STA);

            // 4. Mark as background thread so it doesn't prevent app exit
            thread.IsBackground = true;

            // 5. Begin execution: shows the form and processes its UI events independently
            thread.Start();
        }

    }
}
