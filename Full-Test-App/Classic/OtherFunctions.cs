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
    /// <summary>
    /// Form for executing various auxiliary PLC functions, such as start/stop, time, diagnostic, and status requests.
    /// </summary>
    public partial class OtherFunctions : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OtherFunctions"/> class.
        /// </summary>
        /// <param name="Device">PLCcom device instance to operate on.</param>
        public OtherFunctions(PLCcomCoreDevice Device)
        {
            InitializeComponent();
            this.device = Device;
        }

        #region Private Member

        /// <summary>
        /// Reference to the PLC device to execute functions on.
        /// </summary>
        PLCcomCoreDevice device;

        /// <summary>
        /// Resource manager for localized UI text.
        /// </summary>
        System.Resources.ResourceManager resources;
        #endregion

        /// <summary>
        /// Handles the Load event. Sets up UI texts and labels from resources.
        /// </summary>
        private void OtherFunctions_Load(object sender, EventArgs e)
        {
            lblDeviceType.Text = "DeviceType: " + device.GetType().ToString();

            resources = new System.Resources.ResourceManager("PLCCom_Example_CSharp.Properties.Resources", this.GetType().Assembly);

            // Set localized button and label texts
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

        /// <summary>
        /// Handles the Close button click event. Closes the dialog.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Start PLC button. Starts the PLC and logs the result.
        /// </summary>
        private void btnStartPLC_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(resources.GetString("Continue_Warning_Start") +
                                  Environment.NewLine +
                                  resources.GetString("Continue_Question"),
                                  resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Execute start PLC function
                    OperationResult res = device.StartPLC();

                    // Log results
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

        /// <summary>
        /// Handles the Stop PLC button. Stops the PLC and logs the result.
        /// </summary>
        private void btnStopPLC_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(resources.GetString("Continue_Warning_Stop") +
                                  Environment.NewLine +
                                  resources.GetString("Continue_Question"),
                                  resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Execute stop PLC function
                    OperationResult res = device.StopPLC();

                    // Log results
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

        /// <summary>
        /// Handles the Get PLC Time button. Reads and displays the PLC time.
        /// </summary>
        private void btnGetPLCTime_Click(object sender, EventArgs e)
        {
            try
            {
                // Execute function to get PLC clock time
                PLCClockTimeResult res = device.GetPLCClockTime();

                // Log results
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

                // Display PLC clock time in the values list if successful
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

        /// <summary>
        /// Handles the Set PLC Time button. Sets the PLC clock time to a selected value.
        /// </summary>
        private void btnSetPLCTime_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime PLCDateTime = new DateTime();
                new OtherFunctionsInputBox().ShowOtherFunctionsInputBox(out PLCDateTime);

                if (MessageBox.Show(resources.GetString("Continue_Warning_SetTime") +
                                  Environment.NewLine +
                                  resources.GetString("Continue_Question"),
                                  resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Execute function to set PLC clock time
                    OperationResult res = device.SetPLCClockTime(PLCDateTime);

                    // Log results
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

        /// <summary>
        /// Handles the Basic Info button. Reads and displays device information.
        /// </summary>
        private void btnBasicInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Execute function to get device basic information
                BasicInfoResult res = device.GetBasicInfo();

                // Log results
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

                // Show device information if call was successful
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

        /// <summary>
        /// Handles the CPU Mode button. Reads and displays the CPU mode and state.
        /// </summary>
        private void btnCPUMode_Click(object sender, EventArgs e)
        {
            try
            {
                // Execute function to get CPU mode and state
                CPUModeInfoResult res = device.GetCPUMode();

                // Log results
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

                // Show CPU mode and state if call was successful
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

        /// <summary>
        /// Handles the PLC LED Info button. Reads and displays all available LED information.
        /// </summary>
        private void btnPLCLEDInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Execute function to get PLC LED info
                LEDInfoResult res = device.GetLEDInfo();

                // Log results
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

                // Show LED info if call was successful
                if (res.Quality == OperationResult.eQuality.GOOD)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    for (int i = 0; i < res.LEDInfo.Length; i++)
                    {
                        lvi = new ListViewItem();
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(
                            lvi,
                            "LED: " + res.LEDInfo[i].identifier.ToString() +
                            " State: " + (res.LEDInfo[i].state ? "On " : "Off ") +
                            res.LEDInfo[i].flashing.ToString()));
                        lvValues.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Handles the Diagnose Buffer button. Reads and displays all available diagnostic information.
        /// </summary>
        private void btnDiagnoseBuffer_Click(object sender, EventArgs e)
        {
            try
            {
                // Execute function to get diagnostic information
                DiagnosticInfoResult res = device.GetDiagnosticInfo();

                // Log results
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

                // Display all diagnostic info entries if call was successful
                if (res.Quality == OperationResult.eQuality.GOOD)
                {
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

        /// <summary>
        /// Handles the Read SSL SZL button. Reads and displays a system status list by ID and index.
        /// </summary>
        private void btnReadSSL_SZL_Click(object sender, EventArgs e)
        {
            try
            {
                // Note: You must look up the required SSL ID and index in the PLC documentation.
                // InputBox provides the values as decimal (convert from hex if needed).
                int SSL_ID;
                int SSL_Index;
                new OtherFunctionsInputBox().ShowOtherFunctionsInputBox(out SSL_ID, out SSL_Index);

                // Execute function to read System Status List (SZL)
                SystemStatusListResult res = device.GetSystemStatusList(SSL_ID, SSL_Index);

                // Log results
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

                // Show all buffer bytes of the SZL if call was successful
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

        /// <summary>
        /// Handles the FormClosing event. Decrements the open dialog counter in Main.
        /// </summary>
        private void OtherFunctions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
        }

        /// <summary>
        /// Copies the diagnostic log (lvLog) to the clipboard as text.
        /// </summary>
        private void btnSaveLogtoClipboard_Click(object sender, EventArgs e)
        {
            // Copy diagnostic log to clipboard
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

        /// <summary>
        /// Saves the diagnostic log (lvLog) to a file in the local app data directory.
        /// </summary>
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
                // Copy diagnostic log to file
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
                // Save operation aborted
                MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
