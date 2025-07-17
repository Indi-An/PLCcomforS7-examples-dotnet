using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PLCcom;

namespace PLCCom_Full_Test_App.Classic
{
    /// <summary>
    /// A form for inputting parameters for various PLC functions,
    /// such as setting the PLC date/time or entering SSL IDs and indexes.
    /// </summary>
    public partial class OtherFunctionsInputBox : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OtherFunctionsInputBox"/> class.
        /// </summary>
        internal OtherFunctionsInputBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the input box for entering or selecting a PLC DateTime value.
        /// Enables only the DateTime picker.
        /// </summary>
        /// <param name="PLCDateTime">The DateTime value set by the user.</param>
        internal void ShowOtherFunctionsInputBox(out DateTime PLCDateTime)
        {
            // Only the date/time picker is enabled for DateTime input.
            this.txtSSL_ID.Enabled = false;
            this.txtSSL_Index.Enabled = false;
            this.dateTimePicker.Enabled = true;
            this.ShowDialog();
            PLCDateTime = dateTimePicker.Value;
        }

        /// <summary>
        /// Shows the input box for entering SSL_ID and SSL_Index integer values.
        /// Enables only the related textboxes.
        /// </summary>
        /// <param name="SSL_ID">The SSL_ID entered by the user.</param>
        /// <param name="SSL_Index">The SSL_Index entered by the user.</param>
        internal void ShowOtherFunctionsInputBox(out int SSL_ID, out int SSL_Index)
        {
            // Only SSL ID and Index textboxes are enabled for input.
            txtSSL_ID.Enabled = true;
            txtSSL_Index.Enabled = true;
            dateTimePicker.Enabled = false;
            this.ShowDialog();
            SSL_ID = int.Parse(txtSSL_ID.Text);
            SSL_Index = int.Parse(txtSSL_Index.Text);
        }

        /// <summary>
        /// Handles the Load event for the form.
        /// Sets the custom format of the DateTimePicker based on current application culture.
        /// </summary>
        private void InputBox_Load(object sender, EventArgs e)
        {
            // Set DateTimePicker's format to current culture's short date and time pattern.
            dateTimePicker.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + Application.CurrentCulture.DateTimeFormat.ShortTimePattern;
        }

        /// <summary>
        /// Handles the Click event for the OK button.
        /// Closes the form.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the TextChanged event for the SSL_ID textbox.
        /// Displays a hexadecimal representation if valid, or marks invalid input.
        /// </summary>
        private void txtSSL_ID_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(txtSSL_ID.Text, out value))
            {
                // Display hex representation of the integer value.
                txtSSL_ID_Hex.Text = String.Format("0x{0:X02}", int.Parse(txtSSL_ID.Text));
                txtSSL_ID_Hex.BackColor = SystemColors.Control;
            }
            else
            {
                // Mark input as invalid with red background.
                txtSSL_ID_Hex.Text = "invalid";
                txtSSL_ID_Hex.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// Handles the TextChanged event for the SSL_Index textbox.
        /// Displays a hexadecimal representation if valid, or marks invalid input.
        /// </summary>
        private void txtSSL_Index_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(txtSSL_Index.Text, out value))
            {
                // Display hex representation of the integer value.
                txtSSL_Index_Hex.Text = String.Format("0x{0:X02}", int.Parse(txtSSL_Index.Text));
                txtSSL_Index_Hex.BackColor = SystemColors.Control;
            }
            else
            {
                // Mark input as invalid with red background.
                txtSSL_Index_Hex.Text = "invalid";
                txtSSL_Index_Hex.BackColor = Color.Red;
            }
        }
    }
}
