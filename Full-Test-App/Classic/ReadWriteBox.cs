using PLCcom;
using PLCcom.Core.S7Plus.DataTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLCCom_Full_Test_App.Classic
{
    /// <summary>
    /// Form for reading and writing data to a PLC device.
    /// </summary>
    public partial class ReadWriteBox : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadWriteBox"/> class.
        /// </summary>
        /// <param name="mDevice">The PLCcomDevice to communicate with.</param>
        public ReadWriteBox(PLCcomDevice mDevice)
        {
            // Set resources
            resources = new System.Resources.ResourceManager(
                this.GetType().Assembly.GetName().Name + ".Properties.Resources",
                this.GetType().Assembly
            );
            
            InitializeComponent();
            this.Device = mDevice;
        }

        #region Private Member

        /// <summary>
        /// The PLC device instance for communication.
        /// </summary>
        private PLCcomDevice Device;

        /// <summary>
        /// Resource manager for localized strings.
        /// </summary>
        private System.Resources.ResourceManager resources;

        /// <summary>
        /// Value to write to the PLC, as string.
        /// </summary>
        private string ValuetoWrite = string.Empty;
        #endregion

        /// <summary>
        /// Handles the Load event of the ReadWriteBox form.
        /// Initializes UI controls and resources.
        /// </summary>
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

                // Set the culture/codepage combobox
                List<String> lisEncodings = new List<String>();
                foreach (EncodingInfo ei in Encoding.GetEncodings())
                {
                    lisEncodings.Add(ei.Name);
                }
                cmbCodepage.DataSource = lisEncodings;
                cmbCodepage.SelectedItem = "us-ascii";

                // Set UI texts from resources
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

        /// <summary>
        /// Handles the Click event of the Close button.
        /// Closes the dialog.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the Execute button.
        /// Executes either the read or write operation.
        /// </summary>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                switch (rbRead.Checked)
                {
                    case true:
                        // Execute read operation
                        ExecRead();
                        break;
                    case false:
                        // Execute write operation
                        ExecWrite();
                        break;
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Performs the read operation from the PLC and displays results and logs.
        /// </summary>
        private void ExecRead()
        {
            try
            {
                Device.Connecttimeout = 5000;
                Device.Readtimeout = 5000;
                // Declare a ReadDataRequest object and set the request parameters
                ReadDataRequest myReadDataRequest = new ReadDataRequest(
                    (eRegion)cmbRegion.SelectedValue,          // Region
                    int.Parse(txtDB.Text),                    // DB (for datablock operations), otherwise 0
                    int.Parse(txtReadAddress.Text),           // Read start address
                    (eDataType)cmbDataType.SelectedValue,     // Desired data type
                    int.Parse(txtQuantity.Text) * int.Parse(txtFactor.Text), // Quantity of reading values
                    byte.Parse(txtBit.Text),                  // Bit (for bit operations)
                    Encoding.GetEncoding((string)cmbCodepage.SelectedItem)); // Encoding for string operations

                Stopwatch plcExecutionTimer = Stopwatch.StartNew();

                // Read from device
                ReadDataResult res = Device.ReadData(myReadDataRequest);

                plcExecutionTimer.Stop();

                lvValues.Items.Clear();
                lvLog.Items.Clear();

                // Start evaluating results and set diagnostic output
                lvLog.BeginUpdate();

                ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Summary: " + res.ToString());
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);

                if (res.Quality == OperationResult.eQuality.GOOD)
                {
                    lvi = new ListViewItem(DateTime.Now.ToString() + $" Plc Access Done! Plc Execution Time: {plcExecutionTimer.ElapsedMilliseconds} ms. Start loading results in listview...");
                    lvi.ForeColor = Color.Blue;
                    lvLog.Items.Add(lvi);
                }

                lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
                lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);

                foreach (LogEntry le in res.GetDiagnosticLog())
                {
                    lvi = new ListViewItem(le.ToString());
                    lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                }

                lvLog.EndUpdate();
                lvLog.Refresh();

                // Evaluate values
                lvValues.BeginUpdate();
                lvValues.Columns[1].Text = "Position";
                if (res.Quality == OperationResult.eQuality.GOOD)
                {
                    int Position = 0;
                    var resultValues = res.GetValues();

                    var itemsList = new List<ListViewItem>();

                    foreach (var value in resultValues)
                    {
                        lvi = new ListViewItem();
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, Position++.ToString()));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, value.ToString()));
                        lvi.ForeColor = (value is bool && (bool)value == true ? Color.Blue : Color.Black);
                        lvi.ForeColor = (value is bool && (bool)value == true ? Color.Blue : Color.Black);
                        itemsList.Add(lvi);
                    }

                    lvValues.Items.AddRange(itemsList.ToArray());
                }
                lvValues.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Performs the write operation to the PLC.
        /// </summary>
        private void ExecWrite()
        {
            try
            {
                // Parse value string and add writable data here
                Utilities.sValues_to_Write vtw = null;
                vtw = Utilities.CheckValues(ValuetoWrite, (eDataType)cmbDataType.SelectedItem);

                if (!vtw.ParseError)
                {
                    // Last warning before write
                    if (MessageBox.Show(resources.GetString("Continue_Warning_Write") +
                                      Environment.NewLine +
                                      resources.GetString("Continue_Question")
                                      , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Declare a WriteRequest object and set the request parameters
                        WriteDataRequest myWriteRequest = new WriteDataRequest(
                            (eRegion)cmbRegion.SelectedValue,    // Region
                            int.Parse(txtDB.Text),               // DB (for datablock operations), otherwise 0
                            int.Parse(txtWriteAddress.Text),     // Write start address
                            byte.Parse(txtBit.Text),             // Bit (for bit operations)
                            Encoding.GetEncoding((string)cmbCodepage.SelectedItem)); // Encoding for string operations

                        //allow writing multliple bits 
                        //Important hint: If multiple bits are present, this WriteRequest can not be processed optimally.
                        //All bits are written one after the other.
                        //It is better and more efficient if a separate WriteRequest is used for each bit.
                        myWriteRequest.AllowMultipleBits = true;

                        // Add writable data to request
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
                                    // Abort on wrong data type
                                    MessageBox.Show(resources.GetString("wrong_datatype") + " " + resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                            }
                        }

                        // Write data to PLC
                        WriteDataResult res = Device.WriteData(myWriteRequest);

                        // Evaluate results and show diagnostic output
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
                        // Write operation aborted by user
                        MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Value parsing error
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

        /// <summary>
        /// Handles the CheckedChanged event for chkSingleValue.
        /// Switches between single value and multiple values input controls.
        /// </summary>
        private void chkSingleValue_CheckedChanged(object sender, EventArgs e)
        {
            // Switch between txtMultipleValues and txtSingleValues
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

        /// <summary>
        /// Handles the TextChanged event for txtMultipleNumericValues.
        /// Sets the writable string value.
        /// </summary>
        private void txtMultipleNumericValues_TextChanged(object sender, EventArgs e)
        {
            // Set writable string
            ValuetoWrite = txtMultipleNumericValues.Text;
        }

        /// <summary>
        /// Handles the TextChanged event for txtMultipleBoolValues.
        /// Sets the writable string value.
        /// </summary>
        private void txtMultipleBoolValues_TextChanged(object sender, EventArgs e)
        {
            // Set writable string
            ValuetoWrite = txtMultipleBoolValues.Text;
        }

        /// <summary>
        /// Handles the TextChanged event for txtSingleValues.
        /// Sets the writable string value.
        /// </summary>
        private void txtSingleValues_TextChanged(object sender, EventArgs e)
        {
            // Set writable string
            ValuetoWrite = txtSingleValues.Text;
        }

        /// <summary>
        /// Handles the CheckedChanged event for rbOff.
        /// Sets the writable string value.
        /// </summary>
        private void rbOff_CheckedChanged(object sender, EventArgs e)
        {
            // Set writable string
            ValuetoWrite = rbOn.Checked.ToString();
        }

        /// <summary>
        /// Handles the CheckedChanged event for rbOn.
        /// Sets the writable string value.
        /// </summary>
        private void rbOn_CheckedChanged(object sender, EventArgs e)
        {
            // Set writable string
            ValuetoWrite = rbOn.Checked.ToString();
        }

        /// <summary>
        /// Handles the Click event for btnSaveLogtoClipboard.
        /// Copies the diagnostic log to the clipboard.
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
        /// Handles the Click event for btnSaveLogtoFile.
        /// Saves the diagnostic log to a file.
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
        /// Handles the SelectedIndexChanged event for cmbDataType.
        /// Adjusts UI input controls depending on the data type selection.
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

        /// <summary>
        /// Handles the FormClosing event for ReadWriteBox.
        /// Decrements the open dialog counter in Main.
        /// </summary>
        private void ReadWriteBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.CountOpenDialogs--;
        }

        /// <summary>
        /// Handles the CheckedChanged event for rbRead.
        /// Enables or disables input fields depending on read or write mode.
        /// </summary>
        private void rbRead_CheckedChanged(object sender, EventArgs e)
        {
            // Enable or disable input fields
            grbWriteValues.Enabled = !rbRead.Checked;
            lvValues.Enabled = rbRead.Checked;
            txtQuantity.Enabled = rbRead.Checked;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event for cmbRegion.
        /// Enables or disables the DB field based on selected region.
        /// </summary>
        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable or disable DB field 
            txtDB.Enabled = ((eRegion)cmbRegion.SelectedItem).Equals(eRegion.DataBlock);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event for cmbCodepage.
        /// Updates the factor text field depending on the codepage's byte length.
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
        }
    }
}
