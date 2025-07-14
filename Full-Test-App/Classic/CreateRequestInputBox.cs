using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using PLCcom;
using PLCcom.Core.S7Plus.DataTypes;

namespace PLCCom_Full_Test_App.Classic
{
    public partial class CreateRequestInputBox : Form
    {

        public CreateRequestInputBox(bool withWriteOption)
        {
            //set ressources
            this.withWriteOption = withWriteOption;
            resources = new System.Resources.ResourceManager("PLCCom_Full_Test_App.Properties.Resources", this.GetType().Assembly);
            InitializeComponent();
        }

        #region Private Member
        private System.Resources.ResourceManager resources;
        private string ValuetoWrite = string.Empty;
        private bool InitInProgress = false;
        private bool withWriteOption = true;
        #endregion

        #region internal member
        internal object RequestItem = null;
        #endregion

        private void CreateRequest_Load(object sender, EventArgs e)
        {
            try
            {
                InitInProgress = true;
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

                rbWrite.Enabled = this.withWriteOption;

                this.grpAddress.Text = resources.GetString("grpAddress_Text");
                this.lblDataType.Text = resources.GetString("lblDataType_Text");
                this.lblReadAdress.Text = resources.GetString("lblReadAddress_Text");
                this.lblWriteAddress.Text = resources.GetString("lblWriteAddress_Text");
                this.lblBit.Text = resources.GetString("lblBit_Text");
                this.lblLength.Text = resources.GetString("lblLength_Text");
                this.btnAcceptRequest.Text = resources.GetString("btnAcceptRequest_Text");
                this.btnAbort.Text = resources.GetString("btnAbort_Text");
                this.txtInfoRequest.Text = resources.GetString("txtInfoRequest_Text");
                this.chkSingleValue.Text = resources.GetString("chkSingleValue_Text");
                this.lblEnterValues.Text = resources.GetString("lblValues_Text");
                this.lblRegion.Text = resources.GetString("lblRegion_Text");
                this.lblMode.Text = resources.GetString("lblMode_Text");
                this.rbRead.Text = resources.GetString("read");
                this.rbWrite.Text = resources.GetString("write");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                InitInProgress = false;
                CreateRequest();
            }
        }




        private void CreateRequest()
        {
            //initialization in progress
            if (InitInProgress)
                return;

            switch (rbRead.Checked)
            {
                case true:
                    //create read request
                    CreateReadRequest();
                    break;
                case false:
                    //create write request
                    CreateWriteRequest();
                    break;
            }
            txtResult.Text = this.RequestItem.ToString();
        }

