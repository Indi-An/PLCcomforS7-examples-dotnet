using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using PLCcom;
using PLCcom.Core.S7Plus.DataTypes;

namespace PLCCom_Full_Test_App.Classic
{
    /// <summary>
    /// Input dialog for creating and configuring a ReadDataRequest or WriteDataRequest.
    /// Supports all S7 data types, regions, and options for single/multiple values.
    /// </summary>
    public partial class CreateRequestInputBox : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRequestInputBox"/> class.
        /// </summary>
        /// <param name="withWriteOption">If true, enables write operation UI.</param>
        public CreateRequestInputBox(bool withWriteOption)
        {
            // Set resources
            this.withWriteOption = withWriteOption;
            resources = new System.Resources.ResourceManager("PLCCom_Example_CSharp.Properties.Resources", this.GetType().Assembly);
            InitializeComponent();
        }

        #region Private Member

        /// <summary>
        /// Resource manager for localized strings.
        /// </summary>
        private System.Resources.ResourceManager resources;

        /// <summary>
        /// The value to write, as string, for WriteDataRequest.
        /// </summary>
        private string ValuetoWrite = string.Empty;

        /// <summary>
        /// Indicates whether control initialization is still in progress.
        /// </summary>
        private bool InitInProgress = false;

        /// <summary>
        /// Determines if write operation is enabled in this dialog.
        /// </summary>
        private bool withWriteOption = true;

        #endregion

        #region internal member

        /// <summary>
        /// The result request item (ReadDataRequest or WriteDataRequest), set after configuration.
        /// </summary>
        internal object RequestItem = null;

        #endregion

        /// <summary>
        /// Loads control values, initializes combo boxes, sets resource strings and UI logic.
        /// </summary>
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

                // Set the codepage (encoding) combobox
                List<String> lisEncodings = new List<String>();
                foreach (EncodingInfo ei in Encoding.GetEncodings())
                {
                    lisEncodings.Add(ei.Name);
                }
                cmbCodepage.DataSource = lisEncodings;
                cmbCodepage.SelectedItem = "us-ascii";

                rbWrite.Enabled = this.withWriteOption;

                // Set resource-based UI labels
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
                this.chkAllowMultipleBits.Text = resources.GetString("chkAllowMultipleBits_Text");
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

        /// <summary>
        /// Updates the request item according to current UI input and mode.
        /// </summary>
        private void CreateRequest()
        {
            // If controls are initializing, do nothing yet
            if (InitInProgress)
                return;

            switch (rbRead.Checked)
            {
                case true:
                    // Create and set read request
                    CreateReadRequest();
                    break;
                case false:
                    // Create and set write request
                    CreateWriteRequest();
                    break;
            }
            txtResult.Text = this.RequestItem.ToString();
        }

