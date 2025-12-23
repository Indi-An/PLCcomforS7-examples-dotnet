using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using PLCcom;
using PLCcom.PLCComDataServer;

namespace PLCCom_Full_Test_App.Classic
{
    /// <summary>
    /// Form for controlling and monitoring the PLCcom DataServer.
    /// Allows configuring requests, logging, optimization and observing server state.
    /// </summary>
    public partial class DataServerFunctions : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataServerFunctions"/> class.
        /// Chooses the DataServer type depending on the provided device.
        /// Registers event handlers for state and log updates.
        /// </summary>
        /// <param name="Device">The PLC device to use for the DataServer.</param>
        public DataServerFunctions(PLCcomDevice Device)
        {
            InitializeComponent();

            // Create an instance depending on the device type
            if (Device is TCP_ISO_Device)
            {
                this.myDataServer = new PLCcom.PLCComDataServer.PLCComDataServer_TCP("PLCDataServerTCP1", (TCP_ISO_Device)Device, 500);
            }
            else if (Device is MPI_Device)
            {
                this.myDataServer = new PLCcom.PLCComDataServer.PLCComDataServer_MPI("PLCDataServerMPI1", (MPI_Device)Device, 500);
            }
            else if (Device is PPI_Device)
            {
                this.myDataServer = new PLCcom.PLCComDataServer.PLCComDataServer_PPI("PLCDataServerPPI1", (PPI_Device)Device, 500);
            }

            // Register event handlers for DataServer events
            myDataServer.OnConnectionStateChange += new PLCComDataServer.ConnectionStateChangeEventHandler(myDataServer_OnConnectionStateChange);
            myDataServer.OnReadDataResultChange += new PLCComDataServer.ReadDataResultChangeEventHandler(myDataServer_OnReadDataResultChange);
            myDataServer.OnIncomingLogEntry += new PLCComDataServer.OnIncomingLogEntryDelegate(myDataServer_OnIncomingLogEntry);
        }

        #region Private Member

        /// <summary>
        /// The instance of the DataServer.
        /// </summary>
        PLCComDataServer myDataServer = null;

        /// <summary>
        /// Resource manager for localized UI text.
        /// </summary>
        System.Resources.ResourceManager resources;

        // Delegates for UI thread-invocation of event handlers
        private delegate void dlgtOnConnectionStateChange(object sender, eConnectionState e);
        private delegate void dlgtOnReadDataResultChange(object sender, ReadDataResult Result);
        private delegate void dlgOnIncomingLogEntryCallback(LogEntry[] e);

        /// <summary>
        /// Dialog for creating a new read request.
        /// </summary>
        private CreateRequestInputBox RequestInputbox = new CreateRequestInputBox(false);

        #endregion