        private void CreateReadRequest()
        {
            try
            {
                //declare a ReadDataRequest object and
                //set the request parameters
                ReadDataRequest readDataRequest = new ReadDataRequest((eRegion)cmbRegion.SelectedValue,   //Region
                                                                       int.Parse(txtDB.Text),             //DB / only for datablock operations otherwise 0
                                                                       int.Parse(txtReadAddress.Text),      //read start address
                                                                       (eDataType)cmbDataType.SelectedValue,//desired datatype
                                                                       int.Parse(txtQuantity.Text) * int.Parse(txtFactor.Text), //Quantity of reading values
                                                                       byte.Parse(txtBit.Text),//Bit / only for bit opertions
                                                                       Encoding.GetEncoding((string)cmbCodepage.SelectedItem)); //Optionally the Encoding for eventual string operations        

                this.RequestItem = readDataRequest;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void CreateWriteRequest()
        {
            try
            {
                //parse valuestring and add writable Data here
                Utilities.sValues_to_Write vtw = null;
                vtw = Utilities.CheckValues(ValuetoWrite, (eDataType)cmbDataType.SelectedItem);

                if (!vtw.ParseError)
                {

                    //declare a WriteRequest object and
                    //set the request parameters
                    WriteDataRequest writeRequest = new WriteDataRequest((eRegion)cmbRegion.SelectedValue,   //Region
                                                                            int.Parse(txtDB.Text),             //DB / only for datablock operations otherwise 0
                                                                            int.Parse(txtWriteAddress.Text),   //write start address
                                                                            byte.Parse(txtBit.Text),//Bit / only for bit opertions
                                                                            Encoding.GetEncoding((string)cmbCodepage.SelectedItem));//Optionally the Encoding for eventual string operations 


                    //enable or disable multiple write bit mode
                    writeRequest.AllowMultipleBits = chkAllowMultipleBits.Enabled && chkAllowMultipleBits.Checked;

                    //add writable data to request
                    foreach (object writevalue in vtw.values)
                    {
                        switch ((eDataType)cmbDataType.SelectedItem)
                        {
                            case eDataType.BIT:
                                writeRequest.AddBitToBuffer((bool)writevalue);
                                break;
                            case eDataType.BYTE:
                                writeRequest.AddByteToBuffer((byte)writevalue);
                                break;
                            case eDataType.INT:
                                writeRequest.AddIntToBuffer((short)writevalue);
                                break;
                            case eDataType.DINT:
                                writeRequest.AddDIntToBuffer((int)writevalue);
                                break;
                            case eDataType.LINT:
                                writeRequest.AddLIntToBuffer((long)writevalue);
                                break;
                            case eDataType.WORD:
                                writeRequest.AddWordToBuffer((ushort)writevalue);
                                break;
                            case eDataType.DWORD:
                                writeRequest.AddDWordToBuffer((uint)writevalue);
                                break;
                            case eDataType.LWORD:
                                writeRequest.AddLWordToBuffer((ulong)writevalue);
                                break;
                            case eDataType.REAL:
                                writeRequest.AddRealToBuffer((float)writevalue);
                                break;
                            case eDataType.LREAL:
                                writeRequest.AddLRealToBuffer((double)writevalue);
                                break;
                            case eDataType.RAWDATA:
                                writeRequest.AddByteToBuffer((byte)writevalue);
                                break;
                            case eDataType.BCD8:
                                writeRequest.AddBcd8ToBuffer((byte)writevalue);
                                break;
                            case eDataType.BCD16:
                                writeRequest.AddBcd16ToBuffer((short)writevalue);
                                break;
                            case eDataType.BCD32:
                                writeRequest.AddBcd32ToBuffer((int)writevalue);
                                break;
                            case eDataType.BCD64:
                                writeRequest.AddBcd64ToBuffer((long)writevalue);
                                break;
                            case eDataType.DATETIME:
                            case eDataType.DATE_AND_TIME:
                                writeRequest.AddDateAndTimeToBuffer((DateTime)writevalue);
                                break;
                            case eDataType.DTL:
                                writeRequest.AddLDtlToBuffer((DateTime64)writevalue);
                                break;
                            case eDataType.LDATE_AND_TIME:
                                writeRequest.AddLDateAndTimeToBuffer((DateTime64)writevalue);
                                break;
                            case eDataType.S5TIME:
                                writeRequest.AddS5TimeToBuffer((TimeSpan)writevalue);
                                break;
                            case eDataType.STRING:
                                writeRequest.AddStringToBuffer((string)writevalue);
                                break;
                            case eDataType.S7_STRING:
                                writeRequest.AddS7StringToBuffer((string)writevalue);
                                break;
                            case eDataType.S7_WSTRING:
                                writeRequest.AddS7WStringToBuffer((string)writevalue);
                                break;
                            case eDataType.TIME_OF_DAY:
                                writeRequest.AddTimeOfDayToBuffer((TimeSpan)writevalue);
                                break;
                            case eDataType.LTIME_OF_DAY:
                                writeRequest.AddLTimeOfDayToBuffer((TimeSpan64)writevalue);
                                break;
                            case eDataType.DATE:
                                writeRequest.AddDateToBuffer((DateTime)writevalue);
                                break;
                            case eDataType.TIME:
                                writeRequest.AddTimeToBuffer((TimeSpan)writevalue);
                                break;
                            case eDataType.LTIME:
                                writeRequest.AddLTimeToBuffer((TimeSpan64)writevalue);
                                break;
                            default:
                                //abort message
                                MessageBox.Show(resources.GetString("wrong_datatype"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;

                        }
                    }

                    this.RequestItem = writeRequest;
                }
                else
                {
                    //parse error message
                    MessageBox.Show(resources.GetString("ParseError"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            CreateRequest();
        }

        private void txtMultipleNumericValues_TextChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = txtMultipleNumericValues.Text;
            CreateRequest();
        }

        private void txtMultipleBoolValues_TextChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = txtMultipleBoolValues.Text;
            CreateRequest();
        }


        private void txtSingleValues_TextChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = txtSingleValues.Text;
            CreateRequest();
        }

        private void rbOff_CheckedChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = rbOn.Checked.ToString();
            CreateRequest();
        }

        private void rbOn_CheckedChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = rbOn.Checked.ToString();
            CreateRequest();
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
                chkAllowMultipleBits.Enabled = true;
                if (!chkAllowMultipleBits.Checked)
                {
                    chkSingleValue.Checked = true;
                    chkSingleValue.Enabled = false;
                }
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
                chkAllowMultipleBits.Enabled = false;
                chkSingleValue.Enabled = true;
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
            CreateRequest();
        }

        private void rbRead_CheckedChanged(object sender, EventArgs e)
        {
            //enable or diable input fields
            grbWriteValues.Enabled = !rbRead.Checked;
            txtQuantity.Enabled = rbRead.Checked;
            rbRead.FlatStyle = rbRead.Checked ? FlatStyle.Flat : FlatStyle.Standard;
            rbWrite.FlatStyle = rbWrite.Checked ? FlatStyle.Flat : FlatStyle.Standard;
            CreateRequest();
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enable or diable DB field 
            txtDB.Enabled = ((eRegion)cmbRegion.SelectedItem).Equals(eRegion.DataBlock);
            CreateRequest();
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
            CreateRequest();
        }

        private void txtDB_TextChanged(object sender, EventArgs e)
        {
            CreateRequest();
        }

        private void txtReadAddress_TextChanged(object sender, EventArgs e)
        {
            CreateRequest();
        }

        private void txtWriteAddress_TextChanged(object sender, EventArgs e)
        {
            CreateRequest();
        }

        private void txtBit_TextChanged(object sender, EventArgs e)
        {
            CreateRequest();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CreateRequest();
        }

        private void txtFactor_TextChanged(object sender, EventArgs e)
        {
            CreateRequest();
        }

        private void chkAllowMultipleBits_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowMultipleBits.Checked)
            {
                if (MessageBox.Show(resources.GetString("warning_allow_multiple_bits"), resources.GetString("Important_question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                {
                    chkAllowMultipleBits.Checked = false;
                    return;
                }
                chkSingleValue.Enabled = true;
                chkSingleValue.Checked = false;
            }
            else
            {
                chkSingleValue.Checked = true;
                chkSingleValue.Enabled = false;
            }
        }

        private void btnAcceptRequest_Click(object sender, EventArgs e)
        {
            //close form
            this.DialogResult = DialogResult.OK;
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            //close form and Abort
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