        /// <summary>
        /// Creates and sets a ReadDataRequest from current UI values.
        /// </summary>
        private void CreateReadRequest()
        {
            try
            {
                // Construct ReadDataRequest from current parameters
                ReadDataRequest readDataRequest = new ReadDataRequest(
                    (eRegion)cmbRegion.SelectedValue,         // Region
                    int.Parse(txtDB.Text),                    // DB number (for DataBlock), 0 otherwise
                    int.Parse(txtReadAddress.Text),           // Read start address
                    (eDataType)cmbDataType.SelectedValue,     // Data type
                    int.Parse(txtQuantity.Text) * int.Parse(txtFactor.Text), // Quantity
                    byte.Parse(txtBit.Text),                  // Bit index (for bit ops)
                    Encoding.GetEncoding((string)cmbCodepage.SelectedItem) // Optional encoding
                );

                this.RequestItem = readDataRequest;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Creates and sets a WriteDataRequest from current UI values and input text.
        /// </summary>
        private void CreateWriteRequest()
        {
            try
            {
                // Parse the value string and add writable data
                Utilities.sValues_to_Write vtw = null;
                vtw = Utilities.CheckValues(ValuetoWrite, (eDataType)cmbDataType.SelectedItem);

                if (!vtw.ParseError)
                {
                    // Create WriteDataRequest from current parameters
                    WriteDataRequest writeRequest = new WriteDataRequest(
                        (eRegion)cmbRegion.SelectedValue,       // Region
                        int.Parse(txtDB.Text),                  // DB number (for DataBlock), 0 otherwise
                        int.Parse(txtWriteAddress.Text),        // Write start address
                        byte.Parse(txtBit.Text),                // Bit index (for bit ops)
                        Encoding.GetEncoding((string)cmbCodepage.SelectedItem) // Optional encoding
                    );

                    // Enable or disable multiple write bit mode
                    writeRequest.AllowMultipleBits = chkAllowMultipleBits.Enabled && chkAllowMultipleBits.Checked;

                    // Add each parsed value to the buffer, using correct method for data type
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
                                // Abort on unsupported data type
                                MessageBox.Show(resources.GetString("wrong_datatype"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    }
                    this.RequestItem = writeRequest;
                }
                else
                {
                    // Parse error: show message and do not update request
                    MessageBox.Show(resources.GetString("ParseError"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles switching between single and multiple value input fields.
        /// </summary>
        private void chkSingleValue_CheckedChanged(object sender, EventArgs e)
        {
            // Switch between input controls depending on datatype and single/multi-value selection
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

        /// <summary>
        /// Handles changes in the multiple numeric value input box.
        /// </summary>
        private void txtMultipleNumericValues_TextChanged(object sender, EventArgs e)
        {
            ValuetoWrite = txtMultipleNumericValues.Text;
            CreateRequest();
        }

        /// <summary>
        /// Handles changes in the multiple boolean value input box.
        /// </summary>
        private void txtMultipleBoolValues_TextChanged(object sender, EventArgs e)
        {
            ValuetoWrite = txtMultipleBoolValues.Text;
            CreateRequest();
        }

        /// <summary>
        /// Handles changes in the single value input box.
        /// </summary>
        private void txtSingleValues_TextChanged(object sender, EventArgs e)
        {
            ValuetoWrite = txtSingleValues.Text;
            CreateRequest();
        }

        /// <summary>
        /// Handles the "Off" radio button for boolean values.
        /// </summary>
        private void rbOff_CheckedChanged(object sender, EventArgs e)
        {
            ValuetoWrite = rbOn.Checked.ToString();
            CreateRequest();
        }

        /// <summary>
        /// Handles the "On" radio button for boolean values.
        /// </summary>
        private void rbOn_CheckedChanged(object sender, EventArgs e)
        {
            ValuetoWrite = rbOn.Checked.ToString();
            CreateRequest();
        }

        /// <summary>
        /// Handles selection change of data type. Updates all dependent UI and options.
        /// </summary>
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

        /// <summary>
        /// Handles switching between read and write mode. Updates all related controls and calls CreateRequest.
        /// </summary>
        private void rbRead_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable input fields according to selected operation
            grbWriteValues.Enabled = !rbRead.Checked;
            txtQuantity.Enabled = rbRead.Checked;
            rbRead.FlatStyle = rbRead.Checked ? FlatStyle.Flat : FlatStyle.Standard;
            rbWrite.FlatStyle = rbWrite.Checked ? FlatStyle.Flat : FlatStyle.Standard;
            CreateRequest();
        }

        /// <summary>
        /// Handles region selection. Enables/disables the DB field accordingly.
        /// </summary>
        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDB.Enabled = ((eRegion)cmbRegion.SelectedItem).Equals(eRegion.DataBlock);
            CreateRequest();
        }

        /// <summary>
        /// Handles codepage selection change and updates factor textbox accordingly.
        /// </summary>
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

        // All following handlers simply call CreateRequest() on relevant input change:

        private void txtDB_TextChanged(object sender, EventArgs e) => CreateRequest();
        private void txtReadAddress_TextChanged(object sender, EventArgs e) => CreateRequest();
        private void txtWriteAddress_TextChanged(object sender, EventArgs e) => CreateRequest();
        private void txtBit_TextChanged(object sender, EventArgs e) => CreateRequest();
        private void txtQuantity_TextChanged(object sender, EventArgs e) => CreateRequest();
        private void txtFactor_TextChanged(object sender, EventArgs e) => CreateRequest();

        /// <summary>
        /// Handles multiple bits checkbox. Shows warning and enables/disables relevant UI.
        /// </summary>
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

        /// <summary>
        /// Accepts the dialog and returns the configured request.
        /// </summary>
        private void btnAcceptRequest_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Aborts the dialog and discards the configured request.
        /// </summary>
        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
