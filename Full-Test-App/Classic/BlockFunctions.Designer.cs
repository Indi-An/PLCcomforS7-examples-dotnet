using System.Windows.Forms;

namespace PLCCom_Full_Test_App.Classic
{
    partial class BlockFunctions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlockFunctions));
            grpAction = new GroupBox();
            lvValues = new ListView();
            colDummy = new ColumnHeader();
            colValue = new ColumnHeader();
            btnDeleteBlock = new Button();
            btnRestore_Block = new Button();
            btnBackup_Block = new Button();
            btnBackupPLC = new Button();
            btnsendPW = new Button();
            btnRestorePLC = new Button();
            btnBlockList = new Button();
            btnBlockLen = new Button();
            panelStatusStrip = new Panel();
            statusStrip = new StatusStrip();
            lblDeviceType = new ToolStripStatusLabel();
            btnClose = new Button();
            btnSaveLogtoFile = new Button();
            btnSaveLogtoClipboard = new Button();
            lvLog = new ListView();
            columnHeader1 = new ColumnHeader();
            lblLog = new Label();
            pictureBox2 = new PictureBox();
            txtInfoBF = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
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
            grpAction.Controls.Add(btnDeleteBlock);
            grpAction.Controls.Add(btnRestore_Block);
            grpAction.Controls.Add(btnBackup_Block);
            grpAction.Controls.Add(btnBackupPLC);
            grpAction.Controls.Add(btnsendPW);
            grpAction.Controls.Add(btnRestorePLC);
            grpAction.Controls.Add(btnBlockList);
            grpAction.Controls.Add(btnBlockLen);
            grpAction.Location = new System.Drawing.Point(12, 66);
            grpAction.Name = "grpAction";
            grpAction.Size = new System.Drawing.Size(674, 409);
            grpAction.TabIndex = 95;
            grpAction.TabStop = false;
            grpAction.Text = "Action";
            // 
            // lvValues
            // 
            lvValues.Activation = ItemActivation.OneClick;
            lvValues.Columns.AddRange(new ColumnHeader[] { colDummy, colValue });
            lvValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvValues.FullRowSelect = true;
            lvValues.Location = new System.Drawing.Point(175, 19);
            lvValues.Name = "lvValues";
            lvValues.Size = new System.Drawing.Size(485, 364);
            lvValues.TabIndex = 105;
            lvValues.UseCompatibleStateImageBehavior = false;
            lvValues.View = View.Details;
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
            // btnDeleteBlock
            // 
            btnDeleteBlock.Image = (System.Drawing.Image)resources.GetObject("btnDeleteBlock.Image");
            btnDeleteBlock.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnDeleteBlock.Location = new System.Drawing.Point(17, 241);
            btnDeleteBlock.Name = "btnDeleteBlock";
            btnDeleteBlock.Size = new System.Drawing.Size(68, 68);
            btnDeleteBlock.TabIndex = 72;
            btnDeleteBlock.Text = "Delete Block";
            btnDeleteBlock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnDeleteBlock.UseVisualStyleBackColor = true;
            btnDeleteBlock.Click += btnDeleteBlock_Click;
            // 
            // btnRestore_Block
            // 
            btnRestore_Block.Image = (System.Drawing.Image)resources.GetObject("btnRestore_Block.Image");
            btnRestore_Block.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnRestore_Block.Location = new System.Drawing.Point(91, 167);
            btnRestore_Block.Name = "btnRestore_Block";
            btnRestore_Block.Size = new System.Drawing.Size(68, 68);
            btnRestore_Block.TabIndex = 71;
            btnRestore_Block.Text = "Restore Block";
            btnRestore_Block.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnRestore_Block.UseVisualStyleBackColor = true;
            btnRestore_Block.Click += btnRestore_Block_Click;
            // 
            // btnBackup_Block
            // 
            btnBackup_Block.Image = (System.Drawing.Image)resources.GetObject("btnBackup_Block.Image");
            btnBackup_Block.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnBackup_Block.Location = new System.Drawing.Point(17, 167);
            btnBackup_Block.Name = "btnBackup_Block";
            btnBackup_Block.Size = new System.Drawing.Size(68, 68);
            btnBackup_Block.TabIndex = 70;
            btnBackup_Block.Text = "Backup Block";
            btnBackup_Block.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnBackup_Block.UseVisualStyleBackColor = true;
            btnBackup_Block.Click += btnBackup_Block_Click;
            // 
            // btnBackupPLC
            // 
            btnBackupPLC.Image = (System.Drawing.Image)resources.GetObject("btnBackupPLC.Image");
            btnBackupPLC.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnBackupPLC.Location = new System.Drawing.Point(17, 315);
            btnBackupPLC.Name = "btnBackupPLC";
            btnBackupPLC.Size = new System.Drawing.Size(68, 68);
            btnBackupPLC.TabIndex = 73;
            btnBackupPLC.Text = "Backup PLC";
            btnBackupPLC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnBackupPLC.UseVisualStyleBackColor = true;
            btnBackupPLC.Click += btnBackupPLC_Click;
            // 
            // btnsendPW
            // 
            btnsendPW.Image = (System.Drawing.Image)resources.GetObject("btnsendPW.Image");
            btnsendPW.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnsendPW.Location = new System.Drawing.Point(17, 19);
            btnsendPW.Name = "btnsendPW";
            btnsendPW.Size = new System.Drawing.Size(68, 68);
            btnsendPW.TabIndex = 61;
            btnsendPW.Text = "send Password";
            btnsendPW.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnsendPW.UseVisualStyleBackColor = true;
            btnsendPW.Click += btnsendPW_Click;
            // 
            // btnRestorePLC
            // 
            btnRestorePLC.Image = (System.Drawing.Image)resources.GetObject("btnRestorePLC.Image");
            btnRestorePLC.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnRestorePLC.Location = new System.Drawing.Point(91, 315);
            btnRestorePLC.Name = "btnRestorePLC";
            btnRestorePLC.Size = new System.Drawing.Size(68, 68);
            btnRestorePLC.TabIndex = 74;
            btnRestorePLC.Text = "Restore PLC";
            btnRestorePLC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnRestorePLC.UseVisualStyleBackColor = true;
            btnRestorePLC.Click += btnRestorePLC_Click;
            // 
            // btnBlockList
            // 
            btnBlockList.Image = (System.Drawing.Image)resources.GetObject("btnBlockList.Image");
            btnBlockList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnBlockList.Location = new System.Drawing.Point(17, 93);
            btnBlockList.Name = "btnBlockList";
            btnBlockList.Size = new System.Drawing.Size(68, 68);
            btnBlockList.TabIndex = 68;
            btnBlockList.Text = "get PLC BlockList";
            btnBlockList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnBlockList.UseVisualStyleBackColor = true;
            btnBlockList.Click += btnBlockList_Click;
            // 
            // btnBlockLen
            // 
            btnBlockLen.Image = (System.Drawing.Image)resources.GetObject("btnBlockLen.Image");
            btnBlockLen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnBlockLen.Location = new System.Drawing.Point(91, 93);
            btnBlockLen.Name = "btnBlockLen";
            btnBlockLen.Size = new System.Drawing.Size(68, 68);
            btnBlockLen.TabIndex = 69;
            btnBlockLen.Text = "get PLC BlockLen";
            btnBlockLen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnBlockLen.UseVisualStyleBackColor = true;
            btnBlockLen.Click += btnBlockLen_Click;
            // 
            // panelStatusStrip
            // 
            panelStatusStrip.AutoSize = true;
            panelStatusStrip.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelStatusStrip.BorderStyle = BorderStyle.FixedSingle;
            panelStatusStrip.Controls.Add(statusStrip);
            panelStatusStrip.Dock = DockStyle.Bottom;
            panelStatusStrip.Location = new System.Drawing.Point(0, 724);
            panelStatusStrip.Name = "panelStatusStrip";
            panelStatusStrip.Size = new System.Drawing.Size(690, 24);
            panelStatusStrip.TabIndex = 99;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = System.Drawing.SystemColors.Control;
            statusStrip.Items.AddRange(new ToolStripItem[] { lblDeviceType });
            statusStrip.Location = new System.Drawing.Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(688, 22);
            statusStrip.TabIndex = 94;
            // 
            // lblDeviceType
            // 
            lblDeviceType.BackColor = System.Drawing.Color.White;
            lblDeviceType.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblDeviceType.BorderStyle = Border3DStyle.SunkenInner;
            lblDeviceType.Margin = new Padding(2, 3, 2, 2);
            lblDeviceType.Name = "lblDeviceType";
            lblDeviceType.Overflow = ToolStripItemOverflow.Always;
            lblDeviceType.Size = new System.Drawing.Size(77, 17);
            lblDeviceType.Text = "DeviceType: ";
            // 
            // btnClose
            // 
            btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnClose.Location = new System.Drawing.Point(604, 646);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(68, 68);
            btnClose.TabIndex = 109;
            btnClose.Text = "close window";
            btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSaveLogtoFile
            // 
            btnSaveLogtoFile.Image = (System.Drawing.Image)resources.GetObject("btnSaveLogtoFile.Image");
            btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveLogtoFile.Location = new System.Drawing.Point(29, 570);
            btnSaveLogtoFile.Name = "btnSaveLogtoFile";
            btnSaveLogtoFile.Size = new System.Drawing.Size(68, 68);
            btnSaveLogtoFile.TabIndex = 111;
            btnSaveLogtoFile.Text = "save log to file";
            btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveLogtoFile.UseVisualStyleBackColor = true;
            btnSaveLogtoFile.Click += btnSaveLogtoFile_Click;
            // 
            // btnSaveLogtoClipboard
            // 
            btnSaveLogtoClipboard.Image = (System.Drawing.Image)resources.GetObject("btnSaveLogtoClipboard.Image");
            btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnSaveLogtoClipboard.Location = new System.Drawing.Point(29, 496);
            btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard";
            btnSaveLogtoClipboard.Size = new System.Drawing.Size(68, 68);
            btnSaveLogtoClipboard.TabIndex = 110;
            btnSaveLogtoClipboard.Text = "copy log to clipboard";
            btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnSaveLogtoClipboard.UseVisualStyleBackColor = true;
            btnSaveLogtoClipboard.Click += btnSaveLogtoClipboard_Click;
            // 
            // lvLog
            // 
            lvLog.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lvLog.HeaderStyle = ColumnHeaderStyle.None;
            lvLog.Location = new System.Drawing.Point(187, 496);
            lvLog.Name = "lvLog";
            lvLog.Size = new System.Drawing.Size(485, 142);
            lvLog.TabIndex = 109;
            lvLog.UseCompatibleStateImageBehavior = false;
            lvLog.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 1000;
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new System.Drawing.Point(184, 480);
            lblLog.Name = "lblLog";
            lblLog.Size = new System.Drawing.Size(90, 13);
            lblLog.TabIndex = 108;
            lblLog.Text = "Diagnostic output";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(8, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(130, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 136;
            pictureBox2.TabStop = false;
            // 
            // txtInfoBF
            // 
            txtInfoBF.BackColor = System.Drawing.SystemColors.Info;
            txtInfoBF.BorderStyle = BorderStyle.None;
            txtInfoBF.Location = new System.Drawing.Point(43, 3);
            txtInfoBF.Multiline = true;
            txtInfoBF.Name = "txtInfoBF";
            txtInfoBF.ReadOnly = true;
            txtInfoBF.Size = new System.Drawing.Size(422, 45);
            txtInfoBF.TabIndex = 135;
            txtInfoBF.Text = "In this window you can read the object list, call up the length of individual objects. \r\nIn addition, functions for backup and restore are available.";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Info;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtInfoBF);
            panel1.Location = new System.Drawing.Point(187, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(485, 60);
            panel1.TabIndex = 137;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.SystemColors.Info;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 150;
            pictureBox1.TabStop = false;
            // 
            // BlockFunctions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(690, 748);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(btnSaveLogtoFile);
            Controls.Add(btnClose);
            Controls.Add(btnSaveLogtoClipboard);
            Controls.Add(panelStatusStrip);
            Controls.Add(lvLog);
            Controls.Add(lblLog);
            Controls.Add(grpAction);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BlockFunctions";
            Text = "BlockFunctions";
            FormClosing += BlockFunctions_FormClosing;
            Load += BlockFunctions_Load;
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
        internal System.Windows.Forms.Button btnDeleteBlock;
        internal System.Windows.Forms.Button btnsendPW;
        internal System.Windows.Forms.Button btnRestore_Block;
        internal System.Windows.Forms.Button btnBackup_Block;
        internal System.Windows.Forms.Button btnBlockList;
        internal System.Windows.Forms.Button btnBlockLen;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceType;
        internal System.Windows.Forms.Button btnRestorePLC;
        internal System.Windows.Forms.Button btnBackupPLC;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveLogtoFile;
        private System.Windows.Forms.Button btnSaveLogtoClipboard;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.ListView lvValues;
        private System.Windows.Forms.ColumnHeader colDummy;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtInfoBF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}