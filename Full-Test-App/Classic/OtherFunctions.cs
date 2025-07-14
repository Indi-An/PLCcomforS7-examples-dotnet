using System;
using System.Drawing;
using System.Windows.Forms;
using PLCcom;
using System.Text;
using System.IO;
using PLCcom.Results.S7Plus;
using PLCcom.Requests.S7Plus;
using System.Globalization;


namespace PLCCom_Full_Test_App.Classic
{
    public partial class OtherFunctions : Form
    {

        public OtherFunctions(PLCcomCoreDevice Device)
        {
            InitializeComponent();
            this.device = Device;
        }

        #region Private Member
        PLCcomCoreDevice device;
        System.Resources.ResourceManager resources;
        #endregion


        private void OtherFunctions_Load(object sender, EventArgs e)
        {
            lblDeviceType.Text = "DeviceType: " + device.GetType().ToString();

            resources = new System.Resources.ResourceManager("PLCCom_Full_Test_App.Properties.Resources", this.GetType().Assembly);

            this.btnStartPLC.Text = resources.GetString("btnStartPLC_Text");
            this.btnStopPLC.Text = resources.GetString("btnStopPLC_Text");
            this.btnGetPLCTime.Text = resources.GetString("btnGetPLCTime_Text");
            this.btnsetPLCTime.Text = resources.GetString("btnsetPLCTime_Text");
            this.btnBasicInfo.Text = resources.GetString("btnBasicInfo_Text");
            this.btnCPUMode.Text = resources.GetString("btnCPUMode_Text");
            this.btnPLCLEDInfo.Text = resources.GetString("btnPLCLEDInfo_Text");
            this.btnReadSSL_SZL.Text = resources.GetString("btnReadSSL_SZL_Text");
            this.btnDiagnoseBuffer.Text = resources.GetString("btnDiagnoseBuffer_Text");
            this.lblLog.Text = resources.GetString("lblLog_Text");
            this.grpAction.Text = resources.GetString("grpAction_Text");
            this.btnClose.Text = resources.GetString("btnClose_Text");
            this.txtInfoOF.Text = resources.GetString("txtInfoOF_Text");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStartPLC_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(resources.GetString("Continue_Warning_Start") +
                                  Environment.NewLine +
                                  resources.GetString("Continue_Question")
                                  , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //execute function
                    OperationResult res = device.StartPLC();

                    //starting evaluate results
                    //set diagnostic output
                    lvLog.Items.Clear();
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                    lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                    lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
                    lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                    foreach (LogEntry le in res.GetDiagnosticLog())
                    {
                        lvi = new ListViewItem(le.ToString());
                        lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                        lvLog.Items.Add(lvi);
                    }
                    lvValues.Items.Clear();
                }
                else
                {
                    MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnStopPLC_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(resources.GetString("Continue_Warning_Stop") +
                                  Environment.NewLine +
                                  resources.GetString("Continue_Question")
                                  , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //execute function
                    OperationResult res = device.StopPLC();

                    //starting evaluate results
                    //set diagnostic output
                    lvLog.Items.Clear();
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                    lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                    lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
                    lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                    foreach (LogEntry le in res.GetDiagnosticLog())
                    {
                        lvi = new ListViewItem(le.ToString());
                        lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                        lvLog.Items.Add(lvi);
                    }
                    lvValues.Items.Clear();
                }
                else
                {
                    MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnGetPLCTime_Click(object sender, EventArgs e)
        {
            try
            {

                //execute function
                PLCClockTimeResult res = device.GetPLCClockTime();

                //starting evaluate results
                //set diagnostic output
                lvLog.Items.Clear();
                ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                foreach (LogEntry le in res.GetDiagnosticLog())
                {
                    lvi = new ListViewItem(le.ToString());
                    lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                }
                lvValues.Items.Clear();

                if (res.Quality == OperationResult.eQuality.GOOD)
                {
                    lvi = new ListViewItem();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, res.PLCClockTime.ToString()));
                    lvValues.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnSetPLCTime_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime PLCDateTime = new DateTime();
                new OtherFunctionsInputBox().ShowOtherFunctionsInputBox(out PLCDateTime);

                if (MessageBox.Show(resources.GetString("Continue_Warning_SetTime") +
                                  Environment.NewLine +
                                  resources.GetString("Continue_Question")
                                  , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //execute function
                    OperationResult res = device.SetPLCClockTime(PLCDateTime);

                    //starting evaluate results
                    //set diagnostic output
                    lvLog.Items.Clear();
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                    lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                    lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
                    lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                    foreach (LogEntry le in res.GetDiagnosticLog())
                    {
                        lvi = new ListViewItem(le.ToString());
                        lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                        lvLog.Items.Add(lvi);
                    }
                    lvValues.Items.Clear();

                }
                else
                {
                    MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnBasicInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //execute function
                BasicInfoResult res = device.GetBasicInfo();

                //starting evaluate results
                //set diagnostic output
                lvLog.Items.Clear();
                ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                foreach (LogEntry le in res.GetDiagnosticLog())
                {
                    lvi = new ListViewItem(le.ToString());
                    lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                }
                lvValues.Items.Clear();

                if (res.Quality == OperationResult.eQuality.GOOD)
                {
                    lvi = new ListViewItem();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Device Name: " + res.Name));
                    lvValues.Items.Add(lvi);

                    lvi = new ListViewItem();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Order Number: " + res.OrderNumber));
                    lvValues.Items.Add(lvi);

                    lvi = new ListViewItem();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Module Version: " + res.ModuleVersion));
                    lvValues.Items.Add(lvi);

                    lvi = new ListViewItem();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Firmware Version: " + res.FirmwareVersion));
                    lvValues.Items.Add(lvi);

                    lvi = new ListViewItem();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Simulated Order Number: " + res.SimulatedOrderNumber));
                    lvValues.Items.Add(lvi);

                    lvi = new ListViewItem();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Simulated Firmware Version: " + res.SimulatedFirmwareVersion));
                    lvValues.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnCPUMode_Click(object sender, EventArgs e)
        {
            try
            {
                //execute function
                CPUModeInfoResult res = device.GetCPUMode();

                //starting evaluate results
                //set diagnostic output
                lvLog.Items.Clear();
                ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                foreach (LogEntry le in res.GetDiagnosticLog())
                {
                    lvi = new ListViewItem(le.ToString());
                    lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                }
                lvValues.Items.Clear();

                if (res.Quality == OperationResult.eQuality.GOOD)
                {
                    lvi = new ListViewItem();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "CPU Mode: " + res.CPUModeInfo.ToString()));
                    lvValues.Items.Add(lvi);

                    lvi = new ListViewItem();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "CPU State: " + res.CPUStateInfo.ToString()));
                    lvValues.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnPLCLEDInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //execute function
                LEDInfoResult res = device.GetLEDInfo();

                //starting evaluate results
                //set diagnostic output
                lvLog.Items.Clear();
                ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                foreach (LogEntry le in res.GetDiagnosticLog())
                {
                    lvi = new ListViewItem(le.ToString());
                    lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                }
                lvValues.Items.Clear();


                if (res.Quality == OperationResult.eQuality.GOOD)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    for (int i = 0; i < res.LEDInfo.Length; i++)
                    {
                        lvi = new ListViewItem();
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "LED: " + res.LEDInfo[i].identifier.ToString() + " State: " + (res.LEDInfo[i].state ? "On " : "Off ") + res.LEDInfo[i].flashing.ToString()));
                        lvValues.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnDiagnoseBuffer_Click(object sender, EventArgs e)
        {
            try
            {

                //read the diagnosticinfo into DiagnosticInfoResult-object
                //execute function
                DiagnosticInfoResult res = device.GetDiagnosticInfo();

                //starting evaluate results
                //set diagnostic output
                lvLog.Items.Clear();
                ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                foreach (LogEntry le in res.GetDiagnosticLog())
                {
                    lvi = new ListViewItem(le.ToString());
                    lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                }
                lvValues.Items.Clear();

                if (res.Quality == OperationResult.eQuality.GOOD)
                {

                    //step through the entries
                    foreach (DiagnosticInfoEntry myDiagnosticInfoEntry in res.DiagnosticInfoEntrys)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(resources.GetString("Timestamp") + ": " + myDiagnosticInfoEntry.DiagnosticTimestamp.ToString());
                        sb.Append(" ");
                        sb.Append("ID: " + myDiagnosticInfoEntry.DiagnosticID.ToString());
                        sb.Append(" ");
                        sb.Append(resources.GetString("Message") + ": " + myDiagnosticInfoEntry.DiagnosticText);

                        lvi = new ListViewItem();
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, sb.ToString()));
                        lvValues.Items.Add(lvi);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnReadSSL_SZL_Click(object sender, EventArgs e)
        {

            try
            {
                // important!!! please search the id and index information in the plc-documentation
                // You must convert the specified values hex in decimal
                int SSL_ID;
                int SSL_Index;
                new OtherFunctionsInputBox().ShowOtherFunctionsInputBox(out SSL_ID, out SSL_Index);

                //execute function
                SystemStatusListResult res = device.GetSystemStatusList(SSL_ID, SSL_Index);

                //starting evaluate results
                //set diagnostic output
                lvLog.Items.Clear();
                ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
                foreach (LogEntry le in res.GetDiagnosticLog())
                {
                    lvi = new ListViewItem(le.ToString());
                    lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                }
                lvValues.Items.Clear();

                if (res.Quality == OperationResult.eQuality.GOOD)
                {
                    foreach (SystemStatusListResult.SystemStatusListItemEntry ssle in res.SZLItemEntrys)
                    {
                        foreach (byte b in ssle.buffer)
                        {

                            lvi = new ListViewItem();
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, b.ToString()));
                            lvValues.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void OtherFunctions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
        }

        private void btnSaveLogtoClipboard_Click(object sender, EventArgs e)
        {
            //copy diagnostic log to clipboard
            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem lvi in lvLog.Items)
            {
                sb.Append(lvi.Text);
                sb.Append(Environment.NewLine);
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
            }
        }

        private void btnSaveLogtoFile_Click(object sender, EventArgs e)
        {

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

            // Check if the directory exists, if not, create it
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            SaveFileDialog mySaveDialog = new SaveFileDialog();
            mySaveDialog.InitialDirectory = path;
            mySaveDialog.Filter = "Log|*.log";
            mySaveDialog.Title = "Save an Diagnostic File";
            mySaveDialog.FileName = "PLCcomDiagnosticLog.log";

            if (mySaveDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(mySaveDialog.FileName))
            {
                //copy diagnostic log to file
                StringBuilder sb = new StringBuilder();
                foreach (ListViewItem lvi in lvLog.Items)
                {
                    sb.Append(lvi.Text);
                    sb.Append(Environment.NewLine);
                }

                FileStream fs = File.Create(mySaveDialog.FileName);
                BinaryWriter bw = new BinaryWriter(fs);

                if (!string.IsNullOrEmpty(sb.ToString()))
                {
                    bw.Write(System.Text.Encoding.Default.GetBytes(sb.ToString()));
                }
                bw.Close();
                fs.Close();

                MessageBox.Show(resources.GetString("successfully_saved") + Environment.NewLine +
                                 "File: " + mySaveDialog.FileName, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //abort message
                MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



    }
}
