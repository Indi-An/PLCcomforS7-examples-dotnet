namespace PLCCom_Full_Test_App
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            txtWarning = new System.Windows.Forms.TextBox();
            grbSerial = new System.Windows.Forms.GroupBox();
            lblSerial = new System.Windows.Forms.Label();
            lblUser = new System.Windows.Forms.Label();
            txtSerial = new System.Windows.Forms.TextBox();
            txtUser = new System.Windows.Forms.TextBox();
            lblSerialCode = new System.Windows.Forms.Label();
            grbAccess = new System.Windows.Forms.GroupBox();
            btnAlarmMessages = new System.Windows.Forms.Button();
            btnReadWriteSymbolic = new System.Windows.Forms.Button();
            btnOptimizedReadWrite = new System.Windows.Forms.Button();
            btnReadWriteFunctions = new System.Windows.Forms.Button();
            btnDataServer = new System.Windows.Forms.Button();
            btnOtherFunctions = new System.Windows.Forms.Button();
            btnBlockFunctions = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            grbConnectionSettings = new System.Windows.Forms.GroupBox();
            lblAsyncConnect = new System.Windows.Forms.Label();
            chkAsyncConnect = new System.Windows.Forms.CheckBox();
            lblmaxIdleTime = new System.Windows.Forms.Label();
            btnSaveConnectionSettings = new System.Windows.Forms.Button();
            lblAutoConnect2 = new System.Windows.Forms.Label();
            grbParams = new System.Windows.Forms.GroupBox();
            btnPlcTypeHelp = new System.Windows.Forms.Button();
            lblBusSpeed = new System.Windows.Forms.Label();
            cmbBusspeed = new System.Windows.Forms.ComboBox();
            lblBaudrate = new System.Windows.Forms.Label();
            cmbBaudrate = new System.Windows.Forms.ComboBox();
            lblConnectionType = new System.Windows.Forms.Label();
            cmbConnectionType = new System.Windows.Forms.ComboBox();
            cmbPLCType = new System.Windows.Forms.ComboBox();
            lblPLCType = new System.Windows.Forms.Label();
            grbAddress = new System.Windows.Forms.GroupBox();
            lblProtectionUser = new System.Windows.Forms.Label();
            txtProtectionUser = new System.Windows.Forms.TextBox();
            txtAdress1 = new System.Windows.Forms.TextBox();
            lblProtectionPassword = new System.Windows.Forms.Label();
            txtAdress2 = new System.Windows.Forms.TextBox();
            lblAdress2 = new System.Windows.Forms.Label();
            txtProtectionPassword = new System.Windows.Forms.MaskedTextBox();
            lblAdress1 = new System.Windows.Forms.Label();
            txtAdress0 = new System.Windows.Forms.TextBox();
            txtAdress4 = new System.Windows.Forms.TextBox();
            txtAdress3 = new System.Windows.Forms.TextBox();
            lblAdress0 = new System.Windows.Forms.Label();
            lblAdress3 = new System.Windows.Forms.Label();
            lblAdress4 = new System.Windows.Forms.Label();
            chkAutoConnect = new System.Windows.Forms.CheckBox();
            txtIdleTimeSpan = new System.Windows.Forms.TextBox();
            btnConnect = new System.Windows.Forms.Button();
            btnDisconnect = new System.Windows.Forms.Button();
            panelStatusStrip = new System.Windows.Forms.Panel();
            statusStrip = new System.Windows.Forms.StatusStrip();
            txtDeviceState = new System.Windows.Forms.ToolStripStatusLabel();
            progbarStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            ProgressBarProjectImport = new System.Windows.Forms.ToolStripProgressBar();
            btnEditConnectionSettings = new System.Windows.Forms.Button();
            lblLanguage = new System.Windows.Forms.Label();
            cmbLanguage = new System.Windows.Forms.ComboBox();
            grbConnection = new System.Windows.Forms.Panel();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            lblSerialLimited = new System.Windows.Forms.Label();
            grbSerial.SuspendLayout();
            grbAccess.SuspendLayout();
            grbConnectionSettings.SuspendLayout();
            grbParams.SuspendLayout();
            grbAddress.SuspendLayout();
            panelStatusStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            grbConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // txtWarning
            // 
            txtWarning.BackColor = System.Drawing.SystemColors.Info;
            txtWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            txtWarning.Location = new System.Drawing.Point(12, 12);
            txtWarning.Multiline = true;
            txtWarning.Name = "txtWarning";
            txtWarning.ReadOnly = true;
            txtWarning.Size = new System.Drawing.Size(713, 204);
            txtWarning.TabIndex = 5;
            txtWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grbSerial
            // 
            grbSerial.Controls.Add(lblSerialLimited);
            grbSerial.Controls.Add(lblSerial);
            grbSerial.Controls.Add(lblUser);
            grbSerial.Controls.Add(txtSerial);
            grbSerial.Controls.Add(txtUser);
            grbSerial.Controls.Add(lblSerialCode);
            grbSerial.Enabled = false;
            grbSerial.Location = new System.Drawing.Point(9, 300);
            grbSerial.Name = "grbSerial";
            grbSerial.Size = new System.Drawing.Size(710, 69);
            grbSerial.TabIndex = 15;
            grbSerial.TabStop = false;
            grbSerial.Text = "Serial";
            // 
            // lblSerial
            // 
            lblSerial.AutoSize = true;
            lblSerial.Location = new System.Drawing.Point(425, 41);
            lblSerial.Name = "lblSerial";
            lblSerial.Size = new System.Drawing.Size(36, 13);
            lblSerial.TabIndex = 12;
            lblSerial.Text = "Serial:";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new System.Drawing.Point(425, 16);
            lblUser.Name = "lblUser";
            lblUser.Size = new System.Drawing.Size(32, 13);
            lblUser.TabIndex = 11;
            lblUser.Text = "User:";
            // 
            // txtSerial
            // 
            txtSerial.Location = new System.Drawing.Point(478, 41);
            txtSerial.Name = "txtSerial";
            txtSerial.Size = new System.Drawing.Size(218, 20);
            txtSerial.TabIndex = 10;
            txtSerial.TextChanged += txtSerial_TextChanged;
            // 
            // txtUser
            // 
            txtUser.AcceptsReturn = true;
            txtUser.Location = new System.Drawing.Point(478, 11);
            txtUser.Name = "txtUser";
            txtUser.Size = new System.Drawing.Size(218, 20);
            txtUser.TabIndex = 0;
            txtUser.TextChanged += txtUser_TextChanged;
            // 
            // lblSerialCode
            // 
            lblSerialCode.AutoSize = true;
            lblSerialCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            lblSerialCode.Location = new System.Drawing.Point(11, 18);
            lblSerialCode.Name = "lblSerialCode";
            lblSerialCode.Size = new System.Drawing.Size(250, 16);
            lblSerialCode.TabIndex = 0;
            lblSerialCode.Text = "Enter Serialcode First     >>>>>>>>>";
            // 
            // grbAccess
            // 
            grbAccess.Controls.Add(btnAlarmMessages);
            grbAccess.Controls.Add(btnReadWriteSymbolic);
            grbAccess.Controls.Add(btnOptimizedReadWrite);
            grbAccess.Controls.Add(btnReadWriteFunctions);
            grbAccess.Controls.Add(btnDataServer);
            grbAccess.Controls.Add(btnOtherFunctions);
            grbAccess.Controls.Add(btnBlockFunctions);
            grbAccess.Enabled = false;
            grbAccess.Location = new System.Drawing.Point(183, 564);
            grbAccess.Name = "grbAccess";
            grbAccess.Size = new System.Drawing.Size(459, 92);
            grbAccess.TabIndex = 14;
            grbAccess.TabStop = false;
            grbAccess.Text = "Access";
            // 
            // btnAlarmMessages
            // 
            btnAlarmMessages.Image = (System.Drawing.Image)resources.GetObject("btnAlarmMessages.Image");
            btnAlarmMessages.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnAlarmMessages.Location = new System.Drawing.Point(308, 14);
            btnAlarmMessages.Name = "btnAlarmMessages";
            btnAlarmMessages.Size = new System.Drawing.Size(68, 68);
            btnAlarmMessages.TabIndex = 108;
            btnAlarmMessages.Text = "Alarms Messages";
            btnAlarmMessages.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnAlarmMessages.UseVisualStyleBackColor = true;
            btnAlarmMessages.Click += btnAlarm_Click;
            // 
            // btnReadWriteSymbolic
            // 
            btnReadWriteSymbolic.Image = (System.Drawing.Image)resources.GetObject("btnReadWriteSymbolic.Image");
            btnReadWriteSymbolic.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnReadWriteSymbolic.Location = new System.Drawing.Point(17, 15);
            btnReadWriteSymbolic.Name = "btnReadWriteSymbolic";
            btnReadWriteSymbolic.Size = new System.Drawing.Size(68, 68);
            btnReadWriteSymbolic.TabIndex = 107;
            btnReadWriteSymbolic.Text = "read write symbolic";
            btnReadWriteSymbolic.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnReadWriteSymbolic.UseVisualStyleBackColor = true;
            btnReadWriteSymbolic.Visible = false;
            btnReadWriteSymbolic.Click += btnReadWriteSymbolic_Click;
            // 
            // btnOptimizedReadWrite
            // 
            btnOptimizedReadWrite.Image = (System.Drawing.Image)resources.GetObject("btnOptimizedReadWrite.Image");
            btnOptimizedReadWrite.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnOptimizedReadWrite.Location = new System.Drawing.Point(89, 14);
            btnOptimizedReadWrite.Name = "btnOptimizedReadWrite";
            btnOptimizedReadWrite.Size = new System.Drawing.Size(68, 68);
            btnOptimizedReadWrite.TabIndex = 106;
            btnOptimizedReadWrite.Text = "optimize read write";
            btnOptimizedReadWrite.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnOptimizedReadWrite.UseVisualStyleBackColor = true;
            btnOptimizedReadWrite.Click += btnOptimizedReadWriteBox_Click;
            // 
            // btnReadWriteFunctions
            // 
            btnReadWriteFunctions.Image = (System.Drawing.Image)resources.GetObject("btnReadWriteFunctions.Image");
            btnReadWriteFunctions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnReadWriteFunctions.Location = new System.Drawing.Point(17, 15);
            btnReadWriteFunctions.Name = "btnReadWriteFunctions";
            btnReadWriteFunctions.Size = new System.Drawing.Size(68, 68);
            btnReadWriteFunctions.TabIndex = 105;
            btnReadWriteFunctions.Text = "simple \r\nread write";
            btnReadWriteFunctions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnReadWriteFunctions.UseVisualStyleBackColor = true;
            btnReadWriteFunctions.Click += btnReadWriteFunctions_Click;
            // 
            // btnDataServer
            // 
            btnDataServer.Image = (System.Drawing.Image)resources.GetObject("btnDataServer.Image");
            btnDataServer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnDataServer.Location = new System.Drawing.Point(160, 15);
            btnDataServer.Name = "btnDataServer";
            btnDataServer.Size = new System.Drawing.Size(68, 68);
            btnDataServer.TabIndex = 104;
            btnDataServer.Text = "start \r\ndata server";
            btnDataServer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnDataServer.UseVisualStyleBackColor = true;
            btnDataServer.Click += btnDataServer_Click;
            // 
            // btnOtherFunctions
            // 
            btnOtherFunctions.Image = (System.Drawing.Image)resources.GetObject("btnOtherFunctions.Image");
            btnOtherFunctions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnOtherFunctions.Location = new System.Drawing.Point(382, 14);
            btnOtherFunctions.Name = "btnOtherFunctions";
            btnOtherFunctions.Size = new System.Drawing.Size(68, 68);
            btnOtherFunctions.TabIndex = 67;
            btnOtherFunctions.Text = "other functions";
            btnOtherFunctions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnOtherFunctions.UseVisualStyleBackColor = true;
            btnOtherFunctions.Click += btnOtherFunctions_Click;
            // 
            // btnBlockFunctions
            // 
            btnBlockFunctions.Image = (System.Drawing.Image)resources.GetObject("btnBlockFunctions.Image");
            btnBlockFunctions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnBlockFunctions.Location = new System.Drawing.Point(234, 15);
            btnBlockFunctions.Name = "btnBlockFunctions";
            btnBlockFunctions.Size = new System.Drawing.Size(68, 68);
            btnBlockFunctions.TabIndex = 66;
            btnBlockFunctions.Text = "block functions";
            btnBlockFunctions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnBlockFunctions.UseVisualStyleBackColor = true;
            btnBlockFunctions.Click += btnBlockFunctions_Click;
            // 
            // btnClose
            // 
            btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnClose.Location = new System.Drawing.Point(648, 579);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(68, 68);
            btnClose.TabIndex = 91;
            btnClose.Text = "close";
            btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // grbConnectionSettings
            // 
            grbConnectionSettings.Controls.Add(lblAsyncConnect);
            grbConnectionSettings.Controls.Add(chkAsyncConnect);
            grbConnectionSettings.Controls.Add(lblmaxIdleTime);
            grbConnectionSettings.Controls.Add(btnSaveConnectionSettings);
            grbConnectionSettings.Controls.Add(lblAutoConnect2);
            grbConnectionSettings.Controls.Add(grbParams);
            grbConnectionSettings.Controls.Add(grbAddress);
            grbConnectionSettings.Controls.Add(chkAutoConnect);
            grbConnectionSettings.Controls.Add(txtIdleTimeSpan);
            grbConnectionSettings.Enabled = false;
            grbConnectionSettings.Location = new System.Drawing.Point(6, 374);
            grbConnectionSettings.Name = "grbConnectionSettings";
            grbConnectionSettings.Size = new System.Drawing.Size(710, 184);
            grbConnectionSettings.TabIndex = 13;
            grbConnectionSettings.TabStop = false;
            grbConnectionSettings.Text = "Connection settings";
            // 
            // lblAsyncConnect
            // 
            lblAsyncConnect.Location = new System.Drawing.Point(3, 70);
            lblAsyncConnect.Name = "lblAsyncConnect";
            lblAsyncConnect.Size = new System.Drawing.Size(106, 28);
            lblAsyncConnect.TabIndex = 122;
            lblAsyncConnect.Text = "asynchronous connect";
            lblAsyncConnect.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkAsyncConnect
            // 
            chkAsyncConnect.Checked = true;
            chkAsyncConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            chkAsyncConnect.Location = new System.Drawing.Point(143, 69);
            chkAsyncConnect.Name = "chkAsyncConnect";
            chkAsyncConnect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            chkAsyncConnect.Size = new System.Drawing.Size(20, 32);
            chkAsyncConnect.TabIndex = 121;
            chkAsyncConnect.UseVisualStyleBackColor = true;
            // 
            // lblmaxIdleTime
            // 
            lblmaxIdleTime.Location = new System.Drawing.Point(9, 33);
            lblmaxIdleTime.Name = "lblmaxIdleTime";
            lblmaxIdleTime.Size = new System.Drawing.Size(103, 39);
            lblmaxIdleTime.TabIndex = 120;
            lblmaxIdleTime.Text = "max. idle time to close the port";
            lblmaxIdleTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSaveConnectionSettings
            // 
            btnSaveConnectionSettings.Image = (System.Drawing.Image)resources.GetObject("btnSaveConnectionSettings.Image");
            btnSaveConnectionSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveConnectionSettings.Location = new System.Drawing.Point(12, 108);
            btnSaveConnectionSettings.Name = "btnSaveConnectionSettings";
            btnSaveConnectionSettings.Size = new System.Drawing.Size(68, 68);
            btnSaveConnectionSettings.TabIndex = 119;
            btnSaveConnectionSettings.Text = "save settings";
            btnSaveConnectionSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveConnectionSettings.UseVisualStyleBackColor = true;
            btnSaveConnectionSettings.Click += btnSaveConnectionSettings_Click;
            // 
            // lblAutoConnect2
            // 
            lblAutoConnect2.Location = new System.Drawing.Point(6, 19);
            lblAutoConnect2.Name = "lblAutoConnect2";
            lblAutoConnect2.Size = new System.Drawing.Size(106, 13);
            lblAutoConnect2.TabIndex = 104;
            lblAutoConnect2.Text = "auto connect";
            lblAutoConnect2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grbParams
            // 
            grbParams.Controls.Add(btnPlcTypeHelp);
            grbParams.Controls.Add(lblBusSpeed);
            grbParams.Controls.Add(cmbBusspeed);
            grbParams.Controls.Add(lblBaudrate);
            grbParams.Controls.Add(cmbBaudrate);
            grbParams.Controls.Add(lblConnectionType);
            grbParams.Controls.Add(cmbConnectionType);
            grbParams.Controls.Add(cmbPLCType);
            grbParams.Controls.Add(lblPLCType);
            grbParams.Location = new System.Drawing.Point(177, 8);
            grbParams.Name = "grbParams";
            grbParams.Size = new System.Drawing.Size(258, 169);
            grbParams.TabIndex = 30;
            grbParams.TabStop = false;
            grbParams.Text = "Parameter";
            // 
            // btnPlcTypeHelp
            // 
            btnPlcTypeHelp.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnPlcTypeHelp.BackgroundImage");
            btnPlcTypeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnPlcTypeHelp.Location = new System.Drawing.Point(229, 52);
            btnPlcTypeHelp.Name = "btnPlcTypeHelp";
            btnPlcTypeHelp.Size = new System.Drawing.Size(28, 28);
            btnPlcTypeHelp.TabIndex = 123;
            btnPlcTypeHelp.UseVisualStyleBackColor = true;
            btnPlcTypeHelp.Click += btnPlcTypeHelp_Click;
            // 
            // lblBusSpeed
            // 
            lblBusSpeed.AutoSize = true;
            lblBusSpeed.Location = new System.Drawing.Point(9, 136);
            lblBusSpeed.Name = "lblBusSpeed";
            lblBusSpeed.Size = new System.Drawing.Size(54, 13);
            lblBusSpeed.TabIndex = 41;
            lblBusSpeed.Text = "Busspeed";
            // 
            // cmbBusspeed
            // 
            cmbBusspeed.Enabled = false;
            cmbBusspeed.FormattingEnabled = true;
            cmbBusspeed.Location = new System.Drawing.Point(96, 133);
            cmbBusspeed.Name = "cmbBusspeed";
            cmbBusspeed.Size = new System.Drawing.Size(130, 21);
            cmbBusspeed.TabIndex = 40;
            // 
            // lblBaudrate
            // 
            lblBaudrate.AutoSize = true;
            lblBaudrate.Location = new System.Drawing.Point(9, 99);
            lblBaudrate.Name = "lblBaudrate";
            lblBaudrate.Size = new System.Drawing.Size(50, 13);
            lblBaudrate.TabIndex = 39;
            lblBaudrate.Text = "Baudrate";
            // 
            // cmbBaudrate
            // 
            cmbBaudrate.Enabled = false;
            cmbBaudrate.FormattingEnabled = true;
            cmbBaudrate.Location = new System.Drawing.Point(96, 95);
            cmbBaudrate.Name = "cmbBaudrate";
            cmbBaudrate.Size = new System.Drawing.Size(130, 21);
            cmbBaudrate.TabIndex = 38;
            // 
            // lblConnectionType
            // 
            lblConnectionType.AutoSize = true;
            lblConnectionType.Location = new System.Drawing.Point(9, 26);
            lblConnectionType.Name = "lblConnectionType";
            lblConnectionType.Size = new System.Drawing.Size(85, 13);
            lblConnectionType.TabIndex = 37;
            lblConnectionType.Text = "ConnectionType";
            // 
            // cmbConnectionType
            // 
            cmbConnectionType.FormattingEnabled = true;
            cmbConnectionType.Location = new System.Drawing.Point(96, 23);
            cmbConnectionType.Name = "cmbConnectionType";
            cmbConnectionType.Size = new System.Drawing.Size(130, 21);
            cmbConnectionType.TabIndex = 36;
            cmbConnectionType.SelectedIndexChanged += cmbConnectionType_SelectedIndexChanged;
            // 
            // cmbPLCType
            // 
            cmbPLCType.FormattingEnabled = true;
            cmbPLCType.Location = new System.Drawing.Point(96, 57);
            cmbPLCType.Name = "cmbPLCType";
            cmbPLCType.Size = new System.Drawing.Size(130, 21);
            cmbPLCType.TabIndex = 34;
            cmbPLCType.SelectedIndexChanged += cmbPLCType_SelectedIndexChanged;
            // 
            // lblPLCType
            // 
            lblPLCType.AutoSize = true;
            lblPLCType.Location = new System.Drawing.Point(9, 61);
            lblPLCType.Name = "lblPLCType";
            lblPLCType.Size = new System.Drawing.Size(54, 13);
            lblPLCType.TabIndex = 35;
            lblPLCType.Text = "PLC Type";
            // 
            // grbAddress
            // 
            grbAddress.Controls.Add(lblProtectionUser);
            grbAddress.Controls.Add(txtProtectionUser);
            grbAddress.Controls.Add(txtAdress1);
            grbAddress.Controls.Add(lblProtectionPassword);
            grbAddress.Controls.Add(txtAdress2);
            grbAddress.Controls.Add(lblAdress2);
            grbAddress.Controls.Add(txtProtectionPassword);
            grbAddress.Controls.Add(lblAdress1);
            grbAddress.Controls.Add(txtAdress0);
            grbAddress.Controls.Add(txtAdress4);
            grbAddress.Controls.Add(txtAdress3);
            grbAddress.Controls.Add(lblAdress0);
            grbAddress.Controls.Add(lblAdress3);
            grbAddress.Controls.Add(lblAdress4);
            grbAddress.Location = new System.Drawing.Point(441, 9);
            grbAddress.Name = "grbAddress";
            grbAddress.Size = new System.Drawing.Size(263, 169);
            grbAddress.TabIndex = 29;
            grbAddress.TabStop = false;
            grbAddress.Text = "Adress";
            // 
            // lblProtectionUser
            // 
            lblProtectionUser.AutoSize = true;
            lblProtectionUser.Location = new System.Drawing.Point(7, 56);
            lblProtectionUser.Name = "lblProtectionUser";
            lblProtectionUser.Size = new System.Drawing.Size(29, 13);
            lblProtectionUser.TabIndex = 136;
            lblProtectionUser.Text = "User";
            lblProtectionUser.Visible = false;
            // 
            // txtProtectionUser
            // 
            txtProtectionUser.Enabled = false;
            txtProtectionUser.Location = new System.Drawing.Point(148, 53);
            txtProtectionUser.Name = "txtProtectionUser";
            txtProtectionUser.Size = new System.Drawing.Size(105, 20);
            txtProtectionUser.TabIndex = 135;
            txtProtectionUser.Text = "102";
            // 
            // txtAdress1
            // 
            txtAdress1.Enabled = false;
            txtAdress1.Location = new System.Drawing.Point(148, 53);
            txtAdress1.Name = "txtAdress1";
            txtAdress1.Size = new System.Drawing.Size(105, 20);
            txtAdress1.TabIndex = 134;
            txtAdress1.Text = "102";
            // 
            // lblProtectionPassword
            // 
            lblProtectionPassword.AutoSize = true;
            lblProtectionPassword.Location = new System.Drawing.Point(7, 86);
            lblProtectionPassword.Name = "lblProtectionPassword";
            lblProtectionPassword.Size = new System.Drawing.Size(53, 13);
            lblProtectionPassword.TabIndex = 32;
            lblProtectionPassword.Text = "Password";
            lblProtectionPassword.Visible = false;
            // 
            // txtAdress2
            // 
            txtAdress2.Enabled = false;
            txtAdress2.Location = new System.Drawing.Point(148, 83);
            txtAdress2.Name = "txtAdress2";
            txtAdress2.Size = new System.Drawing.Size(105, 20);
            txtAdress2.TabIndex = 29;
            txtAdress2.Text = "0";
            // 
            // lblAdress2
            // 
            lblAdress2.AutoSize = true;
            lblAdress2.Location = new System.Drawing.Point(7, 86);
            lblAdress2.Name = "lblAdress2";
            lblAdress2.Size = new System.Drawing.Size(99, 13);
            lblAdress2.TabIndex = 30;
            lblAdress2.Text = "Local Port (intern 0)";
            // 
            // txtProtectionPassword
            // 
            txtProtectionPassword.Location = new System.Drawing.Point(148, 83);
            txtProtectionPassword.Name = "txtProtectionPassword";
            txtProtectionPassword.PasswordChar = '*';
            txtProtectionPassword.Size = new System.Drawing.Size(105, 20);
            txtProtectionPassword.TabIndex = 133;
            // 
            // lblAdress1
            // 
            lblAdress1.AutoSize = true;
            lblAdress1.Location = new System.Drawing.Point(7, 56);
            lblAdress1.Name = "lblAdress1";
            lblAdress1.Size = new System.Drawing.Size(132, 13);
            lblAdress1.TabIndex = 28;
            lblAdress1.Text = "PLC Port (usually ISO 102)";
            // 
            // txtAdress0
            // 
            txtAdress0.Location = new System.Drawing.Point(148, 24);
            txtAdress0.Name = "txtAdress0";
            txtAdress0.Size = new System.Drawing.Size(105, 20);
            txtAdress0.TabIndex = 8;
            // 
            // txtAdress4
            // 
            txtAdress4.Location = new System.Drawing.Point(148, 142);
            txtAdress4.Name = "txtAdress4";
            txtAdress4.Size = new System.Drawing.Size(105, 20);
            txtAdress4.TabIndex = 26;
            // 
            // txtAdress3
            // 
            txtAdress3.Location = new System.Drawing.Point(148, 113);
            txtAdress3.Name = "txtAdress3";
            txtAdress3.Size = new System.Drawing.Size(105, 20);
            txtAdress3.TabIndex = 25;
            // 
            // lblAdress0
            // 
            lblAdress0.AutoSize = true;
            lblAdress0.Location = new System.Drawing.Point(7, 27);
            lblAdress0.Name = "lblAdress0";
            lblAdress0.Size = new System.Drawing.Size(17, 13);
            lblAdress0.TabIndex = 9;
            lblAdress0.Text = "IP";
            // 
            // lblAdress3
            // 
            lblAdress3.AutoSize = true;
            lblAdress3.Location = new System.Drawing.Point(7, 115);
            lblAdress3.Name = "lblAdress3";
            lblAdress3.Size = new System.Drawing.Size(47, 13);
            lblAdress3.TabIndex = 23;
            lblAdress3.Text = "Rack ID";
            // 
            // lblAdress4
            // 
            lblAdress4.AutoSize = true;
            lblAdress4.Location = new System.Drawing.Point(7, 145);
            lblAdress4.Name = "lblAdress4";
            lblAdress4.Size = new System.Drawing.Size(39, 13);
            lblAdress4.TabIndex = 24;
            lblAdress4.Text = "Slot ID";
            // 
            // chkAutoConnect
            // 
            chkAutoConnect.Location = new System.Drawing.Point(143, 19);
            chkAutoConnect.Name = "chkAutoConnect";
            chkAutoConnect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            chkAutoConnect.Size = new System.Drawing.Size(20, 19);
            chkAutoConnect.TabIndex = 13;
            chkAutoConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkAutoConnect.UseVisualStyleBackColor = true;
            chkAutoConnect.CheckedChanged += chkAutoConnect_CheckedChanged;
            // 
            // txtIdleTimeSpan
            // 
            txtIdleTimeSpan.Enabled = false;
            txtIdleTimeSpan.Location = new System.Drawing.Point(117, 42);
            txtIdleTimeSpan.Name = "txtIdleTimeSpan";
            txtIdleTimeSpan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            txtIdleTimeSpan.Size = new System.Drawing.Size(46, 20);
            txtIdleTimeSpan.TabIndex = 101;
            txtIdleTimeSpan.Text = "10000";
            txtIdleTimeSpan.TextChanged += txtIdeleTimeSpan_TextChanged;
            // 
            // btnConnect
            // 
            btnConnect.Image = (System.Drawing.Image)resources.GetObject("btnConnect.Image");
            btnConnect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnConnect.Location = new System.Drawing.Point(9, 8);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(68, 68);
            btnConnect.TabIndex = 7;
            btnConnect.Text = "connect";
            btnConnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Image = (System.Drawing.Image)resources.GetObject("btnDisconnect.Image");
            btnDisconnect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnDisconnect.Location = new System.Drawing.Point(83, 8);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new System.Drawing.Size(68, 68);
            btnDisconnect.TabIndex = 10;
            btnDisconnect.Text = "disconnect";
            btnDisconnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // panelStatusStrip
            // 
            panelStatusStrip.AutoSize = true;
            panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelStatusStrip.Controls.Add(statusStrip);
            panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelStatusStrip.Location = new System.Drawing.Point(0, 662);
            panelStatusStrip.Name = "panelStatusStrip";
            panelStatusStrip.Size = new System.Drawing.Size(734, 26);
            panelStatusStrip.TabIndex = 92;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = System.Drawing.SystemColors.Control;
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { txtDeviceState, progbarStatusText, ProgressBarProjectImport });
            statusStrip.Location = new System.Drawing.Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(732, 24);
            statusStrip.TabIndex = 93;
            // 
            // txtDeviceState
            // 
            txtDeviceState.BackColor = System.Drawing.Color.White;
            txtDeviceState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            txtDeviceState.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            txtDeviceState.Name = "txtDeviceState";
            txtDeviceState.Size = new System.Drawing.Size(83, 19);
            txtDeviceState.Text = "Disconnected";
            // 
            // progbarStatusText
            // 
            progbarStatusText.BackColor = System.Drawing.Color.White;
            progbarStatusText.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            progbarStatusText.Name = "progbarStatusText";
            progbarStatusText.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            progbarStatusText.Size = new System.Drawing.Size(4, 19);
            progbarStatusText.Visible = false;
            // 
            // ProgressBarProjectImport
            // 
            ProgressBarProjectImport.Name = "ProgressBarProjectImport";
            ProgressBarProjectImport.Size = new System.Drawing.Size(86, 18);
            ProgressBarProjectImport.Visible = false;
            // 
            // btnEditConnectionSettings
            // 
            btnEditConnectionSettings.Image = (System.Drawing.Image)resources.GetObject("btnEditConnectionSettings.Image");
            btnEditConnectionSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnEditConnectionSettings.Location = new System.Drawing.Point(12, 221);
            btnEditConnectionSettings.Name = "btnEditConnectionSettings";
            btnEditConnectionSettings.Size = new System.Drawing.Size(68, 68);
            btnEditConnectionSettings.TabIndex = 103;
            btnEditConnectionSettings.Text = "edit settings";
            btnEditConnectionSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnEditConnectionSettings.UseVisualStyleBackColor = true;
            btnEditConnectionSettings.Click += btnEditConnectionSettings_Click;
            // 
            // lblLanguage
            // 
            lblLanguage.Location = new System.Drawing.Point(195, 224);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new System.Drawing.Size(82, 27);
            lblLanguage.TabIndex = 130;
            lblLanguage.Text = "Sprache / \r\nLanguage";
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new System.Drawing.Point(283, 226);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new System.Drawing.Size(130, 21);
            cmbLanguage.TabIndex = 129;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // grbConnection
            // 
            grbConnection.Controls.Add(btnDisconnect);
            grbConnection.Controls.Add(btnConnect);
            grbConnection.Location = new System.Drawing.Point(6, 570);
            grbConnection.Name = "grbConnection";
            grbConnection.Size = new System.Drawing.Size(154, 84);
            grbConnection.TabIndex = 131;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(491, 219);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(227, 86);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 132;
            pictureBox2.TabStop = false;
            // 
            // lblSerialLimited
            // 
            lblSerialLimited.Location = new System.Drawing.Point(11, 38);
            lblSerialLimited.Name = "lblSerialLimited";
            lblSerialLimited.Size = new System.Drawing.Size(376, 23);
            lblSerialLimited.TabIndex = 105;
            lblSerialLimited.Text = "Note: Without a license key, the runtime is limited to 15 minutes";
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(734, 688);
            Controls.Add(pictureBox2);
            Controls.Add(grbConnection);
            Controls.Add(lblLanguage);
            Controls.Add(btnClose);
            Controls.Add(cmbLanguage);
            Controls.Add(btnEditConnectionSettings);
            Controls.Add(panelStatusStrip);
            Controls.Add(grbSerial);
            Controls.Add(grbAccess);
            Controls.Add(grbConnectionSettings);
            Controls.Add(txtWarning);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            Text = "Start Example";
            FormClosing += main_FormClosing;
            Load += main_Load;
            grbSerial.ResumeLayout(false);
            grbSerial.PerformLayout();
            grbAccess.ResumeLayout(false);
            grbConnectionSettings.ResumeLayout(false);
            grbConnectionSettings.PerformLayout();
            grbParams.ResumeLayout(false);
            grbParams.PerformLayout();
            grbAddress.ResumeLayout(false);
            grbAddress.PerformLayout();
            panelStatusStrip.ResumeLayout(false);
            panelStatusStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            grbConnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtWarning;
        internal System.Windows.Forms.GroupBox grbSerial;
        internal System.Windows.Forms.Label lblSerial;
        internal System.Windows.Forms.Label lblUser;
        internal System.Windows.Forms.TextBox txtSerial;
        internal System.Windows.Forms.TextBox txtUser;
        internal System.Windows.Forms.Label lblSerialCode;
        internal System.Windows.Forms.GroupBox grbAccess;
        private System.Windows.Forms.Button btnOtherFunctions;
        private System.Windows.Forms.Button btnBlockFunctions;
        internal System.Windows.Forms.GroupBox grbConnectionSettings;
        private System.Windows.Forms.TextBox txtAdress4;
        private System.Windows.Forms.TextBox txtAdress3;
        private System.Windows.Forms.Label lblAdress4;
        private System.Windows.Forms.Label lblAdress3;
        internal System.Windows.Forms.Button btnDisconnect;
        internal System.Windows.Forms.Label lblAdress0;
        internal System.Windows.Forms.TextBox txtAdress0;
        internal System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grbAddress;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbParams;
        internal System.Windows.Forms.Label lblBusSpeed;
        internal System.Windows.Forms.ComboBox cmbBusspeed;
        internal System.Windows.Forms.Label lblBaudrate;
        internal System.Windows.Forms.ComboBox cmbBaudrate;
        internal System.Windows.Forms.Label lblConnectionType;
        internal System.Windows.Forms.ComboBox cmbConnectionType;
        internal System.Windows.Forms.ComboBox cmbPLCType;
        internal System.Windows.Forms.Label lblPLCType;
        internal System.Windows.Forms.TextBox txtAdress2;
        internal System.Windows.Forms.Label lblAdress2;

