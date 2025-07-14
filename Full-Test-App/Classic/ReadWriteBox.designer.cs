namespace PLCCom_Full_Test_App.Classic
{
    partial class ReadWriteBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadWriteBox));
            grpAddress = new System.Windows.Forms.GroupBox();
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
            txtInfoRB = new System.Windows.Forms.TextBox();
            grpAction = new System.Windows.Forms.GroupBox();
            btnExecute = new System.Windows.Forms.Button();
            lvValues = new System.Windows.Forms.ListView();
            colDummy = new System.Windows.Forms.ColumnHeader();
            colPosition = new System.Windows.Forms.ColumnHeader();
            colValue = new System.Windows.Forms.ColumnHeader();
            lblLog = new System.Windows.Forms.Label();
            panelStatusStrip = new System.Windows.Forms.Panel();
            statusStrip = new System.Windows.Forms.StatusStrip();
            lblDeviceType = new System.Windows.Forms.ToolStripStatusLabel();
            lvLog = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            btnSaveLogtoFile = new System.Windows.Forms.Button();
            btnSaveLogtoClipboard = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            grpAddress.SuspendLayout();
            grbWriteValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            grpAction.SuspendLayout();
            panelStatusStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // grpAddress
            // 
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
            grpAddress.Location = new System.Drawing.Point(12, 65);
            grpAddress.Name = "grpAddress";
            grpAddress.Size = new System.Drawing.Size(656, 253);
            grpAddress.TabIndex = 87;
            grpAddress.TabStop = false;
            grpAddress.Text = "request";
            // 
            // txtFactor
            // 
            txtFactor.Enabled = false;
            txtFactor.ForeColor = System.Drawing.SystemColors.HotTrack;
            txtFactor.Location = new System.Drawing.Point(265, 198);
            txtFactor.Name = "txtFactor";
            txtFactor.Size = new System.Drawing.Size(40, 20);
            txtFactor.TabIndex = 146;
            txtFactor.Text = "1";
            // 
            // lblFactor
            // 
            lblFactor.Enabled = false;
            lblFactor.ForeColor = System.Drawing.SystemColors.HotTrack;
            lblFactor.Location = new System.Drawing.Point(182, 201);
            lblFactor.Name = "lblFactor";
            lblFactor.Size = new System.Drawing.Size(71, 16);
            lblFactor.TabIndex = 145;
            lblFactor.Text = "x codepage";
            lblFactor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCodePage
            // 
            lblCodePage.Location = new System.Drawing.Point(44, 227);
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
            cmbCodepage.Location = new System.Drawing.Point(138, 224);
            cmbCodepage.Name = "cmbCodepage";
            cmbCodepage.Size = new System.Drawing.Size(167, 21);
            cmbCodepage.TabIndex = 139;
            cmbCodepage.SelectedIndexChanged += cmbCodepage_SelectedIndexChanged;
            // 
            // txtWriteAddress
            // 
            txtWriteAddress.Location = new System.Drawing.Point(138, 145);
            txtWriteAddress.Name = "txtWriteAddress";
            txtWriteAddress.Size = new System.Drawing.Size(167, 20);
            txtWriteAddress.TabIndex = 137;
            txtWriteAddress.Text = "0";
            // 
            // lblWriteAddress
            // 
            lblWriteAddress.Location = new System.Drawing.Point(44, 148);
            lblWriteAddress.Name = "lblWriteAddress";
            lblWriteAddress.Size = new System.Drawing.Size(88, 13);
            lblWriteAddress.TabIndex = 138;
            lblWriteAddress.Text = "write address";
            lblWriteAddress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMode
            // 
            lblMode.Location = new System.Drawing.Point(15, 17);
            lblMode.Name = "lblMode";
            lblMode.Size = new System.Drawing.Size(117, 16);
            lblMode.TabIndex = 136;
            lblMode.Text = "read / write mode";
            lblMode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rbRead
            // 
            rbRead.AutoSize = true;
            rbRead.Checked = true;
            rbRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rbRead.Location = new System.Drawing.Point(138, 17);
            rbRead.Name = "rbRead";
            rbRead.Size = new System.Drawing.Size(83, 17);
            rbRead.TabIndex = 123;
            rbRead.TabStop = true;
            rbRead.Text = "read on PLC";
            rbRead.UseVisualStyleBackColor = true;
            rbRead.CheckedChanged += rbRead_CheckedChanged;
            // 
            // rbWrite
            // 
            rbWrite.AutoSize = true;
            rbWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rbWrite.Location = new System.Drawing.Point(230, 17);
            rbWrite.Name = "rbWrite";
            rbWrite.Size = new System.Drawing.Size(75, 17);
            rbWrite.TabIndex = 135;
            rbWrite.Text = "write to plc";
            rbWrite.UseVisualStyleBackColor = true;
            // 
            // txtDB
            // 
            txtDB.Location = new System.Drawing.Point(138, 92);
            txtDB.Name = "txtDB";
            txtDB.Size = new System.Drawing.Size(167, 20);
            txtDB.TabIndex = 121;
            txtDB.Text = "1";
            // 
            // lblDB
            // 
            lblDB.Location = new System.Drawing.Point(11, 90);
            lblDB.Name = "lblDB";
            lblDB.Size = new System.Drawing.Size(121, 28);
            lblDB.TabIndex = 122;
            lblDB.Text = "DB (only for DB, use 0 otherwise)";
            lblDB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbRegion
            // 
            cmbRegion.FormattingEnabled = true;
            cmbRegion.Location = new System.Drawing.Point(138, 37);
            cmbRegion.Name = "cmbRegion";
            cmbRegion.Size = new System.Drawing.Size(167, 21);
            cmbRegion.TabIndex = 119;
            cmbRegion.SelectedIndexChanged += cmbRegion_SelectedIndexChanged;
            // 
            // lblRegion
            // 
            lblRegion.Location = new System.Drawing.Point(50, 41);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new System.Drawing.Size(82, 16);
            lblRegion.TabIndex = 120;
            lblRegion.Text = "region";
            lblRegion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grbWriteValues
            // 
            grbWriteValues.Controls.Add(chkSingleValue);
            grbWriteValues.Controls.Add(rbOff);
            grbWriteValues.Controls.Add(rbOn);
            grbWriteValues.Controls.Add(txtSingleValues);
            grbWriteValues.Controls.Add(lblEnterValues);
            grbWriteValues.Controls.Add(txtMultipleNumericValues);
            grbWriteValues.Controls.Add(txtMultipleBoolValues);
            grbWriteValues.Enabled = false;
            grbWriteValues.Location = new System.Drawing.Point(331, 6);
            grbWriteValues.Name = "grbWriteValues";
            grbWriteValues.Size = new System.Drawing.Size(319, 239);
            grbWriteValues.TabIndex = 118;
            // 
            // chkSingleValue
            // 
            chkSingleValue.AutoSize = true;
            chkSingleValue.Location = new System.Drawing.Point(41, 13);
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
            rbOff.Location = new System.Drawing.Point(179, 55);
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
            rbOn.Location = new System.Drawing.Point(41, 55);
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
            txtSingleValues.Location = new System.Drawing.Point(41, 55);
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
            lblEnterValues.Location = new System.Drawing.Point(38, 33);
            lblEnterValues.Name = "lblEnterValues";
            lblEnterValues.Size = new System.Drawing.Size(212, 13);
            lblEnterValues.TabIndex = 118;
            lblEnterValues.Text = "Please enter the values separated by return";
            // 
            // txtMultipleNumericValues
            // 
            txtMultipleNumericValues.BackColor = System.Drawing.Color.White;
            txtMultipleNumericValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMultipleNumericValues.Location = new System.Drawing.Point(41, 56);
            txtMultipleNumericValues.Multiline = true;
            txtMultipleNumericValues.Name = "txtMultipleNumericValues";
            txtMultipleNumericValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtMultipleNumericValues.Size = new System.Drawing.Size(275, 156);
            txtMultipleNumericValues.TabIndex = 117;
            txtMultipleNumericValues.Text = "0\r\n0\r\n0\r\n0";
            txtMultipleNumericValues.TextChanged += txtMultipleNumericValues_TextChanged;
            // 
            // txtMultipleBoolValues
            // 
            txtMultipleBoolValues.BackColor = System.Drawing.Color.White;
            txtMultipleBoolValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMultipleBoolValues.Location = new System.Drawing.Point(41, 56);
            txtMultipleBoolValues.Multiline = true;
            txtMultipleBoolValues.Name = "txtMultipleBoolValues";
            txtMultipleBoolValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtMultipleBoolValues.Size = new System.Drawing.Size(275, 156);
            txtMultipleBoolValues.TabIndex = 117;
            txtMultipleBoolValues.Text = "true\r\ntrue\r\ntrue\r\ntrue";
            txtMultipleBoolValues.TextChanged += txtMultipleBoolValues_TextChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new System.Drawing.Point(138, 198);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new System.Drawing.Size(38, 20);
            txtQuantity.TabIndex = 112;
            txtQuantity.Text = "1";
            // 
            // lblLength
            // 
            lblLength.Location = new System.Drawing.Point(44, 201);
            lblLength.Name = "lblLength";
            lblLength.Size = new System.Drawing.Size(88, 13);
            lblLength.TabIndex = 113;
            lblLength.Text = "quantity";
            lblLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBit
            // 
            txtBit.Location = new System.Drawing.Point(138, 170);
            txtBit.Name = "txtBit";
            txtBit.Size = new System.Drawing.Size(167, 20);
            txtBit.TabIndex = 109;
            txtBit.Text = "0";
            // 
            // lblBit
            // 
            lblBit.Location = new System.Drawing.Point(18, 167);
            lblBit.Name = "lblBit";
            lblBit.Size = new System.Drawing.Size(115, 28);
            lblBit.TabIndex = 110;
            lblBit.Text = "bit";
            lblBit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtReadAddress
            // 
            txtReadAddress.Location = new System.Drawing.Point(138, 119);
            txtReadAddress.Name = "txtReadAddress";
            txtReadAddress.Size = new System.Drawing.Size(167, 20);
            txtReadAddress.TabIndex = 108;
            txtReadAddress.Text = "0";
            // 
            // lblReadAdress
            // 
            lblReadAdress.Location = new System.Drawing.Point(44, 122);
            lblReadAdress.Name = "lblReadAdress";
            lblReadAdress.Size = new System.Drawing.Size(88, 13);
            lblReadAdress.TabIndex = 111;
            lblReadAdress.Text = "read address";
            lblReadAdress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDataType
            // 
            lblDataType.Location = new System.Drawing.Point(44, 67);
            lblDataType.Name = "lblDataType";
            lblDataType.Size = new System.Drawing.Size(88, 13);
            lblDataType.TabIndex = 76;
            lblDataType.Text = "data type";
            lblDataType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbDataType
            // 
            cmbDataType.FormattingEnabled = true;
            cmbDataType.Location = new System.Drawing.Point(138, 64);
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
            // txtInfoRB
            // 
            txtInfoRB.BackColor = System.Drawing.SystemColors.Info;
            txtInfoRB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfoRB.Location = new System.Drawing.Point(42, 2);
            txtInfoRB.Multiline = true;
            txtInfoRB.Name = "txtInfoRB";
            txtInfoRB.Size = new System.Drawing.Size(413, 56);
            txtInfoRB.TabIndex = 114;
            txtInfoRB.Text = "You can execute single read and write processes on this window. For optimized read processes please use the ReadDataRequestCollection.";
            // 
            // grpAction
            // 
            grpAction.Controls.Add(btnExecute);
            grpAction.Controls.Add(lvValues);
            grpAction.Location = new System.Drawing.Point(12, 320);
            grpAction.Name = "grpAction";
            grpAction.Size = new System.Drawing.Size(656, 180);
            grpAction.TabIndex = 88;
            grpAction.TabStop = false;
            grpAction.Text = "Action";
            // 
            // btnExecute
            // 
            btnExecute.Image = (System.Drawing.Image)resources.GetObject("btnExecute.Image");
            btnExecute.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnExecute.Location = new System.Drawing.Point(15, 19);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new System.Drawing.Size(68, 68);
            btnExecute.TabIndex = 105;
            btnExecute.Text = "execute function";
            btnExecute.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // lvValues
            // 
            lvValues.Activation = System.Windows.Forms.ItemActivation.OneClick;
            lvValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colDummy, colPosition, colValue });
            lvValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvValues.FullRowSelect = true;
            lvValues.Location = new System.Drawing.Point(100, 19);
            lvValues.Name = "lvValues";
            lvValues.Size = new System.Drawing.Size(550, 140);
            lvValues.TabIndex = 104;
            lvValues.UseCompatibleStateImageBehavior = false;
            lvValues.View = System.Windows.Forms.View.Details;
            // 
            // colDummy
            // 
            colDummy.Text = "";
            colDummy.Width = 0;
            // 
            // colPosition
            // 
            colPosition.Text = "Position";
            // 
            // colValue
            // 
            colValue.Text = "Values";
            colValue.Width = 460;
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new System.Drawing.Point(109, 476);
            lblLog.Name = "lblLog";
            lblLog.Size = new System.Drawing.Size(90, 13);
            lblLog.TabIndex = 39;
            lblLog.Text = "Diagnostic output";
            // 
            // panelStatusStrip
            // 
            panelStatusStrip.AutoSize = true;
            panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelStatusStrip.Controls.Add(statusStrip);
            panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelStatusStrip.Location = new System.Drawing.Point(0, 739);
            panelStatusStrip.Name = "panelStatusStrip";
            panelStatusStrip.Size = new System.Drawing.Size(671, 24);
            panelStatusStrip.TabIndex = 97;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = System.Drawing.SystemColors.Control;
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblDeviceType });
            statusStrip.Location = new System.Drawing.Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(669, 22);
            statusStrip.TabIndex = 95;
            // 
            // lblDeviceType
            // 
            lblDeviceType.BackColor = System.Drawing.Color.White;
            lblDeviceType.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            lblDeviceType.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            lblDeviceType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            lblDeviceType.Name = "lblDeviceType";
            lblDeviceType.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            lblDeviceType.Size = new System.Drawing.Size(77, 17);
            lblDeviceType.Text = "DeviceType: ";
            // 
            // lvLog
            // 
            lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1 });
            lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvLog.Location = new System.Drawing.Point(112, 514);
            lvLog.Name = "lvLog";
            lvLog.Size = new System.Drawing.Size(550, 142);
            lvLog.TabIndex = 98;
            lvLog.UseCompatibleStateImageBehavior = false;
            lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 1000;
            // 
            // btnSaveLogtoFile
            // 
            btnSaveLogtoFile.Image = (System.Drawing.Image)resources.GetObject("btnSaveLogtoFile.Image");
            btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveLogtoFile.Location = new System.Drawing.Point(27, 592);
            btnSaveLogtoFile.Name = "btnSaveLogtoFile";
            btnSaveLogtoFile.Size = new System.Drawing.Size(68, 68);
            btnSaveLogtoFile.TabIndex = 107;
            btnSaveLogtoFile.Text = "save log to file";
            btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveLogtoFile.UseVisualStyleBackColor = true;
            btnSaveLogtoFile.Click += btnSaveLogtoFile_Click;
            // 
            // btnSaveLogtoClipboard
            // 
            btnSaveLogtoClipboard.Image = (System.Drawing.Image)resources.GetObject("btnSaveLogtoClipboard.Image");
            btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveLogtoClipboard.Location = new System.Drawing.Point(27, 518);
            btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard";
            btnSaveLogtoClipboard.Size = new System.Drawing.Size(68, 68);
            btnSaveLogtoClipboard.TabIndex = 106;
            btnSaveLogtoClipboard.Text = "copy log to clipboard";
            btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveLogtoClipboard.UseVisualStyleBackColor = true;
            btnSaveLogtoClipboard.Click += btnSaveLogtoClipboard_Click;
            // 
            // btnClose
            // 
            btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnClose.Location = new System.Drawing.Point(594, 664);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(68, 68);
            btnClose.TabIndex = 108;
            btnClose.Text = "close window";
            btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Info;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtInfoRB);
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
            // ReadWriteBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(671, 763);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(btnClose);
            Controls.Add(btnSaveLogtoFile);
            Controls.Add(btnSaveLogtoClipboard);
            Controls.Add(lvLog);
            Controls.Add(lblLog);
            Controls.Add(panelStatusStrip);
            Controls.Add(grpAction);
            Controls.Add(grpAddress);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReadWriteBox";
            Text = "ReadWriteBox";
            FormClosing += ReadWriteBox_FormClosing;
            Load += ReadWriteBox_Load;
            grpAddress.ResumeLayout(false);
            grpAddress.PerformLayout();
            grbWriteValues.ResumeLayout(false);
            grbWriteValues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            grpAction.ResumeLayout(false);
            panelStatusStrip.ResumeLayout(false);
            panelStatusStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.GroupBox grpAction;
        internal System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceType;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblDataType;
        internal System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.TextBox txtInfoRB;
        internal System.Windows.Forms.TextBox txtQuantity;
        internal System.Windows.Forms.Label lblLength;
        internal System.Windows.Forms.TextBox txtBit;
        internal System.Windows.Forms.Label lblBit;
        internal System.Windows.Forms.TextBox txtReadAddress;
        internal System.Windows.Forms.Label lblReadAdress;
        private System.Windows.Forms.Button btnSaveLogtoFile;
        private System.Windows.Forms.Button btnSaveLogtoClipboard;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ListView lvValues;
        private System.Windows.Forms.ColumnHeader colDummy;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Button btnClose;
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
        private System.Windows.Forms.ColumnHeader colPosition;
        internal System.Windows.Forms.TextBox txtWriteAddress;
        internal System.Windows.Forms.Label lblWriteAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.ComboBox cmbCodepage;
        internal System.Windows.Forms.Label lblCodePage;
        internal System.Windows.Forms.TextBox txtFactor;
        private System.Windows.Forms.Label lblFactor;
    }
}