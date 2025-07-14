using PLCcom;
using PLCcom.Core.S7Plus;
using PLCcom.Core.S7Plus.AddressSpace;
using PLCcom.Requests.S7Plus;
using PLCcom.Results.S7Plus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PLCCom_Full_Test_App.Symbolic
{
    public partial class ReadWriteSymbolic : Form
    {
        public ReadWriteSymbolic(SymbolicDevice device)
        {
            //set ressources
            resources = new System.Resources.ResourceManager("PLCCom_Full_Test_App.Properties.Resources", this.GetType().Assembly);
            InitializeComponent();
            this._device = device;
        }

        #region Private Member
        private SymbolicDevice _device;
        private System.Resources.ResourceManager resources;
        private string ValuetoWrite = string.Empty;
        //private List<AddressNode> mGlobalAddressTree;
        #endregion

        private void ReadWriteSymbolic_Load(object sender, EventArgs e)
        {
            try
            {
                lblDeviceGUID.Text = "Device Guid: " + _device.DeviceGuid.ToString();
                lblDeviceType.Text = "DeviceType: " + _device.GetType().ToString();

                var globalAddressTree = _device.GetAddressNodeTree();

                treePlcInventory.Nodes.Clear();

                foreach (var addressTreeNode in globalAddressTree)
                {
                    var rootNode = new TreeNode(addressTreeNode.ObjectDescriptor);
                    rootNode.Tag = addressTreeNode.NodeDetails;
                    AddChildNodes(rootNode, addressTreeNode);
                    treePlcInventory.Nodes.Add(rootNode);
                }

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

        private void AddChildNodes(TreeNode parentTreeNode, AddressNode addressNode)
        {
            foreach (var childnode in addressNode.GetChildNodes())
            {
                var childTreeNode = new TreeNode(childnode.NodeDetails.NodeName);
                childTreeNode.Tag = childnode.NodeDetails;
                parentTreeNode.Nodes.Add(childTreeNode);
                AddChildNodes(childTreeNode, childnode);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ReadWriteSymbolic_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
        }




        private void treePlcInventory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                var nodedetails = e.Node.Tag as VariableDetails;
                if (nodedetails != null)
                {
                    txtFullVariableName.Text = nodedetails.FullVariableName;
                    txtDataType.Text = nodedetails.VariableDataType.ToString();
                    picIsReadable.Visible = nodedetails.IsReadable;
                    picNotIsReadable.Visible = !picIsReadable.Visible;
                    picIsWritable.Visible = nodedetails.IsWritable;
                    picNotIsWritable.Visible = !picIsWritable.Visible;

                    picIsArray.Visible = nodedetails.IsArray;
                    picNotIsArray.Visible = !picIsArray.Visible;
                    picIsStruct.Visible = nodedetails.IsStruct;
                    picNotIsStruct.Visible = !picIsStruct.Visible;
                }
                else
                {
                    txtFullVariableName.Text = string.Empty;
                    txtDataType.Text = string.Empty;
                    return;
                }

                if (nodedetails.IsWritable)
                {
                    btnWrite.Enabled = true;
                    txtValue.ReadOnly = false;
                }
                else
                {
                    btnWrite.Enabled = false;
                    txtValue.ReadOnly = true;
                }

                if (nodedetails.IsReadable)
                {

                    ReadSymbolicRequest readRequest = new ReadSymbolicRequest();
                    readRequest.AddFullVariableName(txtFullVariableName.Text);
                    var readResult = _device.ReadData(readRequest) as ReadSymbolicResultSet;
                    if (readResult.Quality == OperationResult.eQuality.GOOD ||
                        readResult.Quality == OperationResult.eQuality.WARNING_PARTITIAL_BAD)
                    {
                        txtValue.Text = readResult.Variables[0].ValueAsJson.ToString();
                    }


                    txtQuality.Text = readResult.Quality.ToString();
                    txtMessage.Text = readResult.Message;

                    switch (readResult.Quality)
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
                    txtValue.Text = string.Empty;
                    txtMessage.Text = string.Empty;
                    txtQuality.Text = string.Empty;
                    txtValue.Text = string.Empty;
                    txtQuality.Text = string.Empty;
                    txtMessage.Text = string.Empty;
                    txtQuality.BackColor = Color.White;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            WriteValue();
        }

        private void WriteValue()
        {
            try
            {
                var variableBody = _device.GetEmptyVariableBody(txtFullVariableName.Text);

                if (variableBody == null)
                    throw new ArgumentNullException("Cannot found variable for writing");

                variableBody.ValueAsJson = txtValue.Text;

                WriteSymbolicRequest writeRequest = new(variableBody);
                WriteSymbolicResultSet writeResult = _device.WriteData(writeRequest);

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

