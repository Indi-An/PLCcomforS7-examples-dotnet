using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PLCcom;
using System.IO;
using System.Threading;

namespace PLCCom_Full_Test_App.Classic
{
    /// <summary>
    /// Form for executing and managing PLC block functions such as block listing, length, backup, restore, and deletion.
    /// </summary>
    public partial class BlockFunctions : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockFunctions"/> class.
        /// </summary>
        /// <param name="device">The PLC device to operate on.</param>
        public BlockFunctions(PLCcomDevice device)
        {
            InitializeComponent();
            this.mDevice = device;
        }

        #region Private Member

        /// <summary>
        /// The PLC device used for block operations.
        /// </summary>
        PLCcomDevice mDevice;

        /// <summary>
        /// Resource manager for localized UI text.
        /// </summary>
        System.Resources.ResourceManager resources;
        #endregion

        /// <summary>
        /// Handles the form load event. Initializes controls and loads UI strings from resources.
        /// </summary>
        private void BlockFunctions_Load(object sender, EventArgs e)
        {
            lblDeviceType.Text = "DeviceType: " + mDevice.GetType().ToString();

            resources = new System.Resources.ResourceManager(
                this.GetType().Assembly.GetName().Name + ".Properties.Resources",
                this.GetType().Assembly
            );

            this.btnsendPW.Text = resources.GetString("btnsendPW_Text");
            this.btnBlockList.Text = resources.GetString("btnBlockList_Text");
            this.btnBlockLen.Text = resources.GetString("btnBlockLen_Text");
            this.btnBackup_Block.Text = resources.GetString("btnBackup_Block_Text");
            this.btnRestore_Block.Text = resources.GetString("btnRestore_Block_Text");
            this.btnDeleteBlock.Text = resources.GetString("btnDeleteBlock_Text");
            this.grpAction.Text = resources.GetString("grpAction_Text");
            this.btnClose.Text = resources.GetString("btnClose_Text");
            this.lblLog.Text = resources.GetString("lblLog_Text");
            this.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveLogtoClipboard_Text");
            this.btnSaveLogtoFile.Text = resources.GetString("btnSaveLogtoFile_Text");
            this.txtInfoBF.Text = resources.GetString("txtInfoBF_Text");
        }

        /// <summary>
        /// Sends a password to the PLC for block protection/unprotection.
        /// </summary>
        private void btnsendPW_Click(object sender, EventArgs e)
        {
            string PW = string.Empty;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out PW);

            OperationResult res = mDevice.SendPassWordToPlc(PW);

            // Evaluate and display results and diagnostic log
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

        /// <summary>
        /// Gets and displays the block list for a selected block type.
        /// </summary>
        private void btnBlockList_Click(object sender, EventArgs e)
        {
            eBlockType BlockType = eBlockType.AllBlocks;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out BlockType, true);

            // Execute function
            BlockListResult res = mDevice.GetBlockList(BlockType);

