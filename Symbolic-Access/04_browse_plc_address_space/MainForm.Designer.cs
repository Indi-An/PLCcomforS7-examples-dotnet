namespace BrowseAddressSpace
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treePlcInventory = new System.Windows.Forms.TreeView();
            this.grpBrowse = new System.Windows.Forms.GroupBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblVarName = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpBrowse.SuspendLayout();
            this.SuspendLayout();
            // 
            // treePlcInventory
            // 
            this.treePlcInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treePlcInventory.Location = new System.Drawing.Point(133, 106);
            this.treePlcInventory.Name = "treePlcInventory";
            this.treePlcInventory.Size = new System.Drawing.Size(925, 306);
            this.treePlcInventory.TabIndex = 123;
            this.treePlcInventory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePlcInventory_AfterSelect);
            // 
            // grpBrowse
            // 
            this.grpBrowse.Controls.Add(this.lblSerial);
            this.grpBrowse.Controls.Add(this.lblUser);
            this.grpBrowse.Controls.Add(this.txtSerial);
            this.grpBrowse.Controls.Add(this.txtUser);
            this.grpBrowse.Controls.Add(this.lblVarName);
            this.grpBrowse.Controls.Add(this.txtIpAddress);
            this.grpBrowse.Controls.Add(this.btnBrowse);
            this.grpBrowse.Controls.Add(this.treePlcInventory);
            this.grpBrowse.Location = new System.Drawing.Point(12, 12);
            this.grpBrowse.Name = "grpBrowse";
            this.grpBrowse.Size = new System.Drawing.Size(1077, 431);
            this.grpBrowse.TabIndex = 124;
            this.grpBrowse.TabStop = false;
            this.grpBrowse.Text = "browse address space";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(86, 49);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(36, 13);
            this.lblSerial.TabIndex = 131;
            this.lblSerial.Text = "Serial:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(86, 24);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 130;
            this.lblUser.Text = "User:";
            // 
            // txtSerial
            // 
            this.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerial.Location = new System.Drawing.Point(133, 49);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(218, 20);
            this.txtSerial.TabIndex = 129;
            // 
            // txtUser
            // 
            this.txtUser.AcceptsReturn = true;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Location = new System.Drawing.Point(133, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(218, 20);
            this.txtUser.TabIndex = 127;
            // 
            // lblVarName
            // 
            this.lblVarName.AutoSize = true;
            this.lblVarName.Location = new System.Drawing.Point(6, 77);
            this.lblVarName.Name = "lblVarName";
            this.lblVarName.Size = new System.Drawing.Size(119, 13);
            this.lblVarName.TabIndex = 126;
            this.lblVarName.Text = "hostname or ip address:";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIpAddress.Location = new System.Drawing.Point(133, 75);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(196, 20);
            this.txtIpAddress.TabIndex = 125;
            this.txtIpAddress.Text = "192.168.1.100";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBrowse.Location = new System.Drawing.Point(32, 106);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(68, 68);
            this.btnBrowse.TabIndex = 124;
            this.btnBrowse.Text = "browse variables";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(1002, 450);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 68);
            this.btnClose.TabIndex = 125;
            this.btnClose.Text = "close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 530);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpBrowse);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "SymbolicBrowseAddressSpace";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpBrowse.ResumeLayout(false);
            this.grpBrowse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView treePlcInventory;
        private GroupBox grpBrowse;
        private Button btnClose;
        private Button btnBrowse;
        internal Label lblVarName;
        private TextBox txtIpAddress;
        internal Label lblSerial;
        internal Label lblUser;
        internal TextBox txtSerial;
        internal TextBox txtUser;
    }
}