/* Nicht gemergte Änderung aus Projekt "PLCComForS7_TestApp"
Vor:
        internal System.Windows.Forms.TextBox txtAdress1;
        internal System.Windows.Forms.Label lblAdress1;
Nach:
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label lblAdress1;
*/
        internal System.Windows.Forms.Label lblAdress1;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel txtDeviceState;
        private System.Windows.Forms.CheckBox chkAutoConnect;
        internal System.Windows.Forms.TextBox txtIdleTimeSpan;
        internal System.Windows.Forms.Label lblAutoConnect2;
        private System.Windows.Forms.Button btnEditConnectionSettings;
        private System.Windows.Forms.Label lblLanguage;
        internal System.Windows.Forms.ComboBox cmbLanguage;
        internal System.Windows.Forms.Label lblmaxIdleTime;
        private System.Windows.Forms.Button btnSaveConnectionSettings;
        private System.Windows.Forms.Panel grbConnection;
        private System.Windows.Forms.CheckBox chkAsyncConnect;
        internal System.Windows.Forms.Label lblAsyncConnect;
        private System.Windows.Forms.Button btnDataServer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnReadWriteFunctions;
        private System.Windows.Forms.Button btnOptimizedReadWrite;
        private System.Windows.Forms.Button btnReadWriteSymbolic;
        private System.Windows.Forms.ToolStripProgressBar ProgressBarProjectImport;
        private System.Windows.Forms.ToolStripStatusLabel progbarStatusText;
        private System.Windows.Forms.Button btnPlcTypeHelp;
        internal System.Windows.Forms.Label lblProtectionPassword;
        private System.Windows.Forms.MaskedTextBox txtProtectionPassword;
        internal System.Windows.Forms.TextBox txtAdress1;
        internal System.Windows.Forms.TextBox txtProtectionUser;
        internal System.Windows.Forms.Label lblProtectionUser;
        private System.Windows.Forms.Button btnAlarmMessages;
        internal System.Windows.Forms.Label lblSerialLimited;
    }
}

