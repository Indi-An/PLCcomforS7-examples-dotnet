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
    /// Dialog for entering block function parameters (block type, block number, or password) for PLC operations.
    /// </summary>
    public partial class BlockFunctionsInputBox : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockFunctionsInputBox"/> class.
        /// </summary>
        internal BlockFunctionsInputBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows dialog for selecting only a block type.
        /// </summary>
        /// <param name="BlockType">The block type selected by the user.</param>
        /// <param name="FocusAllBlock">If true, focus on "AllBlocks"; otherwise focus on "DB".</param>
        internal void ShowBlockFunctionsInputBox(out eBlockType BlockType, bool FocusAllBlock)
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
            BlockType = (eBlockType)cmbBlockType.SelectedItem;
        }

        /// <summary>
        /// Shows dialog for selecting block type and block number.
        /// </summary>
        /// <param name="BlockType">The block type selected by the user.</param>
        /// <param name="Number">The block number entered by the user.</param>
        /// <param name="FocusAllBlock">If true, focus on "AllBlocks"; otherwise focus on "DB".</param>
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

        /// <summary>
        /// Shows dialog for entering only a password, disables other controls.
        /// </summary>
        /// <param name="PW">The password entered by the user.</param>
        internal void ShowBlockFunctionsInputBox(out string PW)
        {
            cmbBlockType.DataSource = Enum.GetValues(typeof(eBlockType));
            txtBlockNumber.Enabled = false;
            cmbBlockType.Enabled = false;
            txtEnterPW.Enabled = true;
            this.ShowDialog();
            PW = txtEnterPW.Text;
        }

        /// <summary>
        /// Handles OK button click: closes the dialog.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
