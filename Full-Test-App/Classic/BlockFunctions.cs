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
    public partial class BlockFunctions : Form
    {
        public BlockFunctions(PLCcomDevice device)
        {
            InitializeComponent();
            this.mDevice = device;
        }

        #region Private Member
        PLCcomDevice mDevice;
        System.Resources.ResourceManager resources;
        #endregion

        private void BlockFunctions_Load(object sender, EventArgs e)
        {
            lblDeviceType.Text = "DeviceType: " + mDevice.GetType().ToString();

            resources = new System.Resources.ResourceManager("PLCCom_Full_Test_App.Properties.Resources", this.GetType().Assembly);

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

        private void btnsendPW_Click(object sender, EventArgs e)
        {
            string PW = string.Empty;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out PW);

            OperationResult res = mDevice.SendPassWordToPlc(PW);


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

        private void btnBlockList_Click(object sender, EventArgs e)
        {

            eBlockType BlockType = eBlockType.AllBlocks;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out BlockType, true);

            //execute Function
            BlockListResult res = mDevice.GetBlockList(BlockType);

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
                //evaluate values
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

        private void btnBlockLen_Click(object sender, EventArgs e)
        {

            eBlockType BlockType = eBlockType.AllBlocks;
            int BlockNumber;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out BlockType, out BlockNumber, false);

            //evaluate results
            BlockListLengthResult res = mDevice.GetBlockLenght(BlockType, BlockNumber);

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

        private void btnBackup_Block_Click(object sender, EventArgs e)
        {
            eBlockType BlockType = eBlockType.AllBlocks;
            int BlockNumber;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out BlockType, out BlockNumber, false);

            //open SaveFileDialog
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.mc7|*.mc7|*.bin|*.bin|*.*|*'.*";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //read Block into ReadPLCBlockResult
                ReadPLCBlockResult res = mDevice.ReadPLCBlock_MC7(BlockType, BlockNumber);

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
                    //save buffer in specified file
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

        private void btnRestore_Block_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.mc7|*.mc7|*.bin|*.bin|*.*|*'.*";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (MessageBox.Show(resources.GetString("Continue_Warning_Restore") +
                                  Environment.NewLine +
                                  resources.GetString("Continue_Question")
                                  , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {


                    using var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[fs.Length];

#if NET7_0_OR_GREATER
                        fs.ReadExactly(buffer);
#elif NETCOREAPP3_1 || NETSTANDARD2_1
                        int total = 0;
                        while (total < buffer.Length)
                        {
                            int read = fs.Read(buffer, total, buffer.Length - total);
                            total += read;
                        }
#else
                    int bytesRead, offset = 0;
                    while ((bytesRead = fs.Read(buffer, offset, buffer.Length - offset)) > 0)
                    {
                        offset += bytesRead;
                        if (offset == buffer.Length) break;
                    }
#endif

                    WritePLCBlockRequest Requestdata = new WritePLCBlockRequest(buffer);
                    //Write Buffer into PLC
                    OperationResult res = mDevice.WritePLCBlock_MC7(Requestdata);

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

        private void btnDeleteBlock_Click(object sender, EventArgs e)
        {
            eBlockType BlockType = eBlockType.AllBlocks;
            int BlockNumber;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out BlockType, out BlockNumber, false);

            if (MessageBox.Show(resources.GetString("Continue_Warning_Delete") +
                                  Environment.NewLine +
                                  resources.GetString("Continue_Question")
                                  , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                OperationResult res = mDevice.DeleteBlock(BlockType, BlockNumber);
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
                    MessageBox.Show("Block " + BlockType.ToString() + BlockNumber.ToString() + " " + resources.GetString("successful_deleted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBackupPLC_Click(object sender, EventArgs e)
        {

            eBlockType BlockType = eBlockType.AllBlocks;
            new BlockFunctionsInputBox().ShowBlockFunctionsInputBox(out BlockType, true);

            BlockListResult res = mDevice.GetBlockList(BlockType);

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

            // Check if the directory exists, if not, create it
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

                //evaluate results
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


                        //read Block into ReadPLCBlockResult
                        ReadPLCBlockResult res1 = mDevice.ReadPLCBlock_MC7(ble.BlockType, ble.BlockNumber);

                        //evaluate results
                        lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res1.ToString());
                        lvi.ForeColor = res1.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                        lvLog.Items.Add(lvi);
                        lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res1.Message);
                        lvi.ForeColor = res1.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                        lvLog.Items.Add(lvi);


                        if (res1.Quality == OperationResult.eQuality.GOOD)
                        {

                            //save buffer in specified file
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

        private void btnRestorePLC_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(resources.GetString("Continue_Warning_Restore") +
                              Environment.NewLine +
                              resources.GetString("Continue_Question")
                              , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {


                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

                // Check if the directory exists, if not, create it
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
                        using var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                        byte[] buffer = new byte[fs.Length];

#if NET7_0_OR_GREATER
                        fs.ReadExactly(buffer);
#elif NETCOREAPP3_1 || NETSTANDARD2_1
                        int total = 0;
                        while (total < buffer.Length)
                        {
                            int read = fs.Read(buffer, total, buffer.Length - total);
                            total += read;
                        }
#else
                        int bytesRead, offset = 0;
                        while ((bytesRead = fs.Read(buffer, offset, buffer.Length - offset)) > 0)
                        {
                            offset += bytesRead;
                            if (offset == buffer.Length) break;
                        }
#endif

                        WritePLCBlockRequest Requestdata = new WritePLCBlockRequest(buffer);

                        //delete Block
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
                        //Write Buffer into PLC
                        OperationResult res = mDevice.WritePLCBlock_MC7(Requestdata);

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

        private void BlockFunctions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
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

    }
}
