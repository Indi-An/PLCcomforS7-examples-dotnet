namespace PLCCom_Full_Test_App.Classic
{
    partial class DataServerFunctions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataServerFunctions));
            grpAddress = new System.Windows.Forms.GroupBox();
            lvRequests = new System.Windows.Forms.ListView();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            btnRemoveRequest = new System.Windows.Forms.Button();
            btnAddRequest = new System.Windows.Forms.Button();
            txtInfoDS = new System.Windows.Forms.TextBox();
            grpAction = new System.Windows.Forms.GroupBox();
            btnHelpReadOptMode = new System.Windows.Forms.Button();
            cmbReadOptimizeMode = new System.Windows.Forms.ComboBox();
            lblReadOptimizationMode = new System.Windows.Forms.Label();
            btnStopServer = new System.Windows.Forms.Button();
            chkAutoScroll = new System.Windows.Forms.CheckBox();
            btnSaveLogtoFile = new System.Windows.Forms.Button();
            chkLogging = new System.Windows.Forms.CheckBox();
            lblLogLevel = new System.Windows.Forms.Label();
            btnSaveLogtoClipboard = new System.Windows.Forms.Button();
            cmbLogLevel = new System.Windows.Forms.ComboBox();
            lvLog = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            btnStartServer = new System.Windows.Forms.Button();
            lvValues = new System.Windows.Forms.ListView();
            colDummy = new System.Windows.Forms.ColumnHeader();
            colTimestamp = new System.Windows.Forms.ColumnHeader();
            colRequestGuid = new System.Windows.Forms.ColumnHeader();
            colValue = new System.Windows.Forms.ColumnHeader();
            columnQuality = new System.Windows.Forms.ColumnHeader();
            panelStatusStrip = new System.Windows.Forms.Panel();
            statusStrip = new System.Windows.Forms.StatusStrip();
            txtDeviceState = new System.Windows.Forms.ToolStripStatusLabel();
            lblDeviceType = new System.Windows.Forms.ToolStripStatusLabel();
            btnClose = new System.Windows.Forms.Button();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            btnLoggingSettings = new System.Windows.Forms.Button();
            grbLogSettings = new System.Windows.Forms.GroupBox();
            txtInfoLoggingConnectors = new System.Windows.Forms.TextBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            grpAddress.SuspendLayout();
            grpAction.SuspendLayout();
            panelStatusStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            grbLogSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // grpAddress
            // 
            grpAddress.Controls.Add(lvRequests);
            grpAddress.Controls.Add(btnRemoveRequest);
            grpAddress.Controls.Add(btnAddRequest);
            grpAddress.Location = new System.Drawing.Point(4, 64);
            grpAddress.Name = "grpAddress";
            grpAddress.Size = new System.Drawing.Size(765, 186);
            grpAddress.TabIndex = 87;
            grpAddress.TabStop = false;
            grpAddress.Text = "add read request";
            // 
            // lvRequests
            // 
            lvRequests.Activation = System.Windows.Forms.ItemActivation.OneClick;
            lvRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader3, columnHeader2 });
            lvRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvRequests.FullRowSelect = true;
            lvRequests.Location = new System.Drawing.Point(94, 30);
            lvRequests.Name = "lvRequests";
            lvRequests.Size = new System.Drawing.Size(662, 140);
            lvRequests.TabIndex = 106;
            lvRequests.UseCompatibleStateImageBehavior = false;
            lvRequests.View = System.Windows.Forms.View.Details;
            lvRequests.SelectedIndexChanged += lvRequests_SelectedIndexChanged;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "RequestGuid";
            columnHeader3.Width = 227;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Request";
            columnHeader2.Width = 408;
            // 
            // btnRemoveRequest
            // 
            btnRemoveRequest.Image = (System.Drawing.Image)resources.GetObject("btnRemoveRequest.Image");
            btnRemoveRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnRemoveRequest.Location = new System.Drawing.Point(9, 102);
            btnRemoveRequest.Name = "btnRemoveRequest";
            btnRemoveRequest.Size = new System.Drawing.Size(68, 68);
            btnRemoveRequest.TabIndex = 105;
            btnRemoveRequest.Text = "remove Request";
            btnRemoveRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnRemoveRequest.UseVisualStyleBackColor = true;
            btnRemoveRequest.Click += btnRemoveRequest_Click;
            // 
            // btnAddRequest
            // 
            btnAddRequest.Image = (System.Drawing.Image)resources.GetObject("btnAddRequest.Image");
            btnAddRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnAddRequest.Location = new System.Drawing.Point(9, 28);
            btnAddRequest.Name = "btnAddRequest";
            btnAddRequest.Size = new System.Drawing.Size(68, 68);
            btnAddRequest.TabIndex = 66;
            btnAddRequest.Text = "add Request";
            btnAddRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnAddRequest.UseVisualStyleBackColor = true;
            btnAddRequest.Click += btnAddRequest_Click;
            // 
            // txtInfoDS
            // 
            txtInfoDS.BackColor = System.Drawing.SystemColors.Info;
            txtInfoDS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfoDS.Location = new System.Drawing.Point(50, 3);
            txtInfoDS.Multiline = true;
            txtInfoDS.Name = "txtInfoDS";
            txtInfoDS.ReadOnly = true;
            txtInfoDS.Size = new System.Drawing.Size(406, 53);
            txtInfoDS.TabIndex = 106;
            txtInfoDS.Text = "The PLCCom data server monitors autonomous data in the PLC in an adjustable cycle and notifies the parent software for a change with an event.";
            // 
            // grpAction
            // 
            grpAction.Controls.Add(btnHelpReadOptMode);
            grpAction.Controls.Add(cmbReadOptimizeMode);
            grpAction.Controls.Add(lblReadOptimizationMode);
            grpAction.Controls.Add(btnStopServer);
            grpAction.Controls.Add(chkAutoScroll);
            grpAction.Controls.Add(btnSaveLogtoFile);
            grpAction.Controls.Add(chkLogging);
            grpAction.Controls.Add(lblLogLevel);
            grpAction.Controls.Add(btnSaveLogtoClipboard);
            grpAction.Controls.Add(cmbLogLevel);
            grpAction.Controls.Add(lvLog);
            grpAction.Controls.Add(btnStartServer);
            grpAction.Controls.Add(lvValues);
            grpAction.Location = new System.Drawing.Point(7, 256);
            grpAction.Name = "grpAction";
            grpAction.Size = new System.Drawing.Size(762, 378);
            grpAction.TabIndex = 88;
            grpAction.TabStop = false;
            grpAction.Text = "Results";
            // 
            // btnHelpReadOptMode
            // 
            btnHelpReadOptMode.Image = (System.Drawing.Image)resources.GetObject("btnHelpReadOptMode.Image");
            btnHelpReadOptMode.Location = new System.Drawing.Point(333, 18);
            btnHelpReadOptMode.Name = "btnHelpReadOptMode";
            btnHelpReadOptMode.Size = new System.Drawing.Size(24, 24);
            btnHelpReadOptMode.TabIndex = 140;
            btnHelpReadOptMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnHelpReadOptMode.UseVisualStyleBackColor = true;
            btnHelpReadOptMode.Click += btnHelpReadOptMode_Click;
            // 
            // cmbReadOptimizeMode
            // 
            cmbReadOptimizeMode.FormattingEnabled = true;
            cmbReadOptimizeMode.Location = new System.Drawing.Point(91, 19);
            cmbReadOptimizeMode.Name = "cmbReadOptimizeMode";
            cmbReadOptimizeMode.Size = new System.Drawing.Size(238, 21);
            cmbReadOptimizeMode.TabIndex = 138;
            cmbReadOptimizeMode.SelectedIndexChanged += cmbReadOptimizeMode_SelectedIndexChanged;
            // 
            // lblReadOptimizationMode
            // 
            lblReadOptimizationMode.Location = new System.Drawing.Point(-14, 23);
            lblReadOptimizationMode.Name = "lblReadOptimizationMode";
            lblReadOptimizationMode.Size = new System.Drawing.Size(103, 16);
            lblReadOptimizationMode.TabIndex = 139;
            lblReadOptimizationMode.Text = "read opt. mode";
            lblReadOptimizationMode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnStopServer
            // 
            btnStopServer.Enabled = false;
            btnStopServer.Image = (System.Drawing.Image)resources.GetObject("btnStopServer.Image");
            btnStopServer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnStopServer.Location = new System.Drawing.Point(6, 126);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new System.Drawing.Size(68, 68);
            btnStopServer.TabIndex = 106;
            btnStopServer.Text = "stop\r\ndata server\r\n";
            btnStopServer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += btnStopServer_Click;
            // 
            // chkAutoScroll
            // 
            chkAutoScroll.AutoSize = true;
            chkAutoScroll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkAutoScroll.Checked = true;
            chkAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            chkAutoScroll.Location = new System.Drawing.Point(221, 205);
            chkAutoScroll.Name = "chkAutoScroll";
            chkAutoScroll.Size = new System.Drawing.Size(71, 17);
            chkAutoScroll.TabIndex = 135;
            chkAutoScroll.Text = "AutoScoll";
            chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // btnSaveLogtoFile
            // 
            btnSaveLogtoFile.Image = (System.Drawing.Image)resources.GetObject("btnSaveLogtoFile.Image");
            btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveLogtoFile.Location = new System.Drawing.Point(6, 300);
            btnSaveLogtoFile.Name = "btnSaveLogtoFile";
            btnSaveLogtoFile.Size = new System.Drawing.Size(68, 68);
            btnSaveLogtoFile.TabIndex = 105;
            btnSaveLogtoFile.Text = "save log to file";
            btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveLogtoFile.UseVisualStyleBackColor = true;
            btnSaveLogtoFile.Click += btnSaveLogtoFile_Click;
            // 
            // chkLogging
            // 
            chkLogging.AutoSize = true;
            chkLogging.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkLogging.Checked = true;
            chkLogging.CheckState = System.Windows.Forms.CheckState.Checked;
            chkLogging.Location = new System.Drawing.Point(91, 204);
            chkLogging.Name = "chkLogging";
            chkLogging.Size = new System.Drawing.Size(109, 17);
            chkLogging.TabIndex = 134;
            chkLogging.Text = "Diagnostic output";
            chkLogging.UseVisualStyleBackColor = true;
            // 
            // lblLogLevel
            // 
            lblLogLevel.AutoSize = true;
            lblLogLevel.Location = new System.Drawing.Point(317, 205);
            lblLogLevel.Name = "lblLogLevel";
            lblLogLevel.Size = new System.Drawing.Size(51, 13);
            lblLogLevel.TabIndex = 137;
            lblLogLevel.Text = "LogLevel";
            // 
            // btnSaveLogtoClipboard
            // 
            btnSaveLogtoClipboard.Image = (System.Drawing.Image)resources.GetObject("btnSaveLogtoClipboard.Image");
            btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveLogtoClipboard.Location = new System.Drawing.Point(6, 226);
            btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard";
            btnSaveLogtoClipboard.Size = new System.Drawing.Size(68, 68);
            btnSaveLogtoClipboard.TabIndex = 104;
            btnSaveLogtoClipboard.Text = "copy log in clipboard";
            btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveLogtoClipboard.UseVisualStyleBackColor = true;
            btnSaveLogtoClipboard.Click += btnSaveLogtoClipboard_Click;
            // 
            // cmbLogLevel
            // 
            cmbLogLevel.FormattingEnabled = true;
            cmbLogLevel.Location = new System.Drawing.Point(385, 202);
            cmbLogLevel.Name = "cmbLogLevel";
            cmbLogLevel.Size = new System.Drawing.Size(110, 21);
            cmbLogLevel.TabIndex = 136;
            // 
            // lvLog
            // 
            lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1 });
            lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvLog.Location = new System.Drawing.Point(91, 226);
            lvLog.Name = "lvLog";
            lvLog.Size = new System.Drawing.Size(662, 140);
            lvLog.TabIndex = 98;
            lvLog.UseCompatibleStateImageBehavior = false;
            lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 1000;
            // 
            // btnStartServer
            // 
            btnStartServer.Image = (System.Drawing.Image)resources.GetObject("btnStartServer.Image");
            btnStartServer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnStartServer.Location = new System.Drawing.Point(6, 52);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new System.Drawing.Size(68, 68);
            btnStartServer.TabIndex = 103;
            btnStartServer.Text = "run \r\ndata server";
            btnStartServer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // lvValues
            // 
            lvValues.Activation = System.Windows.Forms.ItemActivation.OneClick;
            lvValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colDummy, colTimestamp, colRequestGuid, colValue, columnQuality });
            lvValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvValues.FullRowSelect = true;
            lvValues.Location = new System.Drawing.Point(91, 52);
            lvValues.Name = "lvValues";
            lvValues.Size = new System.Drawing.Size(662, 140);
            lvValues.TabIndex = 102;
            lvValues.UseCompatibleStateImageBehavior = false;
            lvValues.View = System.Windows.Forms.View.Details;
            // 
            // colDummy
            // 
            colDummy.Text = "";
            colDummy.Width = 0;
            // 
            // colTimestamp
            // 
            colTimestamp.Text = "Timestamp";
            colTimestamp.Width = 100;
            // 
            // colRequestGuid
            // 
            colRequestGuid.Text = "RequestGuid";
            colRequestGuid.Width = 227;
            // 
            // colValue
            // 
            colValue.Text = "Value";
            colValue.Width = 160;
            // 
            // columnQuality
            // 
            columnQuality.Text = "Quality";
            columnQuality.Width = 150;
            // 
            // panelStatusStrip
            // 
            panelStatusStrip.AutoSize = true;
            panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelStatusStrip.Controls.Add(statusStrip);
            panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelStatusStrip.Location = new System.Drawing.Point(0, 735);
            panelStatusStrip.Name = "panelStatusStrip";
            panelStatusStrip.Size = new System.Drawing.Size(784, 26);
            panelStatusStrip.TabIndex = 97;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = System.Drawing.SystemColors.Control;
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { txtDeviceState, lblDeviceType });
            statusStrip.Location = new System.Drawing.Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(782, 24);
            statusStrip.TabIndex = 95;
            // 
            // txtDeviceState
            // 
            txtDeviceState.BackColor = System.Drawing.Color.White;
            txtDeviceState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            txtDeviceState.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            txtDeviceState.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            txtDeviceState.Name = "txtDeviceState";
            txtDeviceState.Size = new System.Drawing.Size(83, 19);
            txtDeviceState.Text = "Disconnected";
            // 
            // lblDeviceType
            // 
            lblDeviceType.BackColor = System.Drawing.Color.White;
            lblDeviceType.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            lblDeviceType.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            lblDeviceType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            lblDeviceType.Name = "lblDeviceType";
            lblDeviceType.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            lblDeviceType.Size = new System.Drawing.Size(77, 19);
            lblDeviceType.Text = "DeviceType: ";
            // 
            // btnClose
            // 
            btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnClose.Location = new System.Drawing.Point(692, 645);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(68, 68);
            btnClose.TabIndex = 99;
            btnClose.Text = "close window";
            btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(4, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(130, 60);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 133;
            pictureBox2.TabStop = false;
            // 
            // btnLoggingSettings
            // 
            btnLoggingSettings.Image = (System.Drawing.Image)resources.GetObject("btnLoggingSettings.Image");
            btnLoggingSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnLoggingSettings.Location = new System.Drawing.Point(6, 9);
            btnLoggingSettings.Name = "btnLoggingSettings";
            btnLoggingSettings.Size = new System.Drawing.Size(68, 68);
            btnLoggingSettings.TabIndex = 138;
            btnLoggingSettings.Text = "logging connectors";
            btnLoggingSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnLoggingSettings.UseVisualStyleBackColor = true;
            btnLoggingSettings.Click += btnLoggingSettings_Click;
            // 
            // grbLogSettings
            // 
            grbLogSettings.Controls.Add(txtInfoLoggingConnectors);
            grbLogSettings.Controls.Add(btnLoggingSettings);
            grbLogSettings.Location = new System.Drawing.Point(7, 640);
            grbLogSettings.Name = "grbLogSettings";
            grbLogSettings.Size = new System.Drawing.Size(495, 80);
            grbLogSettings.TabIndex = 139;
            grbLogSettings.TabStop = false;
            // 
            // txtInfoLoggingConnectors
            // 
            txtInfoLoggingConnectors.BackColor = System.Drawing.SystemColors.Info;
            txtInfoLoggingConnectors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtInfoLoggingConnectors.Location = new System.Drawing.Point(91, 9);
            txtInfoLoggingConnectors.Multiline = true;
            txtInfoLoggingConnectors.Name = "txtInfoLoggingConnectors";
            txtInfoLoggingConnectors.ReadOnly = true;
            txtInfoLoggingConnectors.Size = new System.Drawing.Size(398, 64);
            txtInfoLoggingConnectors.TabIndex = 139;
            txtInfoLoggingConnectors.Text = "‚Logging-Connectors‘ store read variable data to  the file system or a SQL database for further use.\r\nContinuous archiving and saving an Image with just a few rows of code. \r\n";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(6, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(32, 32);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 150;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Info;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(txtInfoDS);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new System.Drawing.Point(177, 5);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(471, 60);
            panel1.TabIndex = 151;
            // 
            // DataServerFunctions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 761);
            Controls.Add(panel1);
            Controls.Add(grbLogSettings);
            Controls.Add(pictureBox2);
            Controls.Add(btnClose);
            Controls.Add(panelStatusStrip);
            Controls.Add(grpAction);
            Controls.Add(grpAddress);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DataServerFunctions";
            Text = "PLCcom Data Server";
            FormClosing += DataServerFunctions_FormClosing;
            Load += DataServerFunctions_Load;
            grpAddress.ResumeLayout(false);
            grpAction.ResumeLayout(false);
            grpAction.PerformLayout();
            panelStatusStrip.ResumeLayout(false);
            panelStatusStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            grbLogSettings.ResumeLayout(false);
            grbLogSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceType;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvValues;
        private System.Windows.Forms.ColumnHeader colDummy;
        private System.Windows.Forms.ColumnHeader colRequestGuid;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Button btnAddRequest;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnRemoveRequest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveLogtoClipboard;
        private System.Windows.Forms.Button btnSaveLogtoFile;
        private System.Windows.Forms.TextBox txtInfoDS;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.ToolStripStatusLabel txtDeviceState;
        private System.Windows.Forms.ColumnHeader colTimestamp;
        private System.Windows.Forms.ColumnHeader columnQuality;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.Label lblLogLevel;
        private System.Windows.Forms.CheckBox chkLogging;
        internal System.Windows.Forms.ComboBox cmbLogLevel;
        private System.Windows.Forms.Button btnLoggingSettings;
        private System.Windows.Forms.GroupBox grbLogSettings;
        private System.Windows.Forms.TextBox txtInfoLoggingConnectors;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ComboBox cmbReadOptimizeMode;
        internal System.Windows.Forms.Label lblReadOptimizationMode;
        private System.Windows.Forms.Button btnHelpReadOptMode;
        private System.Windows.Forms.ListView lvRequests;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}