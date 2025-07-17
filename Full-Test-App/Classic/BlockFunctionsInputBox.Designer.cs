namespace PLCCom_Full_Test_App.Classic
{
    partial class BlockFunctionsInputBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbBlockType = new System.Windows.Forms.ComboBox();
            this.lblBlockType = new System.Windows.Forms.Label();
            this.txtBlockNumber = new System.Windows.Forms.TextBox();
            this.lblBlockNumber = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtEnterPW = new System.Windows.Forms.TextBox();
            this.lblPW = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbBlockType
            // 
            this.cmbBlockType.FormattingEnabled = true;
            this.cmbBlockType.Location = new System.Drawing.Point(104, 14);
            this.cmbBlockType.Name = "cmbBlockType";
            this.cmbBlockType.Size = new System.Drawing.Size(102, 21);
            this.cmbBlockType.TabIndex = 60;
            // 
            // lblBlockType
            // 
            this.lblBlockType.AutoSize = true;
            this.lblBlockType.Location = new System.Drawing.Point(25, 14);
            this.lblBlockType.Name = "lblBlockType";
            this.lblBlockType.Size = new System.Drawing.Size(73, 13);
            this.lblBlockType.TabIndex = 61;
            this.lblBlockType.Text = "Type of Block";
            // 
            // txtBlockNumber
            // 
            this.txtBlockNumber.Location = new System.Drawing.Point(104, 44);
            this.txtBlockNumber.Name = "txtBlockNumber";
            this.txtBlockNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBlockNumber.Size = new System.Drawing.Size(102, 20);
            this.txtBlockNumber.TabIndex = 62;
            this.txtBlockNumber.Text = "1";
            // 
            // lblBlockNumber
            // 
            this.lblBlockNumber.AutoSize = true;
            this.lblBlockNumber.Location = new System.Drawing.Point(12, 47);
            this.lblBlockNumber.Name = "lblBlockNumber";
            this.lblBlockNumber.Size = new System.Drawing.Size(86, 13);
            this.lblBlockNumber.TabIndex = 63;
            this.lblBlockNumber.Text = "Number of Block";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(131, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 64;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtEnterPW
            // 
            this.txtEnterPW.Location = new System.Drawing.Point(104, 72);
            this.txtEnterPW.Name = "txtEnterPW";
            this.txtEnterPW.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEnterPW.Size = new System.Drawing.Size(102, 20);
            this.txtEnterPW.TabIndex = 65;
            // 
            // lblPW
            // 
            this.lblPW.AutoSize = true;
            this.lblPW.Location = new System.Drawing.Point(12, 75);
            this.lblPW.Name = "lblPW";
            this.lblPW.Size = new System.Drawing.Size(81, 13);
            this.lblPW.TabIndex = 66;
            this.lblPW.Text = "Enter Password";
            // 
            // BlockFunctionsInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 138);
            this.ControlBox = false;
            this.Controls.Add(this.txtEnterPW);
            this.Controls.Add(this.lblPW);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbBlockType);
            this.Controls.Add(this.lblBlockType);
            this.Controls.Add(this.txtBlockNumber);
            this.Controls.Add(this.lblBlockNumber);
            this.Name = "BlockFunctionsInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inputbox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbBlockType;
        internal System.Windows.Forms.Label lblBlockType;
        internal System.Windows.Forms.TextBox txtBlockNumber;
        internal System.Windows.Forms.Label lblBlockNumber;
        private System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.TextBox txtEnterPW;
        internal System.Windows.Forms.Label lblPW;
    }
}