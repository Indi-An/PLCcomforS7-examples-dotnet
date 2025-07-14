namespace PLCCom_Full_Test_App.Classic
{
    partial class DataServerLoggingSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataServerLoggingSettings));
            grbAddress = new System.Windows.Forms.GroupBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lvConnectors = new System.Windows.Forms.ListView();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            btnAddConnector = new System.Windows.Forms.Button();
            btnRemoveConnector = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            txtInfoCreateListener = new System.Windows.Forms.TextBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            grbNewConnector = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            txtInfoDocu = new System.Windows.Forms.TextBox();
            btnReject = new System.Windows.Forms.Button();
            btnAccept = new System.Windows.Forms.Button();
            lblConnectorType = new System.Windows.Forms.Label();
            cmbConnectorType = new System.Windows.Forms.ComboBox();
            grbDatabaseConnectorSettings = new System.Windows.Forms.GroupBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            lblInfoConnectorNameDB = new System.Windows.Forms.Label();
            lblConnectionMessage = new System.Windows.Forms.Label();
            txtConnectorNameDB = new System.Windows.Forms.TextBox();
            lblConnectorNameDB = new System.Windows.Forms.Label();
            lblIsWriteImageActiveDB = new System.Windows.Forms.Label();
            lblInfoIsWriteLogActiveDB = new System.Windows.Forms.Label();
            lblInfoConnectionString = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            txtSQLConnectionString = new System.Windows.Forms.TextBox();
            lblConnectionString = new System.Windows.Forms.Label();
            chkIsWriteImageActiveDB = new System.Windows.Forms.CheckBox();
            chkIsWriteLogActiveDB = new System.Windows.Forms.CheckBox();
            grbFilesystemConnectorSettings = new System.Windows.Forms.GroupBox();
            lblInfoConnectorName = new System.Windows.Forms.Label();
            txtConnectorName = new System.Windows.Forms.TextBox();
            lblConnectorName = new System.Windows.Forms.Label();
            lblInfoImageOutputFormat = new System.Windows.Forms.Label();
            lblInfoMaxFileSizeMB = new System.Windows.Forms.Label();
            lblInfoMaxAgeHours = new System.Windows.Forms.Label();
            btnFolderName = new System.Windows.Forms.Button();
            txtFolderName = new System.Windows.Forms.TextBox();
            lblInfoMaxNumberOfLogFiles = new System.Windows.Forms.Label();
            lblFolderName = new System.Windows.Forms.Label();
            lblInfoEncryptionPassword = new System.Windows.Forms.Label();
            lblInfoIsWriteImageActive = new System.Windows.Forms.Label();
            lblInfoIsWriteLogActive = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            cmbImageOutputFormat = new System.Windows.Forms.ComboBox();
            lblImageOutputFormat = new System.Windows.Forms.Label();
            txtMaxNumberOfLogFiles = new System.Windows.Forms.TextBox();
            chkIsWriteImageActive = new System.Windows.Forms.CheckBox();
            txtMaxAgeHours = new System.Windows.Forms.TextBox();
            chkIsWriteLogActive = new System.Windows.Forms.CheckBox();
            lblMaxNumberOfLogFiles = new System.Windows.Forms.Label();
            txtEncryptionPassword = new System.Windows.Forms.TextBox();
            lblEncryptionPassword = new System.Windows.Forms.Label();
            txtMaxFileSizeMB = new System.Windows.Forms.TextBox();
            lblMaxAgeHours = new System.Windows.Forms.Label();
            lblMaxFileSizeMB = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            grbAddress.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            grbNewConnector.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            grbDatabaseConnectorSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            grbFilesystemConnectorSettings.SuspendLayout();
            SuspendLayout();
            // 
            // grbAddress
            // 
            grbAddress.Controls.Add(groupBox1);
            grbAddress.Controls.Add(panel1);
            grbAddress.Controls.Add(pictureBox2);
            grbAddress.Controls.Add(grbNewConnector);
            grbAddress.Controls.Add(btnClose);
            grbAddress.Location = new System.Drawing.Point(5, -2);
            grbAddress.Name = "grbAddress";
            grbAddress.Size = new System.Drawing.Size(814, 764);
            grbAddress.TabIndex = 97;
            grbAddress.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lvConnectors);
            groupBox1.Controls.Add(btnAddConnector);
            groupBox1.Controls.Add(btnRemoveConnector);
            groupBox1.Location = new System.Drawing.Point(5, 91);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(809, 171);
            groupBox1.TabIndex = 137;
            groupBox1.TabStop = false;
            // 
            // lvConnectors
            // 
            lvConnectors.Activation = System.Windows.Forms.ItemActivation.OneClick;
            lvConnectors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader2, columnHeader4 });
            lvConnectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvConnectors.FullRowSelect = true;
            lvConnectors.Location = new System.Drawing.Point(108, 19);
            lvConnectors.Name = "lvConnectors";
            lvConnectors.Size = new System.Drawing.Size(692, 140);
            lvConnectors.TabIndex = 107;
            lvConnectors.UseCompatibleStateImageBehavior = false;
            lvConnectors.View = System.Windows.Forms.View.Details;
            lvConnectors.SelectedIndexChanged += lvConnectors_SelectedIndexChanged;
            // 
            // columnHeader2
            // 
            columnHeader2.DisplayIndex = 1;
            columnHeader2.Text = "";
            columnHeader2.Width = 0;
            // 
            // columnHeader4
            // 
            columnHeader4.DisplayIndex = 0;
            columnHeader4.Text = "";
            columnHeader4.Width = 684;
            // 
            // btnAddConnector
            // 
            btnAddConnector.Image = (System.Drawing.Image)resources.GetObject("btnAddConnector.Image");
            btnAddConnector.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnAddConnector.Location = new System.Drawing.Point(28, 19);
            btnAddConnector.Name = "btnAddConnector";
            btnAddConnector.Size = new System.Drawing.Size(68, 68);
            btnAddConnector.TabIndex = 106;
            btnAddConnector.Text = "add connector";
            btnAddConnector.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnAddConnector.UseVisualStyleBackColor = true;
            btnAddConnector.Click += btnAddConnector_Click;
            // 
            // btnRemoveConnector
            // 
            btnRemoveConnector.Enabled = false;
            btnRemoveConnector.Image = (System.Drawing.Image)resources.GetObject("btnRemoveConnector.Image");
            btnRemoveConnector.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnRemoveConnector.Location = new System.Drawing.Point(28, 91);
            btnRemoveConnector.Name = "btnRemoveConnector";
            btnRemoveConnector.Size = new System.Drawing.Size(68, 68);
            btnRemoveConnector.TabIndex = 108;
            btnRemoveConnector.Text = "remove connector";
            btnRemoveConnector.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnRemoveConnector.UseVisualStyleBackColor = true;
            btnRemoveConnector.Click += btnRemoveConnector_Click;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Info;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtInfoCreateListener);
            panel1.Location = new System.Drawing.Point(201, 13);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(600, 75);
            panel1.TabIndex = 136;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.SystemColors.Info;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(5, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(32, 32);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 149;
            pictureBox1.TabStop = false;
            // 
            // txtInfoCreateListener
            // 
            txtInfoCreateListener.BackColor = System.Drawing.SystemColors.Info;
            txtInfoCreateListener.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfoCreateListener.Location = new System.Drawing.Point(45, 5);
            txtInfoCreateListener.Multiline = true;
            txtInfoCreateListener.Name = "txtInfoCreateListener";
            txtInfoCreateListener.ReadOnly = true;
            txtInfoCreateListener.Size = new System.Drawing.Size(550, 65);
            txtInfoCreateListener.TabIndex = 115;
            txtInfoCreateListener.Text = resources.GetString("txtInfoCreateListener.Text");
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(15, 14);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(130, 60);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 135;
            pictureBox2.TabStop = false;
            // 
            // grbNewConnector
            // 
            grbNewConnector.Controls.Add(panel2);
            grbNewConnector.Controls.Add(btnReject);
            grbNewConnector.Controls.Add(btnAccept);
            grbNewConnector.Controls.Add(lblConnectorType);
            grbNewConnector.Controls.Add(cmbConnectorType);
            grbNewConnector.Controls.Add(grbDatabaseConnectorSettings);
            grbNewConnector.Controls.Add(grbFilesystemConnectorSettings);
            grbNewConnector.Enabled = false;
            grbNewConnector.Location = new System.Drawing.Point(5, 261);
            grbNewConnector.Name = "grbNewConnector";
            grbNewConnector.Size = new System.Drawing.Size(808, 422);
            grbNewConnector.TabIndex = 134;
            grbNewConnector.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.Info;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(pictureBox4);
            panel2.Controls.Add(txtInfoDocu);
            panel2.Location = new System.Drawing.Point(316, 10);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(480, 38);
            panel2.TabIndex = 144;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = System.Drawing.SystemColors.Info;
            pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new System.Drawing.Point(5, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(32, 32);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox4.TabIndex = 149;
            pictureBox4.TabStop = false;
            // 
            // txtInfoDocu
            // 
            txtInfoDocu.BackColor = System.Drawing.SystemColors.Info;
            txtInfoDocu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfoDocu.Location = new System.Drawing.Point(45, 5);
            txtInfoDocu.Multiline = true;
            txtInfoDocu.Name = "txtInfoDocu";
            txtInfoDocu.ReadOnly = true;
            txtInfoDocu.Size = new System.Drawing.Size(428, 28);
            txtInfoDocu.TabIndex = 115;
            txtInfoDocu.Text = "You can find help in the document 'Documentation_PLCCom_interface_for_filesystem\r\n.pdf'";
            // 
            // btnReject
            // 
            btnReject.Image = (System.Drawing.Image)resources.GetObject("btnReject.Image");
            btnReject.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnReject.Location = new System.Drawing.Point(728, 348);
            btnReject.Name = "btnReject";
            btnReject.Size = new System.Drawing.Size(68, 68);
            btnReject.TabIndex = 143;
            btnReject.Text = "reject";
            btnReject.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // btnAccept
            // 
            btnAccept.Image = (System.Drawing.Image)resources.GetObject("btnAccept.Image");
            btnAccept.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnAccept.Location = new System.Drawing.Point(654, 348);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new System.Drawing.Size(68, 68);
            btnAccept.TabIndex = 142;
            btnAccept.Text = "accept";
            btnAccept.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // lblConnectorType
            // 
            lblConnectorType.Location = new System.Drawing.Point(7, 23);
            lblConnectorType.Name = "lblConnectorType";
            lblConnectorType.Size = new System.Drawing.Size(139, 18);
            lblConnectorType.TabIndex = 134;
            lblConnectorType.Text = "type of connector";
            lblConnectorType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbConnectorType
            // 
            cmbConnectorType.FormattingEnabled = true;
            cmbConnectorType.Location = new System.Drawing.Point(155, 20);
            cmbConnectorType.Name = "cmbConnectorType";
            cmbConnectorType.Size = new System.Drawing.Size(145, 21);
            cmbConnectorType.TabIndex = 133;
            cmbConnectorType.SelectedIndexChanged += cmbConnectorType_SelectedIndexChanged;
            // 
            // grbDatabaseConnectorSettings
            // 
            grbDatabaseConnectorSettings.Controls.Add(pictureBox3);
            grbDatabaseConnectorSettings.Controls.Add(lblInfoConnectorNameDB);
            grbDatabaseConnectorSettings.Controls.Add(lblConnectionMessage);
            grbDatabaseConnectorSettings.Controls.Add(txtConnectorNameDB);
            grbDatabaseConnectorSettings.Controls.Add(lblConnectorNameDB);
            grbDatabaseConnectorSettings.Controls.Add(lblIsWriteImageActiveDB);
            grbDatabaseConnectorSettings.Controls.Add(lblInfoIsWriteLogActiveDB);
            grbDatabaseConnectorSettings.Controls.Add(lblInfoConnectionString);
            grbDatabaseConnectorSettings.Controls.Add(textBox3);
            grbDatabaseConnectorSettings.Controls.Add(txtSQLConnectionString);
            grbDatabaseConnectorSettings.Controls.Add(lblConnectionString);
            grbDatabaseConnectorSettings.Controls.Add(chkIsWriteImageActiveDB);
            grbDatabaseConnectorSettings.Controls.Add(chkIsWriteLogActiveDB);
            grbDatabaseConnectorSettings.Location = new System.Drawing.Point(7, 43);
            grbDatabaseConnectorSettings.Name = "grbDatabaseConnectorSettings";
            grbDatabaseConnectorSettings.Size = new System.Drawing.Size(797, 298);
            grbDatabaseConnectorSettings.TabIndex = 136;
            grbDatabaseConnectorSettings.TabStop = false;
            grbDatabaseConnectorSettings.Text = "Database connector settings";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = System.Drawing.SystemColors.Info;
            pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new System.Drawing.Point(318, 145);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(32, 32);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 150;
            pictureBox3.TabStop = false;
            // 
            // lblInfoConnectorNameDB
            // 
            lblInfoConnectorNameDB.BackColor = System.Drawing.SystemColors.Info;
            lblInfoConnectorNameDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoConnectorNameDB.Location = new System.Drawing.Point(313, 21);
            lblInfoConnectorNameDB.Name = "lblInfoConnectorNameDB";
            lblInfoConnectorNameDB.Size = new System.Drawing.Size(462, 18);
            lblInfoConnectorNameDB.TabIndex = 148;
            lblInfoConnectorNameDB.Text = "<= The desired name of new connector. Name must be unique";
            // 
            // lblConnectionMessage
            // 
            lblConnectionMessage.BackColor = System.Drawing.SystemColors.Info;
            lblConnectionMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblConnectionMessage.Location = new System.Drawing.Point(364, 142);
            lblConnectionMessage.Name = "lblConnectionMessage";
            lblConnectionMessage.Size = new System.Drawing.Size(419, 146);
            lblConnectionMessage.TabIndex = 145;
            lblConnectionMessage.Text = resources.GetString("lblConnectionMessage.Text");
            // 
            // txtConnectorNameDB
            // 
            txtConnectorNameDB.Location = new System.Drawing.Point(148, 18);
            txtConnectorNameDB.Name = "txtConnectorNameDB";
            txtConnectorNameDB.Size = new System.Drawing.Size(145, 20);
            txtConnectorNameDB.TabIndex = 147;
            // 
            // lblConnectorNameDB
            // 
            lblConnectorNameDB.Location = new System.Drawing.Point(3, 21);
            lblConnectorNameDB.Name = "lblConnectorNameDB";
            lblConnectorNameDB.Size = new System.Drawing.Size(139, 18);
            lblConnectorNameDB.TabIndex = 146;
            lblConnectorNameDB.Text = "new connector name";
            lblConnectorNameDB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblIsWriteImageActiveDB
            // 
            lblIsWriteImageActiveDB.BackColor = System.Drawing.SystemColors.Info;
            lblIsWriteImageActiveDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblIsWriteImageActiveDB.Location = new System.Drawing.Point(313, 111);
            lblIsWriteImageActiveDB.Name = "lblIsWriteImageActiveDB";
            lblIsWriteImageActiveDB.Size = new System.Drawing.Size(462, 28);
            lblIsWriteImageActiveDB.TabIndex = 144;
            lblIsWriteImageActiveDB.Text = "<= Allows you to write the current server data image in the file system for your further use";
            // 
            // lblInfoIsWriteLogActiveDB
            // 
            lblInfoIsWriteLogActiveDB.BackColor = System.Drawing.SystemColors.Info;
            lblInfoIsWriteLogActiveDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoIsWriteLogActiveDB.Location = new System.Drawing.Point(313, 85);
            lblInfoIsWriteLogActiveDB.Name = "lblInfoIsWriteLogActiveDB";
            lblInfoIsWriteLogActiveDB.Size = new System.Drawing.Size(462, 18);
            lblInfoIsWriteLogActiveDB.TabIndex = 143;
            lblInfoIsWriteLogActiveDB.Text = "<= Turns data output in a log archive on or off";
            // 
            // lblInfoConnectionString
            // 
            lblInfoConnectionString.BackColor = System.Drawing.SystemColors.Info;
            lblInfoConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoConnectionString.Location = new System.Drawing.Point(313, 50);
            lblInfoConnectionString.Name = "lblInfoConnectionString";
            lblInfoConnectionString.Size = new System.Drawing.Size(462, 27);
            lblInfoConnectionString.TabIndex = 142;
            lblInfoConnectionString.Text = "<= The connection string for the database connection. \r\n      In this example, only MS SQL Server";
            // 
            // textBox3
            // 
            textBox3.BackColor = System.Drawing.SystemColors.Info;
            textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox3.Location = new System.Drawing.Point(309, 13);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(480, 277);
            textBox3.TabIndex = 141;
            // 
            // txtSQLConnectionString
            // 
            txtSQLConnectionString.Location = new System.Drawing.Point(148, 42);
            txtSQLConnectionString.Multiline = true;
            txtSQLConnectionString.Name = "txtSQLConnectionString";
            txtSQLConnectionString.Size = new System.Drawing.Size(145, 35);
            txtSQLConnectionString.TabIndex = 117;
            txtSQLConnectionString.Text = "Server = server2; Database = plccom; Trusted_Connection = True;";
            // 
            // lblConnectionString
            // 
            lblConnectionString.Location = new System.Drawing.Point(8, 50);
            lblConnectionString.Name = "lblConnectionString";
            lblConnectionString.Size = new System.Drawing.Size(136, 28);
            lblConnectionString.TabIndex = 118;
            lblConnectionString.Text = "MSSQL- ConnectionString";
            lblConnectionString.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkIsWriteImageActiveDB
            // 
            chkIsWriteImageActiveDB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkIsWriteImageActiveDB.Checked = true;
            chkIsWriteImageActiveDB.CheckState = System.Windows.Forms.CheckState.Checked;
            chkIsWriteImageActiveDB.Location = new System.Drawing.Point(11, 107);
            chkIsWriteImageActiveDB.Name = "chkIsWriteImageActiveDB";
            chkIsWriteImageActiveDB.Size = new System.Drawing.Size(150, 24);
            chkIsWriteImageActiveDB.TabIndex = 115;
            chkIsWriteImageActiveDB.Text = "isWriteImageActive";
            chkIsWriteImageActiveDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkIsWriteImageActiveDB.UseVisualStyleBackColor = true;
            // 
            // chkIsWriteLogActiveDB
            // 
            chkIsWriteLogActiveDB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkIsWriteLogActiveDB.Checked = true;
            chkIsWriteLogActiveDB.CheckState = System.Windows.Forms.CheckState.Checked;
            chkIsWriteLogActiveDB.Location = new System.Drawing.Point(11, 79);
            chkIsWriteLogActiveDB.Name = "chkIsWriteLogActiveDB";
            chkIsWriteLogActiveDB.Size = new System.Drawing.Size(150, 24);
            chkIsWriteLogActiveDB.TabIndex = 113;
            chkIsWriteLogActiveDB.Text = "isWriteLogActive";
            chkIsWriteLogActiveDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkIsWriteLogActiveDB.UseVisualStyleBackColor = true;
            // 
            // grbFilesystemConnectorSettings
            // 
            grbFilesystemConnectorSettings.Controls.Add(lblInfoConnectorName);
            grbFilesystemConnectorSettings.Controls.Add(txtConnectorName);
            grbFilesystemConnectorSettings.Controls.Add(lblConnectorName);
            grbFilesystemConnectorSettings.Controls.Add(lblInfoImageOutputFormat);
            grbFilesystemConnectorSettings.Controls.Add(lblInfoMaxFileSizeMB);
            grbFilesystemConnectorSettings.Controls.Add(lblInfoMaxAgeHours);
            grbFilesystemConnectorSettings.Controls.Add(btnFolderName);
            grbFilesystemConnectorSettings.Controls.Add(txtFolderName);
            grbFilesystemConnectorSettings.Controls.Add(lblInfoMaxNumberOfLogFiles);
            grbFilesystemConnectorSettings.Controls.Add(lblFolderName);
            grbFilesystemConnectorSettings.Controls.Add(lblInfoEncryptionPassword);
            grbFilesystemConnectorSettings.Controls.Add(lblInfoIsWriteImageActive);
            grbFilesystemConnectorSettings.Controls.Add(lblInfoIsWriteLogActive);
            grbFilesystemConnectorSettings.Controls.Add(textBox2);
            grbFilesystemConnectorSettings.Controls.Add(cmbImageOutputFormat);
            grbFilesystemConnectorSettings.Controls.Add(lblImageOutputFormat);
            grbFilesystemConnectorSettings.Controls.Add(txtMaxNumberOfLogFiles);
            grbFilesystemConnectorSettings.Controls.Add(chkIsWriteImageActive);
            grbFilesystemConnectorSettings.Controls.Add(txtMaxAgeHours);
            grbFilesystemConnectorSettings.Controls.Add(chkIsWriteLogActive);
            grbFilesystemConnectorSettings.Controls.Add(lblMaxNumberOfLogFiles);
            grbFilesystemConnectorSettings.Controls.Add(txtEncryptionPassword);
            grbFilesystemConnectorSettings.Controls.Add(lblEncryptionPassword);
            grbFilesystemConnectorSettings.Controls.Add(txtMaxFileSizeMB);
            grbFilesystemConnectorSettings.Controls.Add(lblMaxAgeHours);
            grbFilesystemConnectorSettings.Controls.Add(lblMaxFileSizeMB);
            grbFilesystemConnectorSettings.Location = new System.Drawing.Point(7, 43);
            grbFilesystemConnectorSettings.Name = "grbFilesystemConnectorSettings";
            grbFilesystemConnectorSettings.Size = new System.Drawing.Size(797, 298);
            grbFilesystemConnectorSettings.TabIndex = 135;
            grbFilesystemConnectorSettings.TabStop = false;
            grbFilesystemConnectorSettings.Text = "Filesystem connector settings";
            // 
            // lblInfoConnectorName
            // 
            lblInfoConnectorName.BackColor = System.Drawing.SystemColors.Info;
            lblInfoConnectorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoConnectorName.Location = new System.Drawing.Point(313, 50);
            lblInfoConnectorName.Name = "lblInfoConnectorName";
            lblInfoConnectorName.Size = new System.Drawing.Size(462, 18);
            lblInfoConnectorName.TabIndex = 141;
            lblInfoConnectorName.Text = "<= The desired name of new connector. Name must be unique";
            // 
            // txtConnectorName
            // 
            txtConnectorName.Location = new System.Drawing.Point(148, 47);
            txtConnectorName.Name = "txtConnectorName";
            txtConnectorName.Size = new System.Drawing.Size(145, 20);
            txtConnectorName.TabIndex = 111;
            // 
            // lblConnectorName
            // 
            lblConnectorName.Location = new System.Drawing.Point(3, 50);
            lblConnectorName.Name = "lblConnectorName";
            lblConnectorName.Size = new System.Drawing.Size(139, 18);
            lblConnectorName.TabIndex = 112;
            lblConnectorName.Text = "new connector name";
            lblConnectorName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblInfoImageOutputFormat
            // 
            lblInfoImageOutputFormat.BackColor = System.Drawing.SystemColors.Info;
            lblInfoImageOutputFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoImageOutputFormat.Location = new System.Drawing.Point(313, 257);
            lblInfoImageOutputFormat.Name = "lblInfoImageOutputFormat";
            lblInfoImageOutputFormat.Size = new System.Drawing.Size(462, 26);
            lblInfoImageOutputFormat.TabIndex = 140;
            lblInfoImageOutputFormat.Text = "<= You can output the data for the image in shallow .dat format (csv) or in .xml format";
            // 
            // lblInfoMaxFileSizeMB
            // 
            lblInfoMaxFileSizeMB.BackColor = System.Drawing.SystemColors.Info;
            lblInfoMaxFileSizeMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoMaxFileSizeMB.Location = new System.Drawing.Point(313, 224);
            lblInfoMaxFileSizeMB.Name = "lblInfoMaxFileSizeMB";
            lblInfoMaxFileSizeMB.Size = new System.Drawing.Size(462, 26);
            lblInfoMaxFileSizeMB.TabIndex = 139;
            lblInfoMaxFileSizeMB.Text = "<= You can restrict the maximum size of files. \r\n     When the value is exceeded the old files are automatically deleted. -1 = Disabled.";
            // 
            // lblInfoMaxAgeHours
            // 
            lblInfoMaxAgeHours.BackColor = System.Drawing.SystemColors.Info;
            lblInfoMaxAgeHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoMaxAgeHours.Location = new System.Drawing.Point(313, 191);
            lblInfoMaxAgeHours.Name = "lblInfoMaxAgeHours";
            lblInfoMaxAgeHours.Size = new System.Drawing.Size(462, 26);
            lblInfoMaxAgeHours.TabIndex = 138;
            lblInfoMaxAgeHours.Text = "<= You can restrict the maximum age of files. \r\n     When the value is exceeded the old files are automatically deleted. -1 = Disabled.";
            // 
            // btnFolderName
            // 
            btnFolderName.Location = new System.Drawing.Point(768, 16);
            btnFolderName.Name = "btnFolderName";
            btnFolderName.Size = new System.Drawing.Size(21, 23);
            btnFolderName.TabIndex = 131;
            btnFolderName.Text = "...";
            btnFolderName.UseVisualStyleBackColor = true;
            btnFolderName.Click += btnFolderName_Click;
            // 
            // txtFolderName
            // 
            txtFolderName.Location = new System.Drawing.Point(148, 18);
            txtFolderName.Name = "txtFolderName";
            txtFolderName.Size = new System.Drawing.Size(614, 20);
            txtFolderName.TabIndex = 117;
            // 
            // lblInfoMaxNumberOfLogFiles
            // 
            lblInfoMaxNumberOfLogFiles.BackColor = System.Drawing.SystemColors.Info;
            lblInfoMaxNumberOfLogFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoMaxNumberOfLogFiles.Location = new System.Drawing.Point(313, 161);
            lblInfoMaxNumberOfLogFiles.Name = "lblInfoMaxNumberOfLogFiles";
            lblInfoMaxNumberOfLogFiles.Size = new System.Drawing.Size(462, 31);
            lblInfoMaxNumberOfLogFiles.TabIndex = 137;
            lblInfoMaxNumberOfLogFiles.Text = "<= You can restrict the maximum number of files. \r\n     When the value is exceeded the old files are automatically deleted. -1 = Disabled.";
            // 
            // lblFolderName
            // 
            lblFolderName.Location = new System.Drawing.Point(5, 21);
            lblFolderName.Name = "lblFolderName";
            lblFolderName.Size = new System.Drawing.Size(134, 18);
            lblFolderName.TabIndex = 118;
            lblFolderName.Text = "target folder";
            lblFolderName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblInfoEncryptionPassword
            // 
            lblInfoEncryptionPassword.BackColor = System.Drawing.SystemColors.Info;
            lblInfoEncryptionPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoEncryptionPassword.Location = new System.Drawing.Point(313, 130);
            lblInfoEncryptionPassword.Name = "lblInfoEncryptionPassword";
            lblInfoEncryptionPassword.Size = new System.Drawing.Size(462, 30);
            lblInfoEncryptionPassword.TabIndex = 136;
            lblInfoEncryptionPassword.Text = "<= If you enter an encryption password, the data is stored in encrypted form. \r\n     You can read the data using the supplied decryption tool again.";
            // 
            // lblInfoIsWriteImageActive
            // 
            lblInfoIsWriteImageActive.BackColor = System.Drawing.SystemColors.Info;
            lblInfoIsWriteImageActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoIsWriteImageActive.Location = new System.Drawing.Point(313, 97);
            lblInfoIsWriteImageActive.Name = "lblInfoIsWriteImageActive";
            lblInfoIsWriteImageActive.Size = new System.Drawing.Size(462, 29);
            lblInfoIsWriteImageActive.TabIndex = 135;
            lblInfoIsWriteImageActive.Text = "<= Allows you to write the current server data image in the file system for your further use";
            // 
            // lblInfoIsWriteLogActive
            // 
            lblInfoIsWriteLogActive.BackColor = System.Drawing.SystemColors.Info;
            lblInfoIsWriteLogActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInfoIsWriteLogActive.Location = new System.Drawing.Point(313, 75);
            lblInfoIsWriteLogActive.Name = "lblInfoIsWriteLogActive";
            lblInfoIsWriteLogActive.Size = new System.Drawing.Size(462, 18);
            lblInfoIsWriteLogActive.TabIndex = 134;
            lblInfoIsWriteLogActive.Text = "<= Turns data output in a log archive on or off";
            // 
            // textBox2
            // 
            textBox2.BackColor = System.Drawing.SystemColors.Info;
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox2.Location = new System.Drawing.Point(309, 42);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(480, 247);
            textBox2.TabIndex = 132;
            // 
            // cmbImageOutputFormat
            // 
            cmbImageOutputFormat.FormattingEnabled = true;
            cmbImageOutputFormat.Location = new System.Drawing.Point(148, 254);
            cmbImageOutputFormat.Name = "cmbImageOutputFormat";
            cmbImageOutputFormat.Size = new System.Drawing.Size(145, 21);
            cmbImageOutputFormat.TabIndex = 125;
            // 
            // lblImageOutputFormat
            // 
            lblImageOutputFormat.Location = new System.Drawing.Point(11, 254);
            lblImageOutputFormat.Name = "lblImageOutputFormat";
            lblImageOutputFormat.Size = new System.Drawing.Size(128, 18);
            lblImageOutputFormat.TabIndex = 126;
            lblImageOutputFormat.Text = "image output format";
            lblImageOutputFormat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMaxNumberOfLogFiles
            // 
            txtMaxNumberOfLogFiles.Location = new System.Drawing.Point(148, 159);
            txtMaxNumberOfLogFiles.Name = "txtMaxNumberOfLogFiles";
            txtMaxNumberOfLogFiles.Size = new System.Drawing.Size(145, 20);
            txtMaxNumberOfLogFiles.TabIndex = 129;
            txtMaxNumberOfLogFiles.Text = "-1";
            // 
            // chkIsWriteImageActive
            // 
            chkIsWriteImageActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkIsWriteImageActive.Checked = true;
            chkIsWriteImageActive.CheckState = System.Windows.Forms.CheckState.Checked;
            chkIsWriteImageActive.Location = new System.Drawing.Point(11, 100);
            chkIsWriteImageActive.Name = "chkIsWriteImageActive";
            chkIsWriteImageActive.Size = new System.Drawing.Size(150, 17);
            chkIsWriteImageActive.TabIndex = 115;
            chkIsWriteImageActive.Text = "isWriteImageActive";
            chkIsWriteImageActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkIsWriteImageActive.UseVisualStyleBackColor = true;
            chkIsWriteImageActive.CheckedChanged += chkIsWriteImageActive_CheckedChanged;
            // 
            // txtMaxAgeHours
            // 
            txtMaxAgeHours.Location = new System.Drawing.Point(148, 189);
            txtMaxAgeHours.Name = "txtMaxAgeHours";
            txtMaxAgeHours.Size = new System.Drawing.Size(145, 20);
            txtMaxAgeHours.TabIndex = 119;
            txtMaxAgeHours.Text = "-1";
            // 
            // chkIsWriteLogActive
            // 
            chkIsWriteLogActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkIsWriteLogActive.Checked = true;
            chkIsWriteLogActive.CheckState = System.Windows.Forms.CheckState.Checked;
            chkIsWriteLogActive.Location = new System.Drawing.Point(11, 68);
            chkIsWriteLogActive.Name = "chkIsWriteLogActive";
            chkIsWriteLogActive.Size = new System.Drawing.Size(150, 24);
            chkIsWriteLogActive.TabIndex = 113;
            chkIsWriteLogActive.Text = "isWriteLogActive";
            chkIsWriteLogActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkIsWriteLogActive.UseVisualStyleBackColor = true;
            chkIsWriteLogActive.CheckedChanged += chkIsWriteLogActive_CheckedChanged;
            // 
            // lblMaxNumberOfLogFiles
            // 
            lblMaxNumberOfLogFiles.Location = new System.Drawing.Point(11, 161);
            lblMaxNumberOfLogFiles.Name = "lblMaxNumberOfLogFiles";
            lblMaxNumberOfLogFiles.Size = new System.Drawing.Size(128, 18);
            lblMaxNumberOfLogFiles.TabIndex = 130;
            lblMaxNumberOfLogFiles.Text = "max number of log files";
            lblMaxNumberOfLogFiles.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtEncryptionPassword
            // 
            txtEncryptionPassword.Location = new System.Drawing.Point(148, 128);
            txtEncryptionPassword.Name = "txtEncryptionPassword";
            txtEncryptionPassword.Size = new System.Drawing.Size(145, 20);
            txtEncryptionPassword.TabIndex = 123;
            // 
            // lblEncryptionPassword
            // 
            lblEncryptionPassword.Location = new System.Drawing.Point(11, 125);
            lblEncryptionPassword.Name = "lblEncryptionPassword";
            lblEncryptionPassword.Size = new System.Drawing.Size(131, 32);
            lblEncryptionPassword.TabIndex = 124;
            lblEncryptionPassword.Text = "encryption password\r\n (empty = no encrypting)";
            lblEncryptionPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMaxFileSizeMB
            // 
            txtMaxFileSizeMB.Location = new System.Drawing.Point(148, 222);
            txtMaxFileSizeMB.Name = "txtMaxFileSizeMB";
            txtMaxFileSizeMB.Size = new System.Drawing.Size(145, 20);
            txtMaxFileSizeMB.TabIndex = 121;
            txtMaxFileSizeMB.Text = "-1";
            // 
            // lblMaxAgeHours
            // 
            lblMaxAgeHours.Location = new System.Drawing.Point(14, 189);
            lblMaxAgeHours.Name = "lblMaxAgeHours";
            lblMaxAgeHours.Size = new System.Drawing.Size(125, 18);
            lblMaxAgeHours.TabIndex = 120;
            lblMaxAgeHours.Text = "max age in hours";
            lblMaxAgeHours.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMaxFileSizeMB
            // 
            lblMaxFileSizeMB.Location = new System.Drawing.Point(11, 224);
            lblMaxFileSizeMB.Name = "lblMaxFileSizeMB";
            lblMaxFileSizeMB.Size = new System.Drawing.Size(128, 18);
            lblMaxFileSizeMB.TabIndex = 122;
            lblMaxFileSizeMB.Text = "max file size in MB";
            lblMaxFileSizeMB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnClose
            // 
            btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnClose.Location = new System.Drawing.Point(733, 688);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(68, 68);
            btnClose.TabIndex = 133;
            btnClose.Text = "close window";
            btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // DataServerLoggingSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(822, 766);
            Controls.Add(grbAddress);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DataServerLoggingSettings";
            Text = "create new logging connector";
            Load += DataServerLoggingSettings_Load;
            grbAddress.ResumeLayout(false);
            grbAddress.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            grbNewConnector.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            grbDatabaseConnectorSettings.ResumeLayout(false);
            grbDatabaseConnectorSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            grbFilesystemConnectorSettings.ResumeLayout(false);
            grbFilesystemConnectorSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grbAddress;
        private System.Windows.Forms.TextBox txtInfoCreateListener;
        private System.Windows.Forms.Button btnRemoveConnector;
        private System.Windows.Forms.ListView lvConnectors;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnAddConnector;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbNewConnector;
        private System.Windows.Forms.GroupBox grbFilesystemConnectorSettings;
        private System.Windows.Forms.Label lblInfoConnectorName;
        internal System.Windows.Forms.TextBox txtConnectorName;
        internal System.Windows.Forms.Label lblConnectorName;
        private System.Windows.Forms.Label lblInfoImageOutputFormat;
        private System.Windows.Forms.Label lblInfoMaxFileSizeMB;
        private System.Windows.Forms.Label lblInfoMaxAgeHours;
        private System.Windows.Forms.Label lblInfoMaxNumberOfLogFiles;
        private System.Windows.Forms.Label lblInfoEncryptionPassword;
        private System.Windows.Forms.Label lblInfoIsWriteImageActive;
        private System.Windows.Forms.Label lblInfoIsWriteLogActive;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnFolderName;
        internal System.Windows.Forms.TextBox txtFolderName;
        internal System.Windows.Forms.ComboBox cmbImageOutputFormat;
        internal System.Windows.Forms.Label lblImageOutputFormat;
        internal System.Windows.Forms.TextBox txtMaxNumberOfLogFiles;
        internal System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.CheckBox chkIsWriteImageActive;
        internal System.Windows.Forms.TextBox txtMaxAgeHours;
        private System.Windows.Forms.CheckBox chkIsWriteLogActive;
        internal System.Windows.Forms.Label lblMaxNumberOfLogFiles;
        internal System.Windows.Forms.TextBox txtEncryptionPassword;
        internal System.Windows.Forms.Label lblEncryptionPassword;
        internal System.Windows.Forms.TextBox txtMaxFileSizeMB;
        internal System.Windows.Forms.Label lblMaxAgeHours;
        internal System.Windows.Forms.Label lblMaxFileSizeMB;
        internal System.Windows.Forms.Label lblConnectorType;
        internal System.Windows.Forms.ComboBox cmbConnectorType;
        private System.Windows.Forms.GroupBox grbDatabaseConnectorSettings;
        private System.Windows.Forms.Label lblInfoConnectorNameDB;
        internal System.Windows.Forms.TextBox txtConnectorNameDB;
        internal System.Windows.Forms.Label lblConnectorNameDB;
        private System.Windows.Forms.Label lblConnectionMessage;
        private System.Windows.Forms.Label lblIsWriteImageActiveDB;
        private System.Windows.Forms.Label lblInfoIsWriteLogActiveDB;
        private System.Windows.Forms.Label lblInfoConnectionString;
        private System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.TextBox txtSQLConnectionString;
        internal System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.CheckBox chkIsWriteImageActiveDB;
        private System.Windows.Forms.CheckBox chkIsWriteLogActiveDB;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtInfoDocu;
    }
}