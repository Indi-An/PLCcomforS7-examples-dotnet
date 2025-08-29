using PLCcom;
using PLCcom.Core.S7Plus;
using PLCcom.Core.S7Plus.AddressSpace;
using PLCcom.Requests.S7Plus;
using PLCcom.Results.S7Plus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PLCCom_Full_Test_App.Symbolic
{
    /// <summary>
    /// WinForms form for symbolic reading and writing of PLC variables using the PLCcom library.
    /// </summary>
    public partial class ReadWriteSymbolic : Form
    {
        /// <summary>
        /// Initializes the form and assigns the symbolic device.
        /// </summary>
        /// <param name="device">The symbolic device to interact with.</param>
        public ReadWriteSymbolic(SymbolicDevice device)
        {
            // Load localized UI resources from assembly
            resources = new System.Resources.ResourceManager("PLCCom_Full_Test_App.Properties.Resources", this.GetType().Assembly);

            InitializeComponent();
            this._device = device;
        }

        #region Private Member
        private SymbolicDevice _device;
        private System.Resources.ResourceManager resources;
        private string ValuetoWrite = string.Empty;
        #endregion

        /// <summary>
        /// Handles form load. Initializes device info, UI text, and populates the TreeView with root nodes.
        /// </summary>
        private void ReadWriteSymbolic_Load(object sender, EventArgs e)
        {
            try
            {
                // Display device GUID and type in the UI
                lblDeviceGUID.Text = "Device Guid: " + _device.DeviceGuid.ToString();
                lblDeviceType.Text = "DeviceType: " + _device.GetType().ToString();

                // Obtain the global address tree from the device
                var globalAddressTree = _device.GetAddressNodeTree();

                treePlcInventory.BeginUpdate();
                treePlcInventory.Nodes.Clear();

                foreach (var addressNode in globalAddressTree)
                {
                    var rootNode = new TreeNode(addressNode.ObjectDescriptor)
                    {
                        Tag = addressNode    // Store AddressNode object in the TreeNode's Tag property
                    };

                    // Add a dummy child if there are further nodes, for lazy loading
                    if (addressNode.GetChildNodes().Any())
                        rootNode.Nodes.Add(new TreeNode("Load…"));

                    treePlcInventory.Nodes.Add(rootNode);
                }
                treePlcInventory.EndUpdate();

                // Register handler for expanding nodes (lazy loading)
                treePlcInventory.AfterExpand += TreePlcInventory_AfterExpand;

                // Set UI labels from localized resources
                this.lblLog.Text = resources.GetString("lblLog_Text");
                this.grpAddress.Text = resources.GetString("grpAddress_Text");
                this.btnClose.Text = resources.GetString("btnClose_Text");
                this.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveLogtoClipboard_Text");
                this.btnSaveLogtoFile.Text = resources.GetString("btnSaveLogtoFile_Text");
                this.txtInfoSymbRB.Text = resources.GetString("txtInfosSymbRBText");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Dynamically loads child nodes when a TreeView node is expanded (lazy loading).
        /// </summary>
        private void TreePlcInventory_AfterExpand(object sender, TreeViewEventArgs e)
        {
            // Show wait cursor for user feedback during potentially long operation
            Application.UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents(); // Force repaint so the cursor is visible

            try
            {
                var node = e.Node;

                // Only process nodes with a dummy ("Load…") child
                if (node.Nodes.Count == 1 && node.Nodes[0].Text == "Load…")
                {
                    this.UseWaitCursor = true;

                    // Refresh UI to ensure the expanded state and "Load…" dummy are painted
                    this.Refresh();
                    treePlcInventory.Refresh();
                    Application.DoEvents();

                    // Remove the dummy and load the real children
                    node.Nodes.Clear();

                    var parent = (AddressNode)node.Tag;
                    var children = parent.GetChildNodes().ToArray();

                    // Prepare child nodes, each with a dummy if it also has children
                    var newNodes = children.Select(child =>
                    {
                        var tn = new TreeNode(child.NodeDetails.NodeName)
                        {
                            Tag = child
                        };
                        if (child.GetChildNodes().Any())
                            tn.Nodes.Add(new TreeNode("Load…"));
                        return tn;
                    }).ToArray();


                    // Add all new child nodes in a single update block for performance
                    treePlcInventory.BeginUpdate();
                    treePlcInventory.SuspendLayout();
                    node.Nodes.AddRange(newNodes);
                    treePlcInventory.ResumeLayout(false);
                    treePlcInventory.EndUpdate();
                }
            }
            finally
            {
                // Restore default cursor
                Application.UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the Close button click and closes the form. Unsubscribes TreeView events for cleanup.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Unregister TreeView event handlers to prevent further event firing
            treePlcInventory.AfterExpand -= TreePlcInventory_AfterExpand;
            treePlcInventory.AfterSelect -= treePlcInventory_AfterSelect;
            this.Close();
        }

        /// <summary>
        /// Copies all log entries from the ListView to the clipboard as plain text.
        /// </summary>
        private void btnSaveLogtoClipboard_Click(object sender, EventArgs e)
        {
            // Build log as single string
            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem lvi in lvLog.Items)
            {
                sb.Append(lvi.Text);
                sb.Append(Environment.NewLine);
            }
            // Copy to clipboard if log is not empty
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
            }
        }

        /// <summary>
        /// Saves all log entries from the ListView to a .log file in the user's LocalApplicationData folder.
        /// </summary>
        private void btnSaveLogtoFile_Click(object sender, EventArgs e)
        {
            // Compose default log file path in LocalApplicationData
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

            // Ensure the log directory exists
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
                // Collect log entries to write
                StringBuilder sb = new StringBuilder();
                foreach (ListViewItem lvi in lvLog.Items)
                {
                    sb.Append(lvi.Text);
                    sb.Append(Environment.NewLine);
                }

                // Write log to selected file in binary format
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
                // Inform user if operation was cancelled
                MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Decrements the open dialog counter in the main form when this dialog is closed.
        /// </summary>
        private void ReadWriteSymbolic_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
        }

        /// <summary>
        /// Handles TreeView node selection, displays variable details and enables read/write UI state accordingly.
        /// </summary>
        private void treePlcInventory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // Cast the Tag property to AddressNode, clear fields if null
                if (!(e.Node.Tag is AddressNode selectedNode))
                {
                    ClearDetailFields();
                    return;
                }

                var details = selectedNode.NodeDetails;

                // Update UI fields with variable details
                txtFullVariableName.Text = details.FullVariableName;
                txtDataType.Text = details.VariableDataType.ToString();

                picIsReadable.Visible = details.IsReadable;
                picNotIsReadable.Visible = !details.IsReadable;
                picIsWritable.Visible = details.IsWritable;
                picNotIsWritable.Visible = !details.IsWritable;
                picIsSubscribable.Visible = details.IsSubscribable;
                picNotIsSubscribable.Visible = !details.IsSubscribable;

                picIsArray.Visible = details.IsArray;
                picNotIsArray.Visible = !details.IsArray;
                picIsStruct.Visible = details.IsStruct;
                picNotIsStruct.Visible = !details.IsStruct;

                btnWrite.Enabled = details.IsWritable;
                txtValue.ReadOnly = !details.IsWritable;

                // If variable is readable, display its value; otherwise clear value fields
                if (details.IsReadable)
                    UpdateReadValues(details.FullVariableName);
                else
                    ClearReadValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Clears detail fields for variable name, type, and all read values.
        /// </summary>
        private void ClearDetailFields()
        {
            txtFullVariableName.Clear();
            txtDataType.Clear();
            ClearReadValues();
        }

        /// <summary>
        /// Clears value, quality, and message fields for read operations and resets background color.
        /// </summary>
        private void ClearReadValues()
        {
            txtValue.Clear();
            txtQuality.Clear();
            txtMessage.Clear();
            txtQuality.BackColor = Color.White;
        }

        /// <summary>
        /// Executes a read operation for the given variable name and updates UI with results.
        /// </summary>
        /// <param name="fullVarName">The full symbolic name of the variable to read.</param>
        private void UpdateReadValues(string fullVarName)
        {
            var req = new ReadSymbolicRequest();
            req.AddFullVariableName(fullVarName);
            var res = _device.ReadData(req) as ReadSymbolicResultSet;

            // Update UI with value and quality
            if (res.IsQualityGoodOrWarning())
                txtValue.Text = res.Variables[0].ValueAsJson.ToString();
            else
                txtValue.Text =string.Empty;

            txtQuality.Text = res.Quality.ToString();
            txtMessage.Text = res.Message;

            // Set background color based on quality
            switch (res.Quality)
            {
                case OperationResult.eQuality.GOOD:
                    txtQuality.BackColor = Color.LimeGreen;
                    break;
                case OperationResult.eQuality.WARNING_PARTITIAL_BAD:
                    txtQuality.BackColor = Color.Yellow;
                    break;
                default:
                    txtQuality.BackColor = Color.Red;
                    break;
            }
        }

        /// <summary>
        /// Handles the Write button click event and triggers value writing.
        /// </summary>
        private void btnWrite_Click(object sender, EventArgs e)
        {
            WriteValue();
        }

        /// <summary>
        /// Performs a symbolic write operation for the current variable and updates the UI with the write result.
        /// </summary>
        private void WriteValue()
        {
            try
            {
                var variableBody = _device.GetEmptyVariableBody(txtFullVariableName.Text);

                if (variableBody == null)
                    throw new ArgumentNullException("Cannot found variable for writing");

                // Set the value to write from the UI textbox
                variableBody.ValueAsJson = txtValue.Text;

                WriteSymbolicRequest writeRequest = new(variableBody);
                WriteSymbolicResultSet writeResult = _device.WriteData(writeRequest);

                // If the write operation is good or partially good, update UI with detailed result
                if (writeResult.IsQualityGoodOrWarning())
                {
                    txtQuality.Text = writeResult.WriteOperationResults[0].Quality.ToString();
                    txtMessage.Text = writeResult.WriteOperationResults[0].Message;

                    switch (writeResult.WriteOperationResults[0].Quality)
                    {
                        case OperationResult.eQuality.GOOD:
                            txtQuality.BackColor = Color.LimeGreen;
                            break;
                        case OperationResult.eQuality.WARNING_PARTITIAL_BAD:
                            txtQuality.BackColor = Color.Yellow;
                            break;
                        default:
                            txtQuality.BackColor = Color.Red;
                            break;
                    }
                }
                else
                {
                    // Otherwise display the overall write quality and message
                    txtQuality.Text = writeResult.Quality.ToString();
                    txtMessage.Text = writeResult.Message;

                    switch (writeResult.Quality)
                    {
                        case OperationResult.eQuality.GOOD:
                            txtQuality.BackColor = Color.LimeGreen;
                            break;
                        case OperationResult.eQuality.WARNING_PARTITIAL_BAD:
                            txtQuality.BackColor = Color.Yellow;
                            break;
                        default:
                            txtQuality.BackColor = Color.Red;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
