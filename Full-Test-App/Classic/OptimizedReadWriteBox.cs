using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PLCcom;

namespace PLCCom_Full_Test_App.Classic
{
    public partial class OptimizedReadWriteBox : Form
    {

        public OptimizedReadWriteBox(PLCcomDevice Device)
        {
            InitializeComponent();
            this.Device = Device;
        }

        #region Private Member
        private PLCcomDevice Device = null;
        private System.Resources.ResourceManager resources;
        private ReadWriteRequestSet RequestSet = new ReadWriteRequestSet();
        private CreateRequestInputBox RequestInputbox = new CreateRequestInputBox(true);
        #endregion

        private void OptimizedReadWriteBox_Load(object sender, EventArgs e)
        {
            try
            {
                lblDeviceType.Text = "DeviceType: " + Device.GetType().ToString();

                //set ressources
                resources = new System.Resources.ResourceManager("PLCCom_Full_Test_App.Properties.Resources", this.GetType().Assembly);

                cmbReadOptimizeMode.DataSource = Enum.GetValues(typeof(eReadOptimizationMode));
                cmbReadOptimizeMode.SelectedItem = eReadOptimizationMode.NONE;

                cmbWriteOptimizeMode.DataSource = Enum.GetValues(typeof(eWriteOptimizationMode));
                cmbWriteOptimizeMode.SelectedItem = eWriteOptimizationMode.NONE;

                cmbOperationOrder.DataSource = Enum.GetValues(typeof(eOperationOrder));
                cmbOperationOrder.SelectedItem = eOperationOrder.WRITE_BEVOR_READ;
                
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


        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var result = RequestInputbox.ShowDialog();
                if (result == DialogResult.OK && RequestInputbox.RequestItem != null)
                {
                    //add new request to request collection
                    if (RequestInputbox.RequestItem is ReadDataRequest)
                        RequestSet.AddRequest((ReadDataRequest)RequestInputbox.RequestItem);
                    else if (RequestInputbox.RequestItem is WriteDataRequest)
                        RequestSet.AddRequest((WriteDataRequest)RequestInputbox.RequestItem);

                    //update UI controls
                    fillRequestListView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnRemoveRequest_Click(object sender, EventArgs e)
        {
            //remove request from request collection
            try
            {
                if (lvRequests.SelectedItems.Count != 0)
                {
                    RequestSet.RemoveRequest(lvRequests.SelectedItems[0].Text);
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

        private void lvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveRequest.Enabled = lvRequests.SelectedItems.Count != 0;
        }

        private void fillRequestListView()
        {
            //clear ListView initial
            lvRequests.Items.Clear();

            //fill ListView with current ReadDataRequests and WriteDataRequests
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

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                //read from device
                ReadWriteResultSet ResultSet = Device.ReadWriteData(RequestSet);

                txtResults.Text = "";
                txtLog.Text = "";

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
                    sb.Append(Environment.NewLine);
                    AppendColorResults(sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);

                    sb = new StringBuilder();
                    sb.Append("End Result");
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    AppendColorResults(sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);

                    //getting request diagnoctic logs   
                    sb = new StringBuilder();
                    sb.Append("Begin diagnostic log");
                    sb.Append(Environment.NewLine);
                    sb.Append(res.ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("with RequestGuid: ");
                    sb.Append(res.GetRequestGuid());
                    sb.Append(Environment.NewLine);

                    AppendColorLogs(sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);
                    foreach (LogEntry le in res.GetDiagnosticLog())
                    {
                        sb = new StringBuilder();
                        sb.Append(le.ToString());
                        sb.Append(Environment.NewLine);
                        AppendColorLogs(sb.ToString(), le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red);
                    }
                    sb = new StringBuilder();
                    sb.Append("End diagnostic log");
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    AppendColorLogs(sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);
                }
                #endregion 

                #region read results
                //evaluate results
                foreach (ReadDataResult res in ResultSet.GetReadDataResults())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Begin Result");
                    sb.Append(Environment.NewLine);
                    sb.Append(res.ToString());
                    sb.Append(Environment.NewLine);
                    AppendColorResults(sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);

                    if (res.Quality == OperationResult.eQuality.GOOD)
                    {
                        //getting values
                        int counter = 0;
                        foreach (object item in res.GetValues())
                        {
                            sb = new StringBuilder();
                            sb.Append(res.DataType.ToString());
                            sb.Append(": ");
                            sb.Append(counter++.ToString("D" + res.GetValues().Length.ToString().Length.ToString()));
                            sb.Append(" => Value: ");
                            sb.Append(item.ToString());
                            sb.Append(Environment.NewLine);
                            AppendColorResults(sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);
                        }
                    }

                    sb = new StringBuilder();
                    sb.Append("End Result");
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    AppendColorResults(sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);

                    //getting request diagnoctic logs   
                    sb = new StringBuilder();
                    sb.Append("Begin diagnostic log");
                    sb.Append(Environment.NewLine);
                    sb.Append(res.ToString());
                    sb.Append(Environment.NewLine);

                    AppendColorLogs(sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);
                    foreach (LogEntry le in res.GetDiagnosticLog())
                    {
                        sb = new StringBuilder();
                        sb.Append(le.ToString());
                        sb.Append(Environment.NewLine);
                        AppendColorLogs(sb.ToString(), le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red);
                    }
                    sb = new StringBuilder();
                    sb.Append("End diagnostic log");
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    AppendColorLogs(sb.ToString(), res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red);
                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void AppendColorResults(string text, Color color)
        {
            txtResults.SelectionStart = txtResults.TextLength;
            txtResults.SelectionLength = 0;

            txtResults.SelectionColor = color;
            txtResults.AppendText(text);
            txtResults.SelectionColor = txtResults.ForeColor;
        }

        private void AppendColorLogs(string text, Color color)
        {
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.SelectionLength = 0;

            txtLog.SelectionColor = color;
            txtLog.AppendText(text);
            txtLog.SelectionColor = txtLog.ForeColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSaveLogtoClipboard_Click(object sender, EventArgs e)
        {
            //copy diagnostic log to clipboard
            Clipboard.SetText(txtLog.Text, TextDataFormat.Rtf);
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
                //abort message
                MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OptimizedReadWriteBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
        }

        private void cmbReadOptimizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequestSet.SetReadOptimizationMode((eReadOptimizationMode)cmbReadOptimizeMode.SelectedItem);
        }

        private void cmbWriteOptimizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequestSet.SetWriteOptimizationMode((eWriteOptimizationMode)cmbWriteOptimizeMode.SelectedItem);
        }

        private void cmbOperationOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            //write opertion order to RequestSet
            RequestSet.SetOperationOrder((eOperationOrder)cmbOperationOrder.SelectedItem);
        }

        private void btnHelpReadOptMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show(resources.GetString("Hint_Read_OptimizationMode_Text"), resources.GetString("Hint_Read_OptimizationMode_Overview"),MessageBoxButtons.OK,MessageBoxIcon.Information );
        }

        private void btnHelpWriteOptMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show(resources.GetString("Hint_Write_OptimizationMode_Text"), resources.GetString("Hint_Write_OptimizationMode_Overview"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
