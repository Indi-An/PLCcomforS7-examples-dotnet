namespace PLCCom_Full_Test_App.Classic
{
    partial class CreateRequestInputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRequestInputBox));
            grpAddress = new System.Windows.Forms.GroupBox();
            lblRequest = new System.Windows.Forms.Label();
            txtResult = new System.Windows.Forms.TextBox();
            txtFactor = new System.Windows.Forms.TextBox();
            lblFactor = new System.Windows.Forms.Label();
            lblCodePage = new System.Windows.Forms.Label();
            cmbCodepage = new System.Windows.Forms.ComboBox();
            txtWriteAddress = new System.Windows.Forms.TextBox();
            lblWriteAddress = new System.Windows.Forms.Label();
            lblMode = new System.Windows.Forms.Label();
            rbRead = new System.Windows.Forms.RadioButton();
            rbWrite = new System.Windows.Forms.RadioButton();
            txtDB = new System.Windows.Forms.TextBox();
            lblDB = new System.Windows.Forms.Label();
            cmbRegion = new System.Windows.Forms.ComboBox();
            lblRegion = new System.Windows.Forms.Label();
            grbWriteValues = new System.Windows.Forms.Panel();
            chkAllowMultipleBits = new System.Windows.Forms.CheckBox();
            chkSingleValue = new System.Windows.Forms.CheckBox();
            rbOff = new System.Windows.Forms.RadioButton();
            rbOn = new System.Windows.Forms.RadioButton();
            txtSingleValues = new System.Windows.Forms.TextBox();
            lblEnterValues = new System.Windows.Forms.Label();
            txtMultipleNumericValues = new System.Windows.Forms.TextBox();
            txtMultipleBoolValues = new System.Windows.Forms.TextBox();
            txtQuantity = new System.Windows.Forms.TextBox();
            lblLength = new System.Windows.Forms.Label();
            txtBit = new System.Windows.Forms.TextBox();
            lblBit = new System.Windows.Forms.Label();
            txtReadAddress = new System.Windows.Forms.TextBox();
            lblReadAdress = new System.Windows.Forms.Label();
            lblDataType = new System.Windows.Forms.Label();
            cmbDataType = new System.Windows.Forms.ComboBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            txtInfoRequest = new System.Windows.Forms.TextBox();
            btnAcceptRequest = new System.Windows.Forms.Button();
            panelStatusStrip = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            btnAbort = new System.Windows.Forms.Button();
            grpAddress.SuspendLayout();
            grbWriteValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // grpAddress
            // 
            grpAddress.Controls.Add(lblRequest);
            grpAddress.Controls.Add(txtResult);
            grpAddress.Controls.Add(txtFactor);
            grpAddress.Controls.Add(lblFactor);
            grpAddress.Controls.Add(lblCodePage);
            grpAddress.Controls.Add(cmbCodepage);
            grpAddress.Controls.Add(txtWriteAddress);
            grpAddress.Controls.Add(lblWriteAddress);
            grpAddress.Controls.Add(lblMode);
            grpAddress.Controls.Add(rbRead);
            grpAddress.Controls.Add(rbWrite);
            grpAddress.Controls.Add(txtDB);
            grpAddress.Controls.Add(lblDB);
            grpAddress.Controls.Add(cmbRegion);
            grpAddress.Controls.Add(lblRegion);
            grpAddress.Controls.Add(grbWriteValues);
            grpAddress.Controls.Add(txtQuantity);
            grpAddress.Controls.Add(lblLength);
            grpAddress.Controls.Add(txtBit);
            grpAddress.Controls.Add(lblBit);
            grpAddress.Controls.Add(txtReadAddress);
            grpAddress.Controls.Add(lblReadAdress);
            grpAddress.Controls.Add(lblDataType);
            grpAddress.Controls.Add(cmbDataType);
            grpAddress.Location = new System.Drawing.Point(5, 71);
            grpAddress.Name = "grpAddress";
            grpAddress.Size = new System.Drawing.Size(656, 341);
            grpAddress.TabIndex = 87;
            grpAddress.TabStop = false;
            grpAddress.Text = "request";
            // 
            // lblRequest
            // 
            lblRequest.Location = new System.Drawing.Point(44, 312);
            lblRequest.Name = "lblRequest";
            lblRequest.Size = new System.Drawing.Size(88, 13);
            lblRequest.TabIndex = 147;
            lblRequest.Text = "request";
            lblRequest.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtResult
            // 
            txtResult.BackColor = System.Drawing.SystemColors.Control;
            txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtResult.Location = new System.Drawing.Point(138, 310);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new System.Drawing.Size(503, 20);
            txtResult.TabIndex = 136;
            // 
            // txtFactor
            // 
            txtFactor.Enabled = false;
            txtFactor.ForeColor = System.Drawing.SystemColors.HotTrack;
            txtFactor.Location = new System.Drawing.Point(265, 257);
            txtFactor.Name = "txtFactor";
            txtFactor.Size = new System.Drawing.Size(40, 20);
            txtFactor.TabIndex = 146;
            txtFactor.Text = "1";
            txtFactor.TextChanged += txtFactor_TextChanged;
            // 
            // lblFactor
            // 
            lblFactor.Enabled = false;
            lblFactor.ForeColor = System.Drawing.SystemColors.HotTrack;
            lblFactor.Location = new System.Drawing.Point(182, 260);
            lblFactor.Name = "lblFactor";
            lblFactor.Size = new System.Drawing.Size(71, 16);
            lblFactor.TabIndex = 145;
            lblFactor.Text = "x codepage";
            lblFactor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCodePage
            // 
            lblCodePage.Location = new System.Drawing.Point(44, 286);
            lblCodePage.Name = "lblCodePage";
            lblCodePage.Size = new System.Drawing.Size(88, 13);
            lblCodePage.TabIndex = 140;
            lblCodePage.Text = "codepage";
            lblCodePage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbCodepage
            // 
            cmbCodepage.Enabled = false;
            cmbCodepage.FormattingEnabled = true;
            cmbCodepage.Location = new System.Drawing.Point(138, 283);
            cmbCodepage.Name = "cmbCodepage";
            cmbCodepage.Size = new System.Drawing.Size(167, 21);
            cmbCodepage.TabIndex = 139;
            cmbCodepage.SelectedIndexChanged += cmbCodepage_SelectedIndexChanged;
            // 
            // txtWriteAddress
            // 
            txtWriteAddress.Location = new System.Drawing.Point(138, 204);
            txtWriteAddress.Name = "txtWriteAddress";
            txtWriteAddress.Size = new System.Drawing.Size(167, 20);
            txtWriteAddress.TabIndex = 137;
            txtWriteAddress.Text = "0";
            txtWriteAddress.TextChanged += txtWriteAddress_TextChanged;
            // 
            // lblWriteAddress
            // 
            lblWriteAddress.Location = new System.Drawing.Point(44, 207);
            lblWriteAddress.Name = "lblWriteAddress";
            lblWriteAddress.Size = new System.Drawing.Size(88, 13);
            lblWriteAddress.TabIndex = 138;
            lblWriteAddress.Text = "write address";
            lblWriteAddress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMode
            // 
            lblMode.Location = new System.Drawing.Point(15, 26);
            lblMode.Name = "lblMode";
            lblMode.Size = new System.Drawing.Size(117, 16);
            lblMode.TabIndex = 136;
            lblMode.Text = "read / write mode";
            lblMode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rbRead
            // 
            rbRead.Appearance = System.Windows.Forms.Appearance.Button;
            rbRead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            rbRead.Checked = true;
            rbRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rbRead.Image = (System.Drawing.Image)resources.GetObject("rbRead.Image");
            rbRead.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            rbRead.Location = new System.Drawing.Point(138, 19);
            rbRead.Name = "rbRead";
            rbRead.Size = new System.Drawing.Size(70, 70);
            rbRead.TabIndex = 123;
            rbRead.TabStop = true;
            rbRead.Text = "read";
            rbRead.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            rbRead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            rbRead.UseVisualStyleBackColor = true;
            rbRead.CheckedChanged += rbRead_CheckedChanged;
            // 
            // rbWrite
            // 
            rbWrite.Appearance = System.Windows.Forms.Appearance.Button;
            rbWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            rbWrite.Image = (System.Drawing.Image)resources.GetObject("rbWrite.Image");
            rbWrite.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            rbWrite.Location = new System.Drawing.Point(235, 19);
            rbWrite.Name = "rbWrite";
            rbWrite.Size = new System.Drawing.Size(70, 70);
            rbWrite.TabIndex = 135;
            rbWrite.Text = "write";
            rbWrite.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            rbWrite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            rbWrite.UseVisualStyleBackColor = true;
            // 
            // txtDB
            // 
            txtDB.Location = new System.Drawing.Point(138, 151);
            txtDB.Name = "txtDB";
            txtDB.Size = new System.Drawing.Size(167, 20);
            txtDB.TabIndex = 121;
            txtDB.Text = "1";
            txtDB.TextChanged += txtDB_TextChanged;
            // 
            // lblDB
            // 
            lblDB.Location = new System.Drawing.Point(11, 149);
            lblDB.Name = "lblDB";
            lblDB.Size = new System.Drawing.Size(121, 28);
            lblDB.TabIndex = 122;
            lblDB.Text = "DB (only for DB, use 0 otherwise)";
            lblDB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbRegion
            // 
            cmbRegion.FormattingEnabled = true;
            cmbRegion.Location = new System.Drawing.Point(138, 96);
            cmbRegion.Name = "cmbRegion";
            cmbRegion.Size = new System.Drawing.Size(167, 21);
            cmbRegion.TabIndex = 119;
            cmbRegion.SelectedIndexChanged += cmbRegion_SelectedIndexChanged;
            // 
            // lblRegion
            // 
            lblRegion.Location = new System.Drawing.Point(50, 100);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new System.Drawing.Size(82, 16);
            lblRegion.TabIndex = 120;
            lblRegion.Text = "region";
            lblRegion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grbWriteValues
            // 
            grbWriteValues.Controls.Add(chkAllowMultipleBits);
            grbWriteValues.Controls.Add(chkSingleValue);
            grbWriteValues.Controls.Add(rbOff);
            grbWriteValues.Controls.Add(rbOn);
            grbWriteValues.Controls.Add(txtSingleValues);
            grbWriteValues.Controls.Add(lblEnterValues);
            grbWriteValues.Controls.Add(txtMultipleNumericValues);
            grbWriteValues.Controls.Add(txtMultipleBoolValues);
            grbWriteValues.Enabled = false;
            grbWriteValues.Location = new System.Drawing.Point(322, 19);
            grbWriteValues.Name = "grbWriteValues";
            grbWriteValues.Size = new System.Drawing.Size(319, 288);
            grbWriteValues.TabIndex = 118;
            // 
            // chkAllowMultipleBits
            // 
            chkAllowMultipleBits.AutoSize = true;
            chkAllowMultipleBits.Location = new System.Drawing.Point(41, 13);
            chkAllowMultipleBits.Name = "chkAllowMultipleBits";
            chkAllowMultipleBits.Size = new System.Drawing.Size(108, 17);
            chkAllowMultipleBits.TabIndex = 128;
            chkAllowMultipleBits.Text = "allow multiple Bits";
            chkAllowMultipleBits.UseVisualStyleBackColor = true;
            chkAllowMultipleBits.CheckedChanged += chkAllowMultipleBits_CheckedChanged;
            // 
            // chkSingleValue
            // 
            chkSingleValue.AutoSize = true;
            chkSingleValue.Location = new System.Drawing.Point(41, 36);
            chkSingleValue.Name = "chkSingleValue";
            chkSingleValue.Size = new System.Drawing.Size(82, 17);
            chkSingleValue.TabIndex = 126;
            chkSingleValue.Text = "single value";
            chkSingleValue.UseVisualStyleBackColor = true;
            chkSingleValue.CheckedChanged += chkSingleValue_CheckedChanged;
            // 
            // rbOff
            // 
            rbOff.AutoSize = true;
            rbOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rbOff.Location = new System.Drawing.Point(179, 78);
            rbOff.Name = "rbOff";
            rbOff.Size = new System.Drawing.Size(44, 17);
            rbOff.TabIndex = 121;
            rbOff.Text = "OFF";
            rbOff.UseVisualStyleBackColor = true;
            rbOff.Visible = false;
            rbOff.CheckedChanged += rbOff_CheckedChanged;
            // 
            // rbOn
            // 
            rbOn.AutoSize = true;
            rbOn.Checked = true;
            rbOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rbOn.Location = new System.Drawing.Point(41, 78);
            rbOn.Name = "rbOn";
            rbOn.Size = new System.Drawing.Size(40, 17);
            rbOn.TabIndex = 120;
            rbOn.TabStop = true;
            rbOn.Text = "ON";
            rbOn.UseVisualStyleBackColor = true;
            rbOn.Visible = false;
            rbOn.CheckedChanged += rbOn_CheckedChanged;
            // 
            // txtSingleValues
            // 
            txtSingleValues.BackColor = System.Drawing.Color.White;
            txtSingleValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSingleValues.Location = new System.Drawing.Point(41, 78);
            txtSingleValues.Name = "txtSingleValues";
            txtSingleValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtSingleValues.Size = new System.Drawing.Size(275, 20);
            txtSingleValues.TabIndex = 119;
            txtSingleValues.Text = "0";
            txtSingleValues.Visible = false;
            txtSingleValues.TextChanged += txtSingleValues_TextChanged;
            // 
            // lblEnterValues
            // 
            lblEnterValues.AutoSize = true;
            lblEnterValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblEnterValues.Location = new System.Drawing.Point(38, 56);
            lblEnterValues.Name = "lblEnterValues";
            lblEnterValues.Size = new System.Drawing.Size(212, 13);
            lblEnterValues.TabIndex = 118;
            lblEnterValues.Text = "Please enter the values separated by return";
            // 
            // txtMultipleNumericValues
            // 
            txtMultipleNumericValues.BackColor = System.Drawing.Color.White;
            txtMultipleNumericValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMultipleNumericValues.Location = new System.Drawing.Point(41, 79);
            txtMultipleNumericValues.Multiline = true;
            txtMultipleNumericValues.Name = "txtMultipleNumericValues";
            txtMultipleNumericValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtMultipleNumericValues.Size = new System.Drawing.Size(275, 189);
            txtMultipleNumericValues.TabIndex = 117;
            txtMultipleNumericValues.Text = "0\r\n0\r\n0\r\n0";
            txtMultipleNumericValues.TextChanged += txtMultipleNumericValues_TextChanged;
            // 
            // txtMultipleBoolValues
            // 
            txtMultipleBoolValues.BackColor = System.Drawing.Color.White;
            txtMultipleBoolValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMultipleBoolValues.Location = new System.Drawing.Point(41, 79);
            txtMultipleBoolValues.Multiline = true;
            txtMultipleBoolValues.Name = "txtMultipleBoolValues";
            txtMultipleBoolValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtMultipleBoolValues.Size = new System.Drawing.Size(275, 189);
            txtMultipleBoolValues.TabIndex = 117;
            txtMultipleBoolValues.Text = "true\r\ntrue\r\ntrue\r\ntrue";
            txtMultipleBoolValues.TextChanged += txtMultipleBoolValues_TextChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new System.Drawing.Point(138, 257);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new System.Drawing.Size(38, 20);
            txtQuantity.TabIndex = 112;
            txtQuantity.Text = "1";
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // lblLength
            // 
            lblLength.Location = new System.Drawing.Point(44, 260);
            lblLength.Name = "lblLength";
            lblLength.Size = new System.Drawing.Size(88, 13);
            lblLength.TabIndex = 113;
            lblLength.Text = "quantity";
            lblLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBit
            // 
            txtBit.Location = new System.Drawing.Point(138, 229);
            txtBit.Name = "txtBit";
            txtBit.Size = new System.Drawing.Size(167, 20);
            txtBit.TabIndex = 109;
            txtBit.Text = "0";
            txtBit.TextChanged += txtBit_TextChanged;
            // 
            // lblBit
            // 
            lblBit.Location = new System.Drawing.Point(18, 226);
            lblBit.Name = "lblBit";
            lblBit.Size = new System.Drawing.Size(115, 28);
            lblBit.TabIndex = 110;
            lblBit.Text = "bit";
            lblBit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtReadAddress
            // 
            txtReadAddress.Location = new System.Drawing.Point(138, 178);
            txtReadAddress.Name = "txtReadAddress";
            txtReadAddress.Size = new System.Drawing.Size(167, 20);
            txtReadAddress.TabIndex = 108;
            txtReadAddress.Text = "0";
            txtReadAddress.TextChanged += txtReadAddress_TextChanged;
            // 
            // lblReadAdress
            // 
            lblReadAdress.Location = new System.Drawing.Point(44, 181);
            lblReadAdress.Name = "lblReadAdress";
            lblReadAdress.Size = new System.Drawing.Size(88, 13);
            lblReadAdress.TabIndex = 111;
            lblReadAdress.Text = "read address";
            lblReadAdress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDataType
            // 
            lblDataType.Location = new System.Drawing.Point(44, 126);
            lblDataType.Name = "lblDataType";
            lblDataType.Size = new System.Drawing.Size(88, 13);
            lblDataType.TabIndex = 76;
            lblDataType.Text = "data type";
            lblDataType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbDataType
            // 
            cmbDataType.FormattingEnabled = true;
            cmbDataType.Location = new System.Drawing.Point(138, 123);
            cmbDataType.Name = "cmbDataType";
            cmbDataType.Size = new System.Drawing.Size(167, 21);
            cmbDataType.TabIndex = 75;
            cmbDataType.SelectedIndexChanged += cmbDataType_SelectedIndexChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(12, -1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(130, 60);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 134;
            pictureBox2.TabStop = false;
            // 
            // txtInfoRequest
            // 
            txtInfoRequest.BackColor = System.Drawing.SystemColors.Info;
            txtInfoRequest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfoRequest.Location = new System.Drawing.Point(42, 2);
            txtInfoRequest.Multiline = true;
            txtInfoRequest.Name = "txtInfoRequest";
            txtInfoRequest.Size = new System.Drawing.Size(413, 56);
            txtInfoRequest.TabIndex = 114;
            txtInfoRequest.Text = "You can execute single read and write processes on this window. For optimized read processes please use the ReadDataRequestCollection.";
            // 
            // btnAcceptRequest
            // 
            btnAcceptRequest.Image = (System.Drawing.Image)resources.GetObject("btnAcceptRequest.Image");
            btnAcceptRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnAcceptRequest.Location = new System.Drawing.Point(517, 421);
            btnAcceptRequest.Name = "btnAcceptRequest";
            btnAcceptRequest.Size = new System.Drawing.Size(68, 68);
            btnAcceptRequest.TabIndex = 105;
            btnAcceptRequest.Text = "Create Request";
            btnAcceptRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnAcceptRequest.UseVisualStyleBackColor = true;
            btnAcceptRequest.Click += btnAcceptRequest_Click;
            // 
            // panelStatusStrip
            // 
            panelStatusStrip.AutoSize = true;
            panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelStatusStrip.Location = new System.Drawing.Point(0, 499);
            panelStatusStrip.Name = "panelStatusStrip";
            panelStatusStrip.Size = new System.Drawing.Size(671, 2);
            panelStatusStrip.TabIndex = 97;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Info;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtInfoRequest);
            panel1.Location = new System.Drawing.Point(185, 6);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(474, 59);
            panel1.TabIndex = 135;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(32, 32);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 153;
            pictureBox1.TabStop = false;
            // 
            // btnAbort
            // 
            btnAbort.Image = (System.Drawing.Image)resources.GetObject("btnAbort.Image");
            btnAbort.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnAbort.Location = new System.Drawing.Point(591, 421);
            btnAbort.Name = "btnAbort";
            btnAbort.Size = new System.Drawing.Size(68, 68);
            btnAbort.TabIndex = 136;
            btnAbort.Text = "Abort";
            btnAbort.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnAbort.UseVisualStyleBackColor = true;
            btnAbort.Click += btnAbort_Click;
            // 
            // CreateRequestInputBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(671, 501);
            Controls.Add(btnAbort);
            Controls.Add(btnAcceptRequest);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(panelStatusStrip);
            Controls.Add(grpAddress);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateRequestInputBox";
            Text = "CreateRequestInputBox";
            Load += CreateRequest_Load;
            grpAddress.ResumeLayout(false);
            grpAddress.PerformLayout();
            grbWriteValues.ResumeLayout(false);
            grbWriteValues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.Label lblDataType;
        internal System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.TextBox txtInfoRequest;
        internal System.Windows.Forms.TextBox txtQuantity;
        internal System.Windows.Forms.Label lblLength;
        internal System.Windows.Forms.TextBox txtBit;
        internal System.Windows.Forms.Label lblBit;
        internal System.Windows.Forms.TextBox txtReadAddress;
        internal System.Windows.Forms.Label lblReadAdress;
        private System.Windows.Forms.Button btnAcceptRequest;
        private System.Windows.Forms.Panel grbWriteValues;
        private System.Windows.Forms.CheckBox chkSingleValue;
        private System.Windows.Forms.RadioButton rbOff;
        private System.Windows.Forms.RadioButton rbOn;
        internal System.Windows.Forms.TextBox txtSingleValues;
        internal System.Windows.Forms.Label lblEnterValues;
        internal System.Windows.Forms.TextBox txtMultipleNumericValues;
        internal System.Windows.Forms.TextBox txtMultipleBoolValues;
        internal System.Windows.Forms.ComboBox cmbRegion;
        internal System.Windows.Forms.Label lblRegion;
        internal System.Windows.Forms.TextBox txtDB;
        internal System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.RadioButton rbRead;
        private System.Windows.Forms.RadioButton rbWrite;
        internal System.Windows.Forms.TextBox txtWriteAddress;
        internal System.Windows.Forms.Label lblWriteAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.ComboBox cmbCodepage;
        internal System.Windows.Forms.Label lblCodePage;
        internal System.Windows.Forms.TextBox txtFactor;
        private System.Windows.Forms.Label lblFactor;
        private System.Windows.Forms.TextBox txtResult;
        internal System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.CheckBox chkAllowMultipleBits;
        private System.Windows.Forms.Button btnAbort;
    }
}