        /// <summary>
        /// Initializes controls, populates combos and sets resource strings on form load.
        /// </summary>
        private void DataServerFunctions_Load(object sender, EventArgs e)
        {
            try
            {
                lblDeviceType.Text = "DeviceType: " + myDataServer.GetType().ToString();

                cmbLogLevel.DataSource = Enum.GetValues(typeof(eLogLevel));
                cmbReadOptimizeMode.DataSource = Enum.GetValues(typeof(eReadOptimizationMode));
                cmbReadOptimizeMode.SelectedItem = eReadOptimizationMode.AUTO;

                // Set resources for UI strings
                 resources = new System.Resources.ResourceManager(
                    this.GetType().Assembly.GetName().Name + ".Properties.Resources",
                    this.GetType().Assembly
                );

                this.chkLogging.Text = resources.GetString("lblLog_Text");
                this.grpAddress.Text = resources.GetString("grpAddress_Text");
                this.grpAction.Text = resources.GetString("grpAction_Text");
                this.btnClose.Text = resources.GetString("btnClose_Text");
                this.btnAddRequest.Text = resources.GetString("btnAddRequest_Text");
                this.btnRemoveRequest.Text = resources.GetString("btnRemoveRequest_Text");
                this.btnStartServer.Text = resources.GetString("btnStartServer_Text");
                this.btnStopServer.Text = resources.GetString("btnStopServer_Text");
                this.txtInfoDS.Text = resources.GetString("txtInfoDS_Text");
                this.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveLogtoClipboard_Text");
                this.btnSaveLogtoFile.Text = resources.GetString("btnSaveLogtoFile_Text");
                this.btnLoggingSettings.Text = resources.GetString("btnLoggingSettings_Text");
                this.txtInfoLoggingConnectors.Text = resources.GetString("txtInfoLoggingConnectors_Text");
                this.lblReadOptimizationMode.Text = resources.GetString("lblReadOptimizationMode_Text");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new read request to the DataServer and updates the request list.
        /// </summary>
        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var result = RequestInputbox.ShowDialog();
                if (result == DialogResult.OK && RequestInputbox.RequestItem != null)
                {
                    // Add new request to request collection
                    myDataServer.AddReadDataRequest((ReadDataRequest)RequestInputbox.RequestItem);

                    // Update UI controls
                    fillRequestListView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Removes the selected request from the DataServer and the value view.
        /// </summary>
        private void btnRemoveRequest_Click(object sender, EventArgs e)
        {
            // Remove request from request collection and corresponding values
            try
            {
                if (lvRequests.SelectedItems.Count != 0)
                {
                    myDataServer.RemoveReadDataRequest(Guid.Parse(lvRequests.SelectedItems[0].Text));
                }

                if (lvValues.Items.ContainsKey(lvRequests.SelectedItems[0].Text))
                {
                    lvValues.Items.RemoveByKey(lvRequests.SelectedItems[0].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                fillRequestListView();
            }
        }

        /// <summary>
        /// Enables or disables the Remove button depending on selection in request list.
        /// </summary>
        private void lvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveRequest.Enabled = lvRequests.SelectedItems.Count != 0;
        }

        /// <summary>
        /// Populates the request ListView with all current read requests.
        /// </summary>
        private void fillRequestListView()
        {
            // Clear ListView initially
            lvRequests.Items.Clear();

            // Fill ListView with current ReadDataRequests
            foreach (ReadDataRequest rr in myDataServer.GetReadDataRequests())
            {
                ListViewItem lvi = new ListViewItem(rr.GetRequestGuid().ToString());
                lvi.SubItems.Add(rr.ToString());
                lvRequests.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Starts the DataServer and enables/disables server control buttons.
        /// </summary>
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                // Start PLCcom DataServer
                myDataServer.SetReadOptimizationMode((eReadOptimizationMode)cmbReadOptimizeMode.SelectedItem);
                myDataServer.StartServer();
                btnStartServer.Enabled = false;
                btnStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Stops the DataServer and enables/disables server control buttons.
        /// </summary>
        private void btnStopServer_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop PLCcom DataServer
                myDataServer.StopServer();
                btnStartServer.Enabled = true;
                btnStopServer.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Event handler for receiving new read data results from DataServer.
        /// Updates or adds rows in the values ListView for each request.
        /// </summary>
        void myDataServer_OnReadDataResultChange(object sender, ReadDataResult Result)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new dlgtOnReadDataResultChange(myDataServer_OnReadDataResultChange), new object[] { sender, Result });
            }
            else
            {
                // Process incoming results
                if (lvValues.Items.ContainsKey(Result.Itemkey.ToString()))
                {
                    // Key exists => update row in ListView
                    ListViewItem lvi = lvValues.Items[Result.Itemkey.ToString()];
                    lvi.SubItems[1].Text = DateTime.Now.ToString("hh:mm:ss.fff");
                    lvi.SubItems[3].Text = ArrayToString(Result.GetValues());
                    lvi.SubItems[4].Text = Result.Quality.ToString();
                    lvi.ForeColor = (Result.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);
                }
                else
                {
                    // Key does not exist => insert row into ListView
                    ListViewItem lvi = new ListViewItem();
                    lvi.Name = Result.Itemkey.ToString();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, DateTime.Now.ToString("hh:mm:ss.fff")));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, Result.Itemkey.ToString()));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, ArrayToString(Result.GetValues())));
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, Result.Quality.ToString()));
                    lvi.ForeColor = (Result.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);
                    lvValues.Items.Add(lvi);
                }
            }
        }

        /// <summary>
        /// Converts an Array of values to a comma-separated string.
        /// </summary>
        private string ArrayToString(Array value)
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

        /// <summary>
        /// Event handler for incoming log entries from DataServer.
        /// Populates the log ListView and keeps only last 100 entries.
        /// </summary>
        void myDataServer_OnIncomingLogEntry(LogEntry[] e)
        {
            // Incoming OnIncomingLogEntry event: add log entries to ListView
            if (!chkLogging.Checked) return;
            if (lvLog.InvokeRequired)
            {
                // Invoke required, call again in UI thread
                try
                {
                    dlgOnIncomingLogEntryCallback callInvoke = new dlgOnIncomingLogEntryCallback(myDataServer_OnIncomingLogEntry);
                    lvLog.Invoke(callInvoke, new object[] { e });
                }
                catch (InvalidOperationException)
                {
                    // Can occur during shutdown; ignore
                }
            }
            else
            {
                // Write LogEntry into ListView
                foreach (LogEntry le in e)
                {
                    if (le.getLogLevel() < (eLogLevel)cmbLogLevel.SelectedItem) return;
                    lock (lvLog)
                    {
                        ListViewItem lvi = new ListViewItem(le.ToString());
                        lvi.ForeColor = le.getLogLevel().Equals(eLogLevel.Error) ? Color.Red : Color.Black;
                        lvLog.Items.Add(lvi);

                        while (lvLog.Items.Count > 100)
                        {
                            lvLog.Items.RemoveAt(0);
                        }
                        if (chkAutoScroll.Checked && lvLog.Items.Count > 1) lvLog.Items[lvLog.Items.Count - 1].EnsureVisible();
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for changes in DataServer connection state.
        /// Updates status display accordingly.
        /// </summary>
        void myDataServer_OnConnectionStateChange(object sender, eConnectionState e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new dlgtOnConnectionStateChange(myDataServer_OnConnectionStateChange), new object[] { sender, e });
            }
            else
            {
                txtDeviceState.Text = resources.GetString("State_" + e.ToString()) + (myDataServer.GetPlcDeviceInfo() != null ? " " + myDataServer.GetPlcDeviceInfo().Name : string.Empty);
                txtDeviceState.BackColor = e == eConnectionState.connected ? Color.Green : Color.White;
                txtDeviceState.ForeColor = e == eConnectionState.connected ? Color.White : Color.Black;
            }
        }

        /// <summary>
        /// Closes the DataServer and the form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (myDataServer != null) myDataServer.StopServer();
            this.Close();
        }

        /// <summary>
        /// Copies the log output to the clipboard as plain text.
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
        /// Saves the log output to a file in the user's local app data directory.
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

        /// <summary>
        /// Handles form closing event. Stops the DataServer and decrements the open dialog counter.
        /// </summary>
        private void DataServerFunctions_FormClosing(object sender, FormClosingEventArgs e)
        {
            myDataServer.StopServer();
            MainForm.CountOpenDialogs--;
        }

        /// <summary>
        /// Opens the logging settings dialog and updates info about logging connectors.
        /// </summary>
        private void btnLoggingSettings_Click(object sender, EventArgs e)
        {
            DataServerLoggingSettings dsls = new DataServerLoggingSettings();
            myDataServer = dsls.ShowSettings(myDataServer);
            if (myDataServer.GetLoggingConnectors().Length == 0)
            {
                this.txtInfoLoggingConnectors.Text = resources.GetString("txtInfoLoggingConnectors_Text");
            }
            else
            {
                this.txtInfoLoggingConnectors.Text = myDataServer.GetLoggingConnectors().Length.ToString() + " " + resources.GetString("txtInfoLoggingDefinedConnectors_Text");
            }
        }

        /// <summary>
        /// Changes the read optimization mode of the DataServer.
        /// </summary>
        private void cmbReadOptimizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            myDataServer.SetReadOptimizationMode((eReadOptimizationMode)cmbReadOptimizeMode.SelectedItem);
        }

        /// <summary>
        /// Shows help for read optimization modes.
        /// </summary>
        private void btnHelpReadOptMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show(resources.GetString("Hint_Read_OptimizationMode_Text"), resources.GetString("Hint_Read_OptimizationMode_Overview"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
