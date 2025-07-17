namespace PLCCom_Full_Test_App.Classic
{
    partial class OptimizedReadWriteBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptimizedReadWriteBox));
            grpAddress = new System.Windows.Forms.GroupBox();
            btnRemoveRequest = new System.Windows.Forms.Button();
            lvRequests = new System.Windows.Forms.ListView();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            btnAddRequest = new System.Windows.Forms.Button();
            txtInfoRCB = new System.Windows.Forms.TextBox();
            grpAction = new System.Windows.Forms.GroupBox();
            btnHelpWriteOptMode = new System.Windows.Forms.Button();
            btnHelpReadOptMode = new System.Windows.Forms.Button();
            cmbWriteOptimizeMode = new System.Windows.Forms.ComboBox();
            lblWriteOptimizationMode = new System.Windows.Forms.Label();
            cmbReadOptimizeMode = new System.Windows.Forms.ComboBox();
            lblReadOptimizationMode = new System.Windows.Forms.Label();
            cmbOperationOrder = new System.Windows.Forms.ComboBox();
            lblOperationOrder = new System.Windows.Forms.Label();
            lblLog = new System.Windows.Forms.Label();
            txtLog = new System.Windows.Forms.RichTextBox();
            btnSaveLogtoFile = new System.Windows.Forms.Button();
            txtResults = new System.Windows.Forms.RichTextBox();
            btnExecute = new System.Windows.Forms.Button();
            btnSaveLogtoClipboard = new System.Windows.Forms.Button();
            panelStatusStrip = new System.Windows.Forms.Panel();
            statusStrip = new System.Windows.Forms.StatusStrip();
            lblDeviceType = new System.Windows.Forms.ToolStripStatusLabel();
            btnClose = new System.Windows.Forms.Button();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            grpAddress.SuspendLayout();
            grpAction.SuspendLayout();
            panelStatusStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // grpAddress
            // 
            grpAddress.Controls.Add(btnRemoveRequest);
            grpAddress.Controls.Add(lvRequests);
            grpAddress.Controls.Add(btnAddRequest);
            grpAddress.Location = new System.Drawing.Point(8, 74);
            grpAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            grpAddress.Name = "grpAddress";
            grpAddress.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            grpAddress.Size = new System.Drawing.Size(910, 209);
            grpAddress.TabIndex = 87;
            grpAddress.TabStop = false;
            grpAddress.Text = "add request";
            // 
            // btnRemoveRequest
            // 
            btnRemoveRequest.Image = (System.Drawing.Image)resources.GetObject("btnRemoveRequest.Image");
            btnRemoveRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnRemoveRequest.Location = new System.Drawing.Point(24, 118);
            btnRemoveRequest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemoveRequest.Name = "btnRemoveRequest";
            btnRemoveRequest.Size = new System.Drawing.Size(79, 78);
            btnRemoveRequest.TabIndex = 105;
            btnRemoveRequest.Text = "remove Request";
            btnRemoveRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnRemoveRequest.UseVisualStyleBackColor = true;
            btnRemoveRequest.Click += btnRemoveRequest_Click;
            // 
            // lvRequests
            // 
            lvRequests.Activation = System.Windows.Forms.ItemActivation.OneClick;
            lvRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader3, columnHeader2 });
            lvRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvRequests.FullRowSelect = true;
            lvRequests.Location = new System.Drawing.Point(126, 31);
            lvRequests.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvRequests.Name = "lvRequests";
            lvRequests.Size = new System.Drawing.Size(772, 161);
            lvRequests.TabIndex = 104;
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
            // btnAddRequest
            // 
            btnAddRequest.Image = (System.Drawing.Image)resources.GetObject("btnAddRequest.Image");
            btnAddRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnAddRequest.Location = new System.Drawing.Point(24, 32);
            btnAddRequest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddRequest.Name = "btnAddRequest";
            btnAddRequest.Size = new System.Drawing.Size(79, 78);
            btnAddRequest.TabIndex = 66;
            btnAddRequest.Text = "add Request";
            btnAddRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnAddRequest.UseVisualStyleBackColor = true;
            btnAddRequest.Click += btnAddRequest_Click;
            // 
            // txtInfoRCB
            // 
            txtInfoRCB.BackColor = System.Drawing.SystemColors.Info;
            txtInfoRCB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfoRCB.Location = new System.Drawing.Point(48, 2);
            txtInfoRCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtInfoRCB.Multiline = true;
            txtInfoRCB.Name = "txtInfoRCB";
            txtInfoRCB.Size = new System.Drawing.Size(621, 61);
            txtInfoRCB.TabIndex = 106;
            // 
            // grpAction
            // 
            grpAction.Controls.Add(btnHelpWriteOptMode);
            grpAction.Controls.Add(btnHelpReadOptMode);
            grpAction.Controls.Add(cmbWriteOptimizeMode);
            grpAction.Controls.Add(lblWriteOptimizationMode);
            grpAction.Controls.Add(cmbReadOptimizeMode);
            grpAction.Controls.Add(lblReadOptimizationMode);
            grpAction.Controls.Add(cmbOperationOrder);
            grpAction.Controls.Add(lblOperationOrder);
            grpAction.Controls.Add(lblLog);
            grpAction.Controls.Add(txtLog);
            grpAction.Controls.Add(btnSaveLogtoFile);
            grpAction.Controls.Add(txtResults);
            grpAction.Controls.Add(btnExecute);
            grpAction.Controls.Add(btnSaveLogtoClipboard);
            grpAction.Location = new System.Drawing.Point(8, 287);
            grpAction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            grpAction.Name = "grpAction";
            grpAction.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            grpAction.Size = new System.Drawing.Size(910, 459);
            grpAction.TabIndex = 88;
            grpAction.TabStop = false;
            grpAction.Text = "Results";
            // 
            // btnHelpWriteOptMode
            // 
            btnHelpWriteOptMode.Image = (System.Drawing.Image)resources.GetObject("btnHelpWriteOptMode.Image");
            btnHelpWriteOptMode.Location = new System.Drawing.Point(412, 40);
            btnHelpWriteOptMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnHelpWriteOptMode.Name = "btnHelpWriteOptMode";
            btnHelpWriteOptMode.Size = new System.Drawing.Size(28, 28);
            btnHelpWriteOptMode.TabIndex = 129;
            btnHelpWriteOptMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnHelpWriteOptMode.UseVisualStyleBackColor = true;
            btnHelpWriteOptMode.Click += btnHelpWriteOptMode_Click;
            // 
            // btnHelpReadOptMode
            // 
            btnHelpReadOptMode.Image = (System.Drawing.Image)resources.GetObject("btnHelpReadOptMode.Image");
            btnHelpReadOptMode.Location = new System.Drawing.Point(412, 12);
            btnHelpReadOptMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnHelpReadOptMode.Name = "btnHelpReadOptMode";
            btnHelpReadOptMode.Size = new System.Drawing.Size(28, 28);
            btnHelpReadOptMode.TabIndex = 128;
            btnHelpReadOptMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnHelpReadOptMode.UseVisualStyleBackColor = true;
            btnHelpReadOptMode.Click += btnHelpReadOptMode_Click;
            // 
            // cmbWriteOptimizeMode
            // 
            cmbWriteOptimizeMode.FormattingEnabled = true;
            cmbWriteOptimizeMode.Location = new System.Drawing.Point(126, 40);
            cmbWriteOptimizeMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbWriteOptimizeMode.Name = "cmbWriteOptimizeMode";
            cmbWriteOptimizeMode.Size = new System.Drawing.Size(278, 23);
            cmbWriteOptimizeMode.TabIndex = 126;
            cmbWriteOptimizeMode.SelectedIndexChanged += cmbWriteOptimizeMode_SelectedIndexChanged;
            // 
            // lblWriteOptimizationMode
            // 
            lblWriteOptimizationMode.Location = new System.Drawing.Point(4, 45);
            lblWriteOptimizationMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblWriteOptimizationMode.Name = "lblWriteOptimizationMode";
            lblWriteOptimizationMode.Size = new System.Drawing.Size(120, 18);
            lblWriteOptimizationMode.TabIndex = 127;
            lblWriteOptimizationMode.Text = "write opt. mode";
            lblWriteOptimizationMode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbReadOptimizeMode
            // 
            cmbReadOptimizeMode.FormattingEnabled = true;
            cmbReadOptimizeMode.Location = new System.Drawing.Point(126, 12);
            cmbReadOptimizeMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbReadOptimizeMode.Name = "cmbReadOptimizeMode";
            cmbReadOptimizeMode.Size = new System.Drawing.Size(278, 23);
            cmbReadOptimizeMode.TabIndex = 123;
            cmbReadOptimizeMode.SelectedIndexChanged += cmbReadOptimizeMode_SelectedIndexChanged;
            // 
            // lblReadOptimizationMode
            // 
            lblReadOptimizationMode.Location = new System.Drawing.Point(4, 16);
            lblReadOptimizationMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblReadOptimizationMode.Name = "lblReadOptimizationMode";
            lblReadOptimizationMode.Size = new System.Drawing.Size(120, 18);
            lblReadOptimizationMode.TabIndex = 124;
            lblReadOptimizationMode.Text = "read opt. mode";
            lblReadOptimizationMode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbOperationOrder
            // 
            cmbOperationOrder.FormattingEnabled = true;
            cmbOperationOrder.Location = new System.Drawing.Point(126, 69);
            cmbOperationOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbOperationOrder.Name = "cmbOperationOrder";
            cmbOperationOrder.Size = new System.Drawing.Size(278, 23);
            cmbOperationOrder.TabIndex = 121;
            cmbOperationOrder.SelectedIndexChanged += cmbOperationOrder_SelectedIndexChanged;
            // 
            // lblOperationOrder
            // 
            lblOperationOrder.Location = new System.Drawing.Point(4, 74);
            lblOperationOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOperationOrder.Name = "lblOperationOrder";
            lblOperationOrder.Size = new System.Drawing.Size(120, 18);
            lblOperationOrder.TabIndex = 122;
            lblOperationOrder.Text = "operation order";
            lblOperationOrder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new System.Drawing.Point(125, 267);
            lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLog.Name = "lblLog";
            lblLog.Size = new System.Drawing.Size(102, 15);
            lblLog.TabIndex = 39;
            lblLog.Text = "Diagnostic output";
            // 
            // txtLog
            // 
            txtLog.BackColor = System.Drawing.Color.White;
            txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLog.Location = new System.Drawing.Point(126, 286);
            txtLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new System.Drawing.Size(768, 161);
            txtLog.TabIndex = 105;
            txtLog.Text = "";
            // 
            // btnSaveLogtoFile
            // 
            btnSaveLogtoFile.Image = (System.Drawing.Image)resources.GetObject("btnSaveLogtoFile.Image");
            btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveLogtoFile.Location = new System.Drawing.Point(21, 369);
            btnSaveLogtoFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSaveLogtoFile.Name = "btnSaveLogtoFile";
            btnSaveLogtoFile.Size = new System.Drawing.Size(79, 78);
            btnSaveLogtoFile.TabIndex = 105;
            btnSaveLogtoFile.Text = "save log to file";
            btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveLogtoFile.UseVisualStyleBackColor = true;
            btnSaveLogtoFile.Click += btnSaveLogtoFile_Click;
            // 
            // txtResults
            // 
            txtResults.BackColor = System.Drawing.Color.White;
            txtResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtResults.Location = new System.Drawing.Point(126, 100);
            txtResults.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.Size = new System.Drawing.Size(768, 161);
            txtResults.TabIndex = 104;
            txtResults.Text = "";
            // 
            // btnExecute
            // 
            btnExecute.Image = (System.Drawing.Image)resources.GetObject("btnExecute.Image");
            btnExecute.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnExecute.Location = new System.Drawing.Point(21, 100);
            btnExecute.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new System.Drawing.Size(79, 78);
            btnExecute.TabIndex = 103;
            btnExecute.Text = "execute";
            btnExecute.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // btnSaveLogtoClipboard
            // 
            btnSaveLogtoClipboard.Image = (System.Drawing.Image)resources.GetObject("btnSaveLogtoClipboard.Image");
            btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveLogtoClipboard.Location = new System.Drawing.Point(21, 286);
            btnSaveLogtoClipboard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard";
            btnSaveLogtoClipboard.Size = new System.Drawing.Size(79, 78);
            btnSaveLogtoClipboard.TabIndex = 104;
            btnSaveLogtoClipboard.Text = "copy log in clipboard";
            btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveLogtoClipboard.UseVisualStyleBackColor = true;
            btnSaveLogtoClipboard.Click += btnSaveLogtoClipboard_Click;
            // 
            // panelStatusStrip
            // 
            panelStatusStrip.AutoSize = true;
            panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelStatusStrip.Controls.Add(statusStrip);
            panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelStatusStrip.Location = new System.Drawing.Point(0, 841);
            panelStatusStrip.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelStatusStrip.Name = "panelStatusStrip";
            panelStatusStrip.Size = new System.Drawing.Size(926, 24);
            panelStatusStrip.TabIndex = 97;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = System.Drawing.SystemColors.Control;
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblDeviceType });
            statusStrip.Location = new System.Drawing.Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(924, 22);
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
            // btnClose
            // 
            btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnClose.Location = new System.Drawing.Point(819, 752);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(79, 78);
            btnClose.TabIndex = 99;
            btnClose.Text = "close window";
            btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(14, 1);
            pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(130, 60);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 133;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Info;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtInfoRCB);
            panel1.Location = new System.Drawing.Point(229, 7);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(664, 69);
            panel1.TabIndex = 134;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(5, 3);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(32, 32);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 152;
            pictureBox1.TabStop = false;
            // 
            // OptimizedReadWriteBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(926, 865);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(btnClose);
            Controls.Add(panelStatusStrip);
            Controls.Add(grpAction);
            Controls.Add(grpAddress);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OptimizedReadWriteBox";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "OptimizedReadWriteBox";
            FormClosing += OptimizedReadWriteBox_FormClosing;
            Load += OptimizedReadWriteBox_Load;
            grpAddress.ResumeLayout(false);
            grpAction.ResumeLayout(false);
            grpAction.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceType;
        private System.Windows.Forms.Button btnAddRequest;
        private System.Windows.Forms.ListView lvRequests;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnRemoveRequest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveLogtoClipboard;
        private System.Windows.Forms.Button btnSaveLogtoFile;
        private System.Windows.Forms.TextBox txtInfoRCB;
        private System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.RichTextBox txtResults;
        private System.Windows.Forms.RichTextBox txtLog;
        internal System.Windows.Forms.ComboBox cmbReadOptimizeMode;
        internal System.Windows.Forms.Label lblReadOptimizationMode;
        internal System.Windows.Forms.ComboBox cmbOperationOrder;
        internal System.Windows.Forms.Label lblOperationOrder;
        internal System.Windows.Forms.ComboBox cmbWriteOptimizeMode;
        internal System.Windows.Forms.Label lblWriteOptimizationMode;
        private System.Windows.Forms.Button btnHelpWriteOptMode;
        private System.Windows.Forms.Button btnHelpReadOptMode;
    }
}