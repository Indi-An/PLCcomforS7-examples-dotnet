using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using PLCcom;
using System.Linq;
using PLCcom.Core.S7Plus.DataTypes;

namespace PLCCom_Full_Test_App.Classic
{
    public partial class ReadWriteBox : Form
    {

        public ReadWriteBox(PLCcomDevice mDevice)
        {
            //set ressources
            resources = new System.Resources.ResourceManager("PLCCom_Full_Test_App.Properties.Resources", this.GetType().Assembly);
            InitializeComponent();
            this.Device = mDevice;
        }

        #region Private Member
        private PLCcomDevice Device;
        private System.Resources.ResourceManager resources;
        private string ValuetoWrite = string.Empty;
        #endregion

        private void ReadWriteBox_Load(object sender, EventArgs e)
        {
            try
            {
                lblDeviceType.Text = "DeviceType: " + Device.GetType().ToString();

                cmbRegion.DataSource = Enum.GetValues(typeof(eRegion));

                List<eDataType> lisDataType = new List<eDataType>();
                lisDataType.AddRange((eDataType[])Enum.GetValues(typeof(eDataType)));
                cmbDataType.DataSource = lisDataType;

                cmbDataType.Text = eDataType.BYTE.ToString();

                //set the culture combobox
                List<String> lisEncodings = new List<String>();
                foreach (EncodingInfo ei in Encoding.GetEncodings())
                {
                    lisEncodings.Add(ei.Name);
                }
                cmbCodepage.DataSource = lisEncodings;
                cmbCodepage.SelectedItem = "us-ascii";


                this.lblLog.Text = resources.GetString("lblLog_Text");
                this.grpAddress.Text = resources.GetString("grpAddress_Text");
                this.grpAction.Text = resources.GetString("grpAction_Text");
                this.lblDataType.Text = resources.GetString("lblDataType_Text");
                this.lblReadAdress.Text = resources.GetString("lblReadAddress_Text");
                this.lblWriteAddress.Text = resources.GetString("lblWriteAddress_Text");
                this.lblBit.Text = resources.GetString("lblBit_Text");
                this.lblLength.Text = resources.GetString("lblLength_Text");
                this.btnClose.Text = resources.GetString("btnClose_Text");
                this.btnExecute.Text = resources.GetString("btnExecute_Text");
                this.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveLogtoClipboard_Text");
                this.btnSaveLogtoFile.Text = resources.GetString("btnSaveLogtoFile_Text");
                this.txtInfoRB.Text = resources.GetString("txtInfoRB_OR_Text");
                this.chkSingleValue.Text = resources.GetString("chkSingleValue_Text");
                this.lblEnterValues.Text = resources.GetString("lblValues_Text");
                this.lblRegion.Text = resources.GetString("lblRegion_Text");
                this.lblMode.Text = resources.GetString("lblMode_Text");
                this.rbRead.Text = resources.GetString("rbRead_Text");
                this.rbWrite.Text = resources.GetString("rbWrite_Text");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            switch (rbRead.Checked)
            {
                case true:
                    //execute read
                    ExecRead();
                    break;
                case false:
                    //execute write
                    ExecWrite();
                    break;
            }
        }

        private void ExecRead()
        {
            try
            {
                Device.Connecttimeout = 5000;
                Device.Readtimeout = 5000;
                //declare a ReadDataRequest object and
                //set the request parameters
                ReadDataRequest myReadDataRequest = new ReadDataRequest((eRegion)cmbRegion.SelectedValue,   //Region
                                                                       int.Parse(txtDB.Text),             //DB / only for datablock operations otherwise 0
                                                                       int.Parse(txtReadAddress.Text),      //read start adress
                                                                       (eDataType)cmbDataType.SelectedValue,//desired datatype
                                                                       int.Parse(txtQuantity.Text) * int.Parse(txtFactor.Text), //Quantity of reading values
                                                                       byte.Parse(txtBit.Text),//Bit / only for bit opertions
                                                                       Encoding.GetEncoding((string)cmbCodepage.SelectedItem)); //Optionally the Encoding for eventual string operations           


                //read from device
                ReadDataResult res = Device.ReadData(myReadDataRequest);

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


                //evaluate values
                lvValues.Items.Clear();
                lvValues.Columns[1].Text = "Position";
                if (res.Quality == OperationResult.eQuality.GOOD)
                {
                    int Position = 0;
                    foreach (Object item in res.GetValues())
                    {
                        lvi = new ListViewItem();
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, Position++.ToString()));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, item.ToString()));
                        lvi.ForeColor = (item is bool && (bool)item == true ? Color.Blue : Color.Black);
                        lvValues.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ExecWrite()
        {
            try
            {
                //parse valuestring and add writable Data here
                Utilities.sValues_to_Write vtw = null;
                vtw = Utilities.CheckValues(ValuetoWrite, (eDataType)cmbDataType.SelectedItem);

                if (!vtw.ParseError)
                {
                    //last warning
                    if (MessageBox.Show(resources.GetString("Continue_Warning_Write") +
                                      Environment.NewLine +
                                      resources.GetString("Continue_Question")
                                      , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {

                        //declare a WriteRequest object and
                        //set the request parameters
                        WriteDataRequest myWriteRequest = new WriteDataRequest((eRegion)cmbRegion.SelectedValue,   //Region
                                                                                int.Parse(txtDB.Text),             //DB / only for datablock operations otherwise 0
                                                                                int.Parse(txtWriteAddress.Text),   //write start adress
                                                                                byte.Parse(txtBit.Text),//Bit / only for bit opertions
                                                                                Encoding.GetEncoding((string)cmbCodepage.SelectedItem));//Optionally the Encoding for eventual string operations         


                        //add writable data to request
                        foreach (object writevalue in vtw.values)
                        {
                            switch ((eDataType)cmbDataType.SelectedItem)
                            {
                                case eDataType.BIT:
                                    myWriteRequest.AddBitToBuffer((bool)writevalue);
                                    break;
                                case eDataType.BYTE:
                                    myWriteRequest.AddByteToBuffer((byte)writevalue);
                                    break;
                                case eDataType.INT:
                                    myWriteRequest.AddIntToBuffer((short)writevalue);
                                    break;
                                case eDataType.DINT:
                                    myWriteRequest.AddDIntToBuffer((int)writevalue);
                                    break;
                                case eDataType.LINT:
                                    myWriteRequest.AddLIntToBuffer((long)writevalue);
                                    break;
                                case eDataType.WORD:
                                    myWriteRequest.AddWordToBuffer((ushort)writevalue);
                                    break;
                                case eDataType.DWORD:
                                    myWriteRequest.AddDWordToBuffer((uint)writevalue);
                                    break;
                                case eDataType.LWORD:
                                    myWriteRequest.AddLWordToBuffer((ulong)writevalue);
                                    break;
                                case eDataType.REAL:
                                    myWriteRequest.AddRealToBuffer((float)writevalue);
                                    break;
                                case eDataType.LREAL:
                                    myWriteRequest.AddLRealToBuffer((double)writevalue);
                                    break;
                                case eDataType.RAWDATA:
                                    myWriteRequest.AddByteToBuffer((byte)writevalue);
                                    break;
                                case eDataType.BCD8:
                                    myWriteRequest.AddBcd8ToBuffer((byte)writevalue);
                                    break;
                                case eDataType.BCD16:
                                    myWriteRequest.AddBcd16ToBuffer((short)writevalue);
                                    break;
                                case eDataType.BCD32:
                                    myWriteRequest.AddBcd32ToBuffer((int)writevalue);
                                    break;
                                case eDataType.BCD64:
                                    myWriteRequest.AddBcd64ToBuffer((long)writevalue);
                                    break;
                                case eDataType.DATETIME:
                                case eDataType.DATE_AND_TIME:
                                    myWriteRequest.AddDateAndTimeToBuffer((DateTime)writevalue);
                                    break;

                                case eDataType.DTL:
                                    myWriteRequest.AddLDtlToBuffer((DateTime64)writevalue);
                                    break;



                                case eDataType.LDATE_AND_TIME:
                                    myWriteRequest.AddLDateAndTimeToBuffer((DateTime64)writevalue);
                                    break;

                                case eDataType.S5TIME:
                                    myWriteRequest.AddS5TimeToBuffer((TimeSpan)writevalue);
                                    break;
                                case eDataType.STRING:
                                    myWriteRequest.AddStringToBuffer((string)writevalue);
                                    break;
                                case eDataType.S7_STRING:
                                    myWriteRequest.AddS7StringToBuffer((string)writevalue);
                                    break;
                                case eDataType.S7_WSTRING:
                                    myWriteRequest.AddS7WStringToBuffer((string)writevalue);
                                    break;
                                case eDataType.TIME_OF_DAY:
                                    myWriteRequest.AddTimeOfDayToBuffer((TimeSpan)writevalue);
                                    break;

                                case eDataType.LTIME_OF_DAY:
                                    myWriteRequest.AddLTimeOfDayToBuffer((TimeSpan64)writevalue);
                                    break;

                                case eDataType.DATE:
                                    myWriteRequest.AddDateToBuffer((DateTime)writevalue);
                                    break;
                                case eDataType.TIME:
                                    myWriteRequest.AddTimeToBuffer((TimeSpan)writevalue);
                                    break;

                                case eDataType.LTIME:
                                    myWriteRequest.AddLTimeToBuffer((TimeSpan64)writevalue);
                                    break;

                                default:
                                    //abort message
                                    MessageBox.Show(resources.GetString("wrong_datatype") + " " + resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                            }
                        }

                        //write
                        WriteDataResult res = Device.WriteData(myWriteRequest);

                        //starting evaluate results
                        //set diagnostic output
                        lvLog.Items.Clear();
                        ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                        lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                        lvLog.Items.Add(lvi);
                        foreach (LogEntry le in res.GetDiagnosticLog())
                        {
                            lvi = new ListViewItem(le.ToString());
                            lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                            lvLog.Items.Add(lvi);
                        }

                    }
                    else
                    {
                        //abort message
                        MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //parse error message
                    lvLog.Items.Clear();
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " " + resources.GetString("ParseError"));
                    lvi.ForeColor = Color.Red;
                    lvLog.Items.Add(lvi);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void chkSingleValue_CheckedChanged(object sender, EventArgs e)
        {
            //switch between txtMultipleValues and txtSingleValues
            if ((eDataType)cmbDataType.SelectedItem == eDataType.BIT)
            {
                txtSingleValues.Visible = false;
                rbOn.Visible = chkSingleValue.Checked;
                rbOff.Visible = chkSingleValue.Checked;
                txtMultipleBoolValues.Visible = !chkSingleValue.Checked;
                txtMultipleNumericValues.Visible = false;
                ValuetoWrite = chkSingleValue.Checked ? rbOn.Checked.ToString() : txtMultipleBoolValues.Text;
            }
            else
            {
                txtSingleValues.Visible = chkSingleValue.Checked;
                rbOn.Visible = false;
                rbOff.Visible = false;
                txtMultipleNumericValues.Visible = !chkSingleValue.Checked;
                txtMultipleBoolValues.Visible = false;
                ValuetoWrite = chkSingleValue.Checked ? txtSingleValues.Text : txtMultipleNumericValues.Text;
            }
            lblEnterValues.Visible = true;
            this.lblEnterValues.Text = chkSingleValue.Checked ?
                                        resources.GetString("lblValues_Text") :
                                        resources.GetString("lblMultipleValues_Text");


        }

        private void txtMultipleNumericValues_TextChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = txtMultipleNumericValues.Text;
        }

        private void txtMultipleBoolValues_TextChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = txtMultipleBoolValues.Text;
        }


        private void txtSingleValues_TextChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = txtSingleValues.Text;
        }

        private void rbOff_CheckedChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = rbOn.Checked.ToString();
        }

        private void rbOn_CheckedChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = rbOn.Checked.ToString();
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

        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((eDataType)cmbDataType.SelectedItem == eDataType.BIT)
            {
                txtSingleValues.Visible = false;
                rbOn.Visible = chkSingleValue.Checked;
                rbOff.Visible = chkSingleValue.Checked;
                txtMultipleBoolValues.Visible = !chkSingleValue.Checked;
                txtMultipleNumericValues.Visible = false;
                ValuetoWrite = chkSingleValue.Checked ? rbOn.Checked.ToString() : txtMultipleBoolValues.Text;
                txtBit.Enabled = true;
            }
            else
            {
                txtSingleValues.Visible = chkSingleValue.Checked;
                rbOn.Visible = false;
                rbOff.Visible = false;
                txtMultipleNumericValues.Visible = !chkSingleValue.Checked;
                txtMultipleBoolValues.Visible = false;
                ValuetoWrite = chkSingleValue.Checked ? txtSingleValues.Text : txtMultipleNumericValues.Text;
                txtBit.Enabled = false;
            }

            cmbCodepage.Enabled = cmbDataType.SelectedItem.Equals(eDataType.STRING) || cmbDataType.SelectedItem.Equals(eDataType.S7_STRING);

            if (((eDataType)cmbDataType.SelectedItem).Equals(eDataType.STRING)
                    || ((eDataType)cmbDataType.SelectedItem).Equals(eDataType.S7_STRING))
            {
                this.txtFactor.Enabled = true;
                this.lblFactor.Enabled = true;
            }
            else
            {
                this.txtFactor.Enabled = false;
                this.lblFactor.Enabled = false;
                this.cmbCodepage.SelectedItem = "us-ascii";
            }

            lblEnterValues.Visible = true;
            this.lblEnterValues.Text = chkSingleValue.Checked ?
                                        resources.GetString("lblValues_Text") :
                                        resources.GetString("lblMultipleValues_Text");
        }

        private void ReadWriteBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
        }

        private void rbRead_CheckedChanged(object sender, EventArgs e)
        {
            //enable or diable input fields
            grbWriteValues.Enabled = !rbRead.Checked;
            lvValues.Enabled = rbRead.Checked;
            txtQuantity.Enabled = rbRead.Checked;
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enable or diable DB field 
            txtDB.Enabled = ((eRegion)cmbRegion.SelectedItem).Equals(eRegion.DataBlock);
        }

        private void cmbCodepage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtFactor.Text = Encoding.GetEncoding((string)cmbCodepage.SelectedItem).GetBytes("0").Length.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


    }
}
