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
    public partial class OtherFunctionsInputBox : Form
    {
        internal OtherFunctionsInputBox()
        {
            InitializeComponent();
        }


        internal void ShowOtherFunctionsInputBox(out DateTime PLCDateTime)
        {
            this.txtSSL_ID.Enabled = false;
            this.txtSSL_Index.Enabled = false;
            this.dateTimePicker.Enabled = true;
            this.ShowDialog();
            PLCDateTime = dateTimePicker.Value;
        }

        internal void ShowOtherFunctionsInputBox(out int SSL_ID, out int SSL_Index)
        {
            txtSSL_ID.Enabled = true;
            txtSSL_Index.Enabled = true;
            dateTimePicker.Enabled = false;
            this.ShowDialog();
            SSL_ID = int.Parse(txtSSL_ID.Text);
            SSL_Index = int.Parse(txtSSL_Index.Text);
        }


        private void InputBox_Load(object sender, EventArgs e)
        {
            dateTimePicker.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + Application.CurrentCulture.DateTimeFormat.ShortTimePattern;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSSL_ID_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(txtSSL_ID.Text, out value))
            {
                txtSSL_ID_Hex.Text = String.Format("0x{0:X02}", int.Parse(txtSSL_ID.Text));
                txtSSL_ID_Hex.BackColor = SystemColors.Control;
            }
            else
            {
                txtSSL_ID_Hex.Text = "invalid";
                txtSSL_ID_Hex.BackColor = Color.Red;
            }

        }

        private void txtSSL_Index_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(txtSSL_Index.Text, out value))
            {
                txtSSL_Index_Hex.Text = String.Format("0x{0:X02}", int.Parse(txtSSL_Index.Text));
                txtSSL_Index_Hex.BackColor = SystemColors.Control;
            }
            else
            {
                txtSSL_Index_Hex.Text = "invalid";
                txtSSL_Index_Hex.BackColor = Color.Red;
            }
        }
    }
}
