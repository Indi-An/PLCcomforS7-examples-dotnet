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
    public partial class BlockFunctionsInputBox : Form
    {
        internal BlockFunctionsInputBox()
        {
            InitializeComponent();
        }

        internal void ShowBlockFunctionsInputBox(out eBlockType BlockType,bool FocusAllBlock)
        {
            cmbBlockType.DataSource = Enum.GetValues(typeof(eBlockType));
            if (FocusAllBlock)
            {
                cmbBlockType.Text = eBlockType.AllBlocks.ToString();
            }
            else
            {
                cmbBlockType.Text = eBlockType.DB.ToString();
            }
            txtBlockNumber.Enabled = false;
            cmbBlockType.Enabled = true;
            txtEnterPW.Enabled = false;
            this.ShowDialog();
            BlockType = (eBlockType) cmbBlockType.SelectedItem;
        }

        internal void ShowBlockFunctionsInputBox(out eBlockType BlockType, out int Number, bool FocusAllBlock)
        {
            cmbBlockType.DataSource = Enum.GetValues(typeof(eBlockType));
            if (FocusAllBlock)
            {
                cmbBlockType.Text = eBlockType.AllBlocks.ToString();
            }
            else
            {
                cmbBlockType.Text = eBlockType.DB.ToString();
            }
            txtBlockNumber.Enabled = true;
            cmbBlockType.Enabled = true;
            txtEnterPW.Enabled = false;
            this.ShowDialog();
            BlockType = (eBlockType)cmbBlockType.SelectedItem;
            Number = int.Parse(txtBlockNumber.Text);
        }

        internal void ShowBlockFunctionsInputBox(out string PW)
        {
            cmbBlockType.DataSource = Enum.GetValues(typeof(eBlockType));
            txtBlockNumber.Enabled = false;
            cmbBlockType.Enabled = false;
            txtEnterPW.Enabled = true;
            this.ShowDialog();
            PW = txtEnterPW.Text;
        }
       
        private void btnOK_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void BlockFunctionsInputBox_Load(object sender, EventArgs e)
        {

        }
    }
}
