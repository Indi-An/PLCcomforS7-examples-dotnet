namespace PLCCom_Full_Test_App.Classic
{
    partial class OtherFunctions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtherFunctions));
            grpAction = new System.Windows.Forms.GroupBox();
            lvValues = new System.Windows.Forms.ListView();
            colDummy = new System.Windows.Forms.ColumnHeader();
            colValue = new System.Windows.Forms.ColumnHeader();
            btnReadSSL_SZL = new System.Windows.Forms.Button();
            btnDiagnoseBuffer = new System.Windows.Forms.Button();
            btnBasicInfo = new System.Windows.Forms.Button();
            btnCPUMode = new System.Windows.Forms.Button();
            btnStartPLC = new System.Windows.Forms.Button();
            btnPLCLEDInfo = new System.Windows.Forms.Button();
            btnsetPLCTime = new System.Windows.Forms.Button();
            btnStopPLC = new System.Windows.Forms.Button();
            btnGetPLCTime = new System.Windows.Forms.Button();
            panelStatusStrip = new System.Windows.Forms.Panel();
            statusStrip = new System.Windows.Forms.StatusStrip();
            lblDeviceType = new System.Windows.Forms.ToolStripStatusLabel();
            btnSaveLogtoFile = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            btnSaveLogtoClipboard = new System.Windows.Forms.Button();
            lvLog = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            lblLog = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            txtInfoOF = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            grpAction.SuspendLayout();
            panelStatusStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // grpAction
            // 
            grpAction.Controls.Add(lvValues);
            grpAction.Controls.Add(btnReadSSL_SZL);
            grpAction.Controls.Add(btnDiagnoseBuffer);
            grpAction.Controls.Add(btnBasicInfo);
            grpAction.Controls.Add(btnCPUMode);
            grpAction.Controls.Add(btnStartPLC);
            grpAction.Controls.Add(btnPLCLEDInfo);
            grpAction.Controls.Add(btnsetPLCTime);
            grpAction.Controls.Add(btnStopPLC);
            grpAction.Controls.Add(btnGetPLCTime);
            grpAction.Location = new System.Drawing.Point(12, 67);
            grpAction.Name = "grpAction";
            grpAction.Size = new System.Drawing.Size(682, 460);
            grpAction.TabIndex = 98;
            grpAction.TabStop = false;
            grpAction.Text = "Action";
            // 
            // lvValues
            // 
            lvValues.Activation = System.Windows.Forms.ItemActivation.OneClick;
            lvValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colDummy, colValue });
            lvValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvValues.FullRowSelect = true;
            lvValues.Location = new System.Drawing.Point(183, 14);
            lvValues.Name = "lvValues";
            lvValues.Size = new System.Drawing.Size(485, 438);
            lvValues.TabIndex = 118;
            lvValues.UseCompatibleStateImageBehavior = false;
            lvValues.View = System.Windows.Forms.View.Details;
            // 
            // colDummy
            // 
            colDummy.Text = "";
            colDummy.Width = 0;
            // 
            // colValue
            // 
            colValue.Text = "Values";
            colValue.Width = 460;
            // 
            // btnReadSSL_SZL
            // 
            btnReadSSL_SZL.Image = (System.Drawing.Image)resources.GetObject("btnReadSSL_SZL.Image");
            btnReadSSL_SZL.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnReadSSL_SZL.Location = new System.Drawing.Point(21, 310);
            btnReadSSL_SZL.Name = "btnReadSSL_SZL";
            btnReadSSL_SZL.Size = new System.Drawing.Size(68, 68);
            btnReadSSL_SZL.TabIndex = 71;
            btnReadSSL_SZL.Text = "read SSL/SZL";
            btnReadSSL_SZL.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnReadSSL_SZL.UseVisualStyleBackColor = true;
            btnReadSSL_SZL.Click += btnReadSSL_SZL_Click;
            // 
            // btnDiagnoseBuffer
            // 
            btnDiagnoseBuffer.Image = (System.Drawing.Image)resources.GetObject("btnDiagnoseBuffer.Image");
            btnDiagnoseBuffer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnDiagnoseBuffer.Location = new System.Drawing.Point(21, 384);
            btnDiagnoseBuffer.Name = "btnDiagnoseBuffer";
            btnDiagnoseBuffer.Size = new System.Drawing.Size(68, 68);
            btnDiagnoseBuffer.TabIndex = 70;
            btnDiagnoseBuffer.Text = "diagnostic data";
            btnDiagnoseBuffer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnDiagnoseBuffer.UseVisualStyleBackColor = true;
            btnDiagnoseBuffer.Click += btnDiagnoseBuffer_Click;
            // 
            // btnBasicInfo
            // 
            btnBasicInfo.Image = (System.Drawing.Image)resources.GetObject("btnBasicInfo.Image");
            btnBasicInfo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnBasicInfo.Location = new System.Drawing.Point(21, 162);
            btnBasicInfo.Name = "btnBasicInfo";
            btnBasicInfo.Size = new System.Drawing.Size(68, 68);
            btnBasicInfo.TabIndex = 65;
            btnBasicInfo.Text = "PLC Basic Info";
            btnBasicInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnBasicInfo.UseVisualStyleBackColor = true;
            btnBasicInfo.Click += btnBasicInfo_Click;
            // 
            // btnCPUMode
            // 
            btnCPUMode.Image = (System.Drawing.Image)resources.GetObject("btnCPUMode.Image");
            btnCPUMode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnCPUMode.Location = new System.Drawing.Point(95, 162);
            btnCPUMode.Name = "btnCPUMode";
            btnCPUMode.Size = new System.Drawing.Size(68, 68);
            btnCPUMode.TabIndex = 64;
            btnCPUMode.Text = "get CPU Mode";
            btnCPUMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnCPUMode.UseVisualStyleBackColor = true;
            btnCPUMode.Click += btnCPUMode_Click;
            // 
            // btnStartPLC
            // 
            btnStartPLC.Image = (System.Drawing.Image)resources.GetObject("btnStartPLC.Image");
            btnStartPLC.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnStartPLC.Location = new System.Drawing.Point(21, 14);
            btnStartPLC.Name = "btnStartPLC";
            btnStartPLC.Size = new System.Drawing.Size(68, 68);
            btnStartPLC.TabIndex = 69;
            btnStartPLC.Text = "Start PLC";
            btnStartPLC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnStartPLC.UseVisualStyleBackColor = true;
            btnStartPLC.Click += btnStartPLC_Click;
            // 
            // btnPLCLEDInfo
            // 
            btnPLCLEDInfo.Image = (System.Drawing.Image)resources.GetObject("btnPLCLEDInfo.Image");
            btnPLCLEDInfo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnPLCLEDInfo.Location = new System.Drawing.Point(21, 236);
            btnPLCLEDInfo.Name = "btnPLCLEDInfo";
            btnPLCLEDInfo.Size = new System.Drawing.Size(68, 68);
            btnPLCLEDInfo.TabIndex = 63;
            btnPLCLEDInfo.Text = "get PLC LED Info";
            btnPLCLEDInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnPLCLEDInfo.UseVisualStyleBackColor = true;
            btnPLCLEDInfo.Click += btnPLCLEDInfo_Click;
            // 
            // btnsetPLCTime
            // 
            btnsetPLCTime.Image = (System.Drawing.Image)resources.GetObject("btnsetPLCTime.Image");
            btnsetPLCTime.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnsetPLCTime.Location = new System.Drawing.Point(95, 88);
            btnsetPLCTime.Name = "btnsetPLCTime";
            btnsetPLCTime.Size = new System.Drawing.Size(68, 68);
            btnsetPLCTime.TabIndex = 66;
            btnsetPLCTime.Text = "set PLC Time";
            btnsetPLCTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnsetPLCTime.UseVisualStyleBackColor = true;
            btnsetPLCTime.Click += btnSetPLCTime_Click;
            // 
            // btnStopPLC
            // 
            btnStopPLC.Image = (System.Drawing.Image)resources.GetObject("btnStopPLC.Image");
            btnStopPLC.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnStopPLC.Location = new System.Drawing.Point(95, 14);
            btnStopPLC.Name = "btnStopPLC";
            btnStopPLC.Size = new System.Drawing.Size(68, 68);
            btnStopPLC.TabIndex = 68;
            btnStopPLC.Text = "Stop PLC";
            btnStopPLC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnStopPLC.UseVisualStyleBackColor = true;
            btnStopPLC.Click += btnStopPLC_Click;
            // 
            // btnGetPLCTime
            // 
            btnGetPLCTime.Image = (System.Drawing.Image)resources.GetObject("btnGetPLCTime.Image");
            btnGetPLCTime.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnGetPLCTime.Location = new System.Drawing.Point(21, 88);
            btnGetPLCTime.Name = "btnGetPLCTime";
            btnGetPLCTime.Size = new System.Drawing.Size(68, 68);
            btnGetPLCTime.TabIndex = 67;
            btnGetPLCTime.Text = "get PLC Time";
            btnGetPLCTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnGetPLCTime.UseVisualStyleBackColor = true;
            btnGetPLCTime.Click += btnGetPLCTime_Click;
            // 
            // panelStatusStrip
            // 
            panelStatusStrip.AutoSize = true;
            panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelStatusStrip.Controls.Add(statusStrip);
            panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelStatusStrip.Location = new System.Drawing.Point(0, 770);
            panelStatusStrip.Name = "panelStatusStrip";
            panelStatusStrip.Size = new System.Drawing.Size(704, 24);
            panelStatusStrip.TabIndex = 101;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = System.Drawing.SystemColors.Control;
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblDeviceType });
            statusStrip.Location = new System.Drawing.Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(702, 22);
            statusStrip.TabIndex = 94;
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
            // btnSaveLogtoFile
            // 
            btnSaveLogtoFile.Image = (System.Drawing.Image)resources.GetObject("btnSaveLogtoFile.Image");
            btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveLogtoFile.Location = new System.Drawing.Point(32, 622);
            btnSaveLogtoFile.Name = "btnSaveLogtoFile";
            btnSaveLogtoFile.Size = new System.Drawing.Size(68, 68);
            btnSaveLogtoFile.TabIndex = 116;
            btnSaveLogtoFile.Text = "save log to file";
            btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveLogtoFile.UseVisualStyleBackColor = true;
            btnSaveLogtoFile.Click += btnSaveLogtoFile_Click;
            // 
            // btnClose
            // 
            btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnClose.Location = new System.Drawing.Point(612, 696);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(68, 68);
            btnClose.TabIndex = 114;
            btnClose.Text = "close window";
            btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSaveLogtoClipboard
            // 
            btnSaveLogtoClipboard.Image = (System.Drawing.Image)resources.GetObject("btnSaveLogtoClipboard.Image");
            btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveLogtoClipboard.Location = new System.Drawing.Point(33, 548);
            btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard";
            btnSaveLogtoClipboard.Size = new System.Drawing.Size(68, 68);
            btnSaveLogtoClipboard.TabIndex = 115;
            btnSaveLogtoClipboard.Text = "copy log to clipboard";
            btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveLogtoClipboard.UseVisualStyleBackColor = true;
            btnSaveLogtoClipboard.Click += btnSaveLogtoClipboard_Click;
            // 
            // lvLog
            // 
            lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1 });
            lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvLog.Location = new System.Drawing.Point(195, 548);
            lvLog.Name = "lvLog";
            lvLog.Size = new System.Drawing.Size(485, 142);
            lvLog.TabIndex = 113;
            lvLog.UseCompatibleStateImageBehavior = false;
            lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 1000;
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new System.Drawing.Point(192, 532);
            lblLog.Name = "lblLog";
            lblLog.Size = new System.Drawing.Size(90, 13);
            lblLog.TabIndex = 112;
            lblLog.Text = "Diagnostic output";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(12, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(130, 60);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 138;
            pictureBox2.TabStop = false;
            // 
            // txtInfoOF
            // 
            txtInfoOF.BackColor = System.Drawing.SystemColors.Info;
            txtInfoOF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfoOF.Location = new System.Drawing.Point(51, 3);
            txtInfoOF.Multiline = true;
            txtInfoOF.Name = "txtInfoOF";
            txtInfoOF.ReadOnly = true;
            txtInfoOF.Size = new System.Drawing.Size(429, 56);
            txtInfoOF.TabIndex = 137;
            txtInfoOF.Text = "In this window, you can start and stop the PLC. In addition, you can reading basic data from hardware, get and set PLC-clock and retrieve diagnostic data.";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Info;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtInfoOF);
            panel1.Location = new System.Drawing.Point(195, 6);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(485, 60);
            panel1.TabIndex = 139;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(5, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(32, 32);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 151;
            pictureBox1.TabStop = false;
            // 
            // OtherFunctions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(704, 794);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(btnSaveLogtoFile);
            Controls.Add(btnClose);
            Controls.Add(btnSaveLogtoClipboard);
            Controls.Add(lvLog);
            Controls.Add(lblLog);
            Controls.Add(panelStatusStrip);
            Controls.Add(grpAction);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OtherFunctions";
            Text = "OtherFunctions";
            FormClosing += OtherFunctions_FormClosing;
            Load += OtherFunctions_Load;
            grpAction.ResumeLayout(false);
            panelStatusStrip.ResumeLayout(false);
            panelStatusStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpAction;
        internal System.Windows.Forms.Button btnReadSSL_SZL;
        internal System.Windows.Forms.Button btnDiagnoseBuffer;
        internal System.Windows.Forms.Button btnBasicInfo;
        internal System.Windows.Forms.Button btnCPUMode;
        internal System.Windows.Forms.Button btnStartPLC;
        internal System.Windows.Forms.Button btnPLCLEDInfo;
        internal System.Windows.Forms.Button btnsetPLCTime;
        internal System.Windows.Forms.Button btnStopPLC;
        internal System.Windows.Forms.Button btnGetPLCTime;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceType;
        private System.Windows.Forms.Button btnSaveLogtoFile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveLogtoClipboard;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.ListView lvValues;
        private System.Windows.Forms.ColumnHeader colDummy;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtInfoOF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}