using PLCcom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PLCCom_Full_Test_App.Classic
{
    /// <summary>
    /// Form for optimized read and write operations to a PLC device using request sets and advanced options.
    /// </summary>
    public partial class OptimizedReadWriteBox : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizedReadWriteBox"/> class.
        /// </summary>
        /// <param name="Device">The PLCcomDevice to communicate with.</param>
        public OptimizedReadWriteBox(PLCcomDevice Device)
        {
            InitializeComponent();
            this.Device = Device;
        }

        #region Private Member

        /// <summary>
        /// The device instance for PLC communication.
        /// </summary>
        private PLCcomDevice Device = null;

        /// <summary>
        /// Resource manager for localized strings.
        /// </summary>
        private System.Resources.ResourceManager resources;

        /// <summary>
        /// The request set containing all read and write requests.
        /// </summary>
        private ReadWriteRequestSet RequestSet = new ReadWriteRequestSet();

        /// <summary>
        /// Input box for creating new requests.
        /// </summary>
        private CreateRequestInputBox RequestInputbox = new CreateRequestInputBox(true);

        #endregion

        /// <summary>
        /// Handles the form load event. Initializes UI controls and resource strings.
        /// </summary>
        private void OptimizedReadWriteBox_Load(object sender, EventArgs e)
        {
            try
            {
                lblDeviceType.Text = "DeviceType: " + Device.GetType().ToString();

                // Set resources for localized UI strings
                resources = new System.Resources.ResourceManager("PLCCom_Example_CSharp.Properties.Resources", this.GetType().Assembly);

                cmbReadOptimizeMode.DataSource = Enum.GetValues(typeof(eReadOptimizationMode));
                cmbReadOptimizeMode.SelectedItem = eReadOptimizationMode.NONE;

                cmbWriteOptimizeMode.DataSource = Enum.GetValues(typeof(eWriteOptimizationMode));
                cmbWriteOptimizeMode.SelectedItem = eWriteOptimizationMode.NONE;

                cmbOperationOrder.DataSource = Enum.GetValues(typeof(eOperationOrder));
                cmbOperationOrder.SelectedItem = eOperationOrder.WRITE_BEVOR_READ;

                // Set all relevant UI texts
                this.lblLog.Text = resources.GetString("lblLog_Text");
                this.grpAddress.Text = resources.GetString("grpAddress_Text");
                this.grpAction.Text = resources.GetString("grpAction_Text");
                this.btnClose.Text = resources.GetString("btnClose_Text");
                this.btnAddRequest.Text = resources.GetString("btnAddRequest_Text");
                this.btnRemoveRequest.Text = resources.GetString("btnRemoveRequest_Text");
                this.btnExecute.Text = resources.GetString("btnExecute_Text");
                this.txtInfoRCB.Text = resources.GetString("txtInfoRCB_Text");
                this.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveLogtoClipboard_Text");
                this.btnSaveLogtoFile.Text = resources.GetString("btnSaveLogtoFile_Text");
                this.lblReadOptimizationMode.Text = resources.GetString("lblReadOptimizationMode_Text");
                this.lblWriteOptimizationMode.Text = resources.GetString("lblWriteOptimizationMode_Text");
                this.lblOperationOrder.Text = resources.GetString("lblOperationOrder_Text");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Add Request button. Opens a dialog to add a new read/write request to the set.
        /// </summary>
        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var result = RequestInputbox.ShowDialog();
                if (result == DialogResult.OK && RequestInputbox.RequestItem != null)
                {
                    // Add new request to the request set
                    if (RequestInputbox.RequestItem is ReadDataRequest)
                        RequestSet.AddRequest((ReadDataRequest)RequestInputbox.RequestItem);
                    else if (RequestInputbox.RequestItem is WriteDataRequest)
                        RequestSet.AddRequest((WriteDataRequest)RequestInputbox.RequestItem);

                    // Update UI controls with new request list
                    fillRequestListView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Handles the Remove Request button. Removes the selected request from the request set.
        /// </summary>
        private void btnRemoveRequest_Click(object sender, EventArgs e)
        {
            // Remove request from request set based on selection
            try
            {
                if (lvRequests.SelectedItems.Count != 0)
                {
                    RequestSet.RemoveRequest(new Guid(lvRequests.SelectedItems[0].Text));
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
        /// Enables or disables the Remove button depending on the list selection.
        /// </summary>
        private void lvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveRequest.Enabled = lvRequests.SelectedItems.Count != 0;
        }

        /// <summary>
        /// Populates the request list view with all read and write requests, in order.
        /// </summary>
        private void fillRequestListView()
        {
            // Clear ListView before updating
            lvRequests.Items.Clear();

            // Fill ListView according to operation order (write before read or vice versa)
            switch (RequestSet.GetOperationOrder())
            {
                case eOperationOrder.WRITE_BEVOR_READ:
                    foreach (WriteDataRequest rr in RequestSet.GetWriteDataRequests())
                    {
                        ListViewItem lvi = new ListViewItem(rr.GetRequestGuid().ToString());
                        lvi.SubItems.Add(rr.ToString());
                        lvRequests.Items.Add(lvi);
                    }
                    foreach (ReadDataRequest rr in RequestSet.GetReadDataRequests())
                    {
                        ListViewItem lvi = new ListViewItem(rr.GetRequestGuid().ToString());
                        lvi.SubItems.Add(rr.ToString());
                        lvRequests.Items.Add(lvi);
                    }
                    break;

                case eOperationOrder.READ_BEVOR_WRITE:
                    foreach (ReadDataRequest rr in RequestSet.GetReadDataRequests())
                    {
                        ListViewItem lvi = new ListViewItem(rr.GetRequestGuid().ToString());
                        lvi.SubItems.Add(rr.ToString());
                        lvRequests.Items.Add(lvi);
                    }
                    foreach (WriteDataRequest rr in RequestSet.GetWriteDataRequests())
                    {
                        ListViewItem lvi = new ListViewItem(rr.GetRequestGuid().ToString());
                        lvi.SubItems.Add(rr.ToString());
                        lvRequests.Items.Add(lvi);
                    }
                    break;
            }
        }

        /// <summary>
        /// Executes all requests in the set and displays the results and logs.
        /// </summary>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Stopwatch plcExecutionTimer = Stopwatch.StartNew();

                // Execute the full request set (read and write in order)
                ReadWriteResultSet ResultSet = Device.ReadWriteData(RequestSet);

                plcExecutionTimer.Stop();

                txtResults.Text = "";
                txtLog.Text = "";

                var rtfResultEntries = new List<(string Text, Color Color)>();
                var rtfDiagnosticEntries = new List<(string Text, Color Color)>();

                #region write results

                foreach (WriteDataResult res in ResultSet.GetWriteDataResults())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Begin Result");
                    sb.Append(Environment.NewLine);
                    sb.Append(res.ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("with RequestGuid: ");
                    sb.Append(res.GetRequestGuid());
                    rtfResultEntries.Add((sb.ToString(), res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red));

                    sb = new StringBuilder();
                    sb.Append("End Result");
                    sb.Append(Environment.NewLine);
                    rtfResultEntries.Add((sb.ToString(), res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red));

                    // Append diagnostic logs for write request
                    sb = new StringBuilder();
                    sb.Append("Begin diagnostic log");
                    sb.Append(Environment.NewLine);
                    sb.Append(res.ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("with RequestGuid: ");
                    sb.Append(res.GetRequestGuid());
                    rtfDiagnosticEntries.Add((sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red));

                    foreach (LogEntry le in res.GetDiagnosticLog())
                    {
                        sb = new StringBuilder();
                        sb.Append(le.ToString());
                        sb.Append(Environment.NewLine);
                        rtfDiagnosticEntries.Add((sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red));
                    }
                    sb = new StringBuilder();
                    sb.Append("End diagnostic log");
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    rtfDiagnosticEntries.Add((sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red));
                }
                #endregion

                #region read results
                // Process read request results
                foreach (ReadDataResult res in ResultSet.GetReadDataResults())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Begin Result");
                    sb.Append(Environment.NewLine);
                    sb.Append(res.ToString());

                    rtfResultEntries.Add((sb.ToString(), res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red));

                    if (res.Quality == OperationResult.eQuality.GOOD)
                    {
                        // Output values for successful reads
                        int counter = 0;
                        var resultValues = res.GetValues().Cast<object>().ToArray();

                        foreach (var item in resultValues)
                        {
                            sb = new StringBuilder();
                            sb.Append(res.DataType.ToString());
                            sb.Append(": ");
                            sb.Append(counter++.ToString("D" + resultValues.Length.ToString().Length.ToString()));
                            sb.Append(" => Value: ");
                            sb.Append(item.ToString());
                            rtfResultEntries.Add((sb.ToString(), res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red));
                        }
                    }

                    sb = new StringBuilder();
                    sb.Append("End Result");
                    sb.Append(Environment.NewLine);

                    rtfResultEntries.Add((sb.ToString(), res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red));

                    // Append diagnostic logs for read request
                    sb = new StringBuilder();
                    sb.Append("Begin diagnostic log");
                    sb.Append(Environment.NewLine);
                    sb.Append(res.ToString());

                    rtfDiagnosticEntries.Add((sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red));
                    foreach (LogEntry le in res.GetDiagnosticLog())
                    {
                        sb = new StringBuilder();
                        sb.Append(le.ToString());
                        rtfDiagnosticEntries.Add((sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red));
                    }
                    sb = new StringBuilder();
                    sb.Append("End diagnostic log");
                    sb.Append(Environment.NewLine);
                    rtfDiagnosticEntries.Add((sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red));
                }
                #endregion

                // Add PLC execution time as the final diagnostic entry
                rtfDiagnosticEntries.Add(("Plc Execution Time: " + plcExecutionTimer.ElapsedMilliseconds + " ms", Color.Blue));

                // Build RTF strings for results and diagnostic logs
                string rtf = BuildRtf(rtfResultEntries);
                txtResults.Rtf = rtf;

                rtf = BuildRtf(rtfDiagnosticEntries);
                txtLog.Rtf = rtf;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Helper that constructs the RTF header, color table, and escaped text for output.
        /// </summary>
        /// <param name="entries">List of result or diagnostic entries, each with text and color.</param>
        /// <returns>Complete RTF-formatted string for a RichTextBox.</returns>
        private string BuildRtf(List<(string Text, Color Color)> entries)
        {
            // Collect the distinct colors used
            var palette = entries
                .Select(e => e.Color)
                .Distinct()
                .ToList();

            var sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi{\colortbl;");

            // Add each color to the color table (index 0 is default)
            foreach (var c in palette)
                sb.Append($@"\red{c.R}\green{c.G}\blue{c.B};");
            sb.Append("}");

            // Append each entry, prefixing with its color index
            foreach (var (text, color) in entries)
            {
                int colorIndex = palette.IndexOf(color) + 1; // +1 since 0 is default
                // Escape RTF special chars and convert line breaks
                string safeText = text
                    .Replace(@"\", @"\\")
                    .Replace("{", @"\{")
                    .Replace("}", @"\}")
                    .Replace("\r\n", @"\par ")
                    .Replace("\n", @"\par ");

                sb.Append($@"\cf{colorIndex} {safeText}\par ");
            }

            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// Handles the Close button click event. Closes the form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Copies the log output (in RTF format) to the clipboard.
        /// </summary>
        private void btnSaveLogtoClipboard_Click(object sender, EventArgs e)
        {
            // Copy diagnostic log to clipboard as RTF text
            Clipboard.SetText(txtLog.Text, TextDataFormat.Rtf);
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
                sb.Append(txtLog.Text);
                sb.Append(Environment.NewLine);

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
        /// Handles the form closing event. Decrements the open dialog counter in Main.
        /// </summary>
        private void OptimizedReadWriteBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
        }

        /// <summary>
        /// Handles the selection change of the read optimization mode combo box.
        /// Updates the request set accordingly.
        /// </summary>
        private void cmbReadOptimizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequestSet.SetReadOptimizationMode((eReadOptimizationMode)cmbReadOptimizeMode.SelectedItem);
        }

        /// <summary>
        /// Handles the selection change of the write optimization mode combo box.
        /// Updates the request set accordingly.
        /// </summary>
        private void cmbWriteOptimizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequestSet.SetWriteOptimizationMode((eWriteOptimizationMode)cmbWriteOptimizeMode.SelectedItem);
        }

        /// <summary>
        /// Handles the selection change of the operation order combo box.
        /// Updates the request set accordingly.
        /// </summary>
        private void cmbOperationOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Write operation order to request set
            RequestSet.SetOperationOrder((eOperationOrder)cmbOperationOrder.SelectedItem);
        }

        /// <summary>
        /// Shows help for the read optimization mode.
        /// </summary>
        private void btnHelpReadOptMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show(resources.GetString("Hint_Read_OptimizationMode_Text"), resources.GetString("Hint_Read_OptimizationMode_Overview"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows help for the write optimization mode.
        /// </summary>
        private void btnHelpWriteOptMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show(resources.GetString("Hint_Write_OptimizationMode_Text"), resources.GetString("Hint_Write_OptimizationMode_Overview"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