            // Evaluate and display results and diagnostic log
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
                // Display block list entries
                foreach (BlockListEntry ble in res.BlockList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(ble.BlockType.ToString());
                    sb.Append(ble.BlockNumber.ToString());
                    sb.Append(Environment.NewLine);

                    lvi = new ListViewItem();
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, sb.ToString()));
                    lvValues.Items.Add(lvi);
                }
            }
        }

        /// <summary>
        /// Gets and displays the length of a selected block.
        /// </summary>
        private void btnBlockLen_Click(object sender, EventArgs e)
        {
            eBlockType BlockType = eBlockType.AllBlocks;
            int BlockNumber;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out BlockType, out BlockNumber, false);

            // Get block length result
            BlockListLengthResult res = mDevice.GetBlockLenght(BlockType, BlockNumber);

            // Evaluate and display results and diagnostic log
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
                StringBuilder sb = new StringBuilder();
                sb.Append(res.BlockType.ToString());
                sb.Append(res.BlockNumber.ToString());
                sb.Append(" Len:");
                sb.Append(res.BlockLength.ToString());
                sb.Append(Environment.NewLine);

                lvi = new ListViewItem();
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, sb.ToString()));
                lvValues.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Reads and backs up a PLC block to a file (.mc7 or .bin).
        /// </summary>
        private void btnBackup_Block_Click(object sender, EventArgs e)
        {
            eBlockType BlockType = eBlockType.AllBlocks;
            int BlockNumber;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out BlockType, out BlockNumber, false);

            // Open file dialog to choose backup location
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.mc7|*.mc7|*.bin|*.bin|*.*|*'.*";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Read block data
                ReadPLCBlockResult res = mDevice.ReadPLCBlock_MC7(BlockType, BlockNumber);

                // Evaluate and display results and diagnostic log
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
                    // Save buffer to specified file
                    System.IO.FileStream fs = new System.IO.FileStream(sfd.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    fs.Write(res.Buffer, 0, res.Buffer.Length);
                    fs.Close();
                    MessageBox.Show("Block " + BlockType.ToString() + BlockNumber.ToString() + resources.GetString("successful_saved") + sfd.FileName, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Restores a PLC block from a selected file.
        /// </summary>
        private void btnRestore_Block_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.mc7|*.mc7|*.bin|*.bin|*.*|*'.*";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (MessageBox.Show(resources.GetString("Continue_Warning_Restore") +
                                  Environment.NewLine +
                                  resources.GetString("Continue_Question"),
                                  resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Read block data from file
                    System.IO.FileStream fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    fs.Close();

                    WritePLCBlockRequest Requestdata = new WritePLCBlockRequest(buffer);
                    // Write buffer into PLC
                    OperationResult res = mDevice.WritePLCBlock_MC7(Requestdata);

                    // Evaluate and display results and diagnostic log
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
                        MessageBox.Show("Block " + Requestdata.BlockInfo.Header.BlockType.ToString() + Requestdata.BlockInfo.Header.BlockNumber.ToString() + resources.GetString("successful_saved_PLC") + ofd.FileName, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Deletes a selected block on the PLC.
        /// </summary>
        private void btnDeleteBlock_Click(object sender, EventArgs e)
        {
            eBlockType BlockType = eBlockType.AllBlocks;
            int BlockNumber;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out BlockType, out BlockNumber, false);

            if (MessageBox.Show(resources.GetString("Continue_Warning_Delete") +
                                  Environment.NewLine +
                                  resources.GetString("Continue_Question"),
                                  resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                OperationResult res = mDevice.DeleteBlock(BlockType, BlockNumber);
                // Evaluate and display results and diagnostic log
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
                    MessageBox.Show("Block " + BlockType.ToString() + BlockNumber.ToString() + " " + resources.GetString("successful_deleted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Backs up all PLC blocks to a selected folder.
        /// </summary>
        private void btnBackupPLC_Click(object sender, EventArgs e)
        {
            eBlockType BlockType = eBlockType.AllBlocks;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out BlockType, true);

            BlockListResult res = mDevice.GetBlockList(BlockType);

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

            // Ensure the directory exists
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FolderBrowserDialog myFolderBrowserDialog = new FolderBrowserDialog();
            myFolderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            myFolderBrowserDialog.SelectedPath = path;
            myFolderBrowserDialog.Description = "Select Folder";

            if (myFolderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(myFolderBrowserDialog.SelectedPath))
            {
                // Log results and show block list
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
                    StringBuilder sb = new StringBuilder();
                    sb.Append(resources.GetString("reading_blocklist"));
                    foreach (BlockListEntry ble in res.BlockList)
                    {
                        sb = new StringBuilder();
                        sb.Append(ble.BlockType.ToString());
                        sb.Append(ble.BlockNumber.ToString());

                        lvi = new ListViewItem();
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, sb.ToString()));
                        lvValues.Items.Add(lvi);
                    }

                    foreach (BlockListEntry ble in res.BlockList)
                    {
                        sb = new StringBuilder();
                        sb.Append(resources.GetString("starting_backup"));
                        sb.Append(ble.BlockType.ToString());
                        sb.Append(ble.BlockNumber.ToString());

                        // Read each block and save to file
                        ReadPLCBlockResult res1 = mDevice.ReadPLCBlock_MC7(ble.BlockType, ble.BlockNumber);

                        // Log results for each block
                        lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res1.ToString());
                        lvi.ForeColor = res1.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                        lvLog.Items.Add(lvi);
                        lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res1.Message);
                        lvi.ForeColor = res1.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                        lvLog.Items.Add(lvi);

                        if (res1.Quality == OperationResult.eQuality.GOOD)
                        {
                            // Save buffer to file
                            string Filename = myFolderBrowserDialog.SelectedPath + @"\" + ble.BlockType.ToString() + "_" + ble.BlockNumber + ".mc7";
                            System.IO.FileStream fs = new System.IO.FileStream(Filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                            fs.Write(res1.Buffer, 0, res1.Buffer.Length);
                            fs.Close();
                            lvi = new ListViewItem("Block " + ble.BlockType.ToString() + ble.BlockNumber.ToString() + resources.GetString("successful_saved") + Filename);
                            lvLog.Items.Add(lvi);
                            lvi = new ListViewItem();
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, sb.ToString()));
                            lvValues.Items.Add(lvi);
                        }
                        else
                        {
                            sb.Append(res1.Quality.ToString());
                            lvi = new ListViewItem();
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, sb.ToString()));
                            lvValues.Items.Add(lvi);
                            break;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Restores all PLC blocks from .mc7 files in a selected folder.
        /// </summary>
        private void btnRestorePLC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(resources.GetString("Continue_Warning_Restore") +
                              Environment.NewLine +
                              resources.GetString("Continue_Question"),
                              resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

                // Ensure directory exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FolderBrowserDialog myFolderBrowserDialog = new FolderBrowserDialog();
                myFolderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                myFolderBrowserDialog.SelectedPath = path;
                myFolderBrowserDialog.Description = "Select Folder";

                if (myFolderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(myFolderBrowserDialog.SelectedPath))
                {
                    StringBuilder sb = new StringBuilder();
                    string[] files = Directory.GetFiles(myFolderBrowserDialog.SelectedPath, "*.mc7");

                    foreach (string FileName in files)
                    {
                        System.IO.FileStream fs = new System.IO.FileStream(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, (int)fs.Length);
                        fs.Close();

                        WritePLCBlockRequest Requestdata = new WritePLCBlockRequest(buffer);

                        // First delete the block if it exists
                        OperationResult resdelete = mDevice.DeleteBlock(Requestdata.RequestedBlockType, Requestdata.Blocknumber);
                        if (resdelete.Quality == OperationResult.eQuality.GOOD)
                        {
                            sb.Append("Block " + Requestdata.BlockInfo.Header.BlockType.ToString() + Requestdata.BlockInfo.Header.BlockNumber.ToString() + " " + resources.GetString("successful_deleted"));
                            sb.Append(Environment.NewLine);
                        }
                        else
                        {
                            sb.Append("Block " + Requestdata.BlockInfo.Header.BlockType.ToString() + Requestdata.BlockInfo.Header.BlockNumber.ToString() + " " + resources.GetString("not_successful_deleted") + " Quality:" + resdelete.Quality.ToString());
                            sb.Append(Environment.NewLine);
                        }

                        //Thread.Sleep(500);
                        // Write buffer into PLC
                        OperationResult res = mDevice.WritePLCBlock_MC7(Requestdata);

                        // Evaluate and display results and diagnostic log
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
                            sb.Append("Block " + Requestdata.BlockInfo.Header.BlockType.ToString() + Requestdata.BlockInfo.Header.BlockNumber.ToString() + resources.GetString("successful_saved_PLC") + FileName);
                        }
                        else if (res.Quality == OperationResult.eQuality.BAD_NO_PERMISSION_TO_ACCESS_THE_OBJECT)
                        {
                            sb.Append("Block " + Requestdata.BlockInfo.Header.BlockType.ToString() + Requestdata.BlockInfo.Header.BlockNumber.ToString() + " unsuccessfull Quality" + res.Quality.ToString() + " " + FileName);
                        }
                        else if (res.Quality == OperationResult.eQuality.BAD_DEVICE_IS_NOT_CONNECTED)
                        {
                            sb.Append("Block " + Requestdata.BlockInfo.Header.BlockType.ToString() + Requestdata.BlockInfo.Header.BlockNumber.ToString() + " unsuccessfull Quality" + res.Quality.ToString() + " " + FileName);
                            break;
                        }
                        else
                        {
                            sb.Append("Block " + Requestdata.BlockInfo.Header.BlockType.ToString() + Requestdata.BlockInfo.Header.BlockNumber.ToString() + " unsuccessfull Quality" + res.Quality.ToString() + " " + FileName);
                            //break;
                        }
                        sb.Append(Environment.NewLine);
                        lvi = new ListViewItem(sb.ToString());
                        lvLog.Items.Add(lvi);
                    }
                }
            }
            else
            {
                MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles form closing event: decrements global dialog counter.
        /// </summary>
        private void BlockFunctions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
        }

        /// <summary>
        /// Handles Close button click event.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Copies the log output to clipboard as plain text.
        /// </summary>
        private void btnSaveLogtoClipboard_Click(object sender, EventArgs e)
        {
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
        /// Saves the log output to a file in the local application data directory.
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
