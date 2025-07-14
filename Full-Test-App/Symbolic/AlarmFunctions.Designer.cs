using System.Windows.Forms;

namespace PLCCom_Full_Test_App.Symbolic
{
    partial class AlarmFunctions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmFunctions));
            grbAlarms = new GroupBox();
            btnAcknowledge = new Button();
            lvAlarms = new ListView();
            colAlarmId = new ColumnHeader();
            colMessageType = new ColumnHeader();
            colState = new ColumnHeader();
            colId = new ColumnHeader();
            colTimestamp = new ColumnHeader();
            colAlarmText = new ColumnHeader();
            panelStatusStrip = new Panel();
            statusStrip = new StatusStrip();
            lblDeviceType = new ToolStripStatusLabel();
            btnClose = new Button();
            pictureBox2 = new PictureBox();
            txtInfoAlarms = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            grbInformations = new GroupBox();
            lvInformations = new ListView();
            colInfoAlarmId = new ColumnHeader();
            colInfoMessageType = new ColumnHeader();
            colInfoTimestamp = new ColumnHeader();
            colInfoAlarmText = new ColumnHeader();
            grbAlarms.SuspendLayout();
            panelStatusStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grbInformations.SuspendLayout();
            SuspendLayout();
            // 
            // grbAlarms
            // 
            grbAlarms.Controls.Add(btnAcknowledge);
            grbAlarms.Controls.Add(lvAlarms);
            grbAlarms.Location = new System.Drawing.Point(15, 82);
            grbAlarms.Margin = new Padding(4, 3, 4, 3);
            grbAlarms.Name = "grbAlarms";
            grbAlarms.Padding = new Padding(4, 3, 4, 3);
            grbAlarms.Size = new System.Drawing.Size(1026, 333);
            grbAlarms.TabIndex = 98;
            grbAlarms.TabStop = false;
            grbAlarms.Text = "Alarm Messages, doubleclick for details";
            // 
            // btnAcknowledge
            // 
            btnAcknowledge.Enabled = false;
            btnAcknowledge.Image = (System.Drawing.Image)resources.GetObject("btnAcknowledge.Image");
            btnAcknowledge.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnAcknowledge.Location = new System.Drawing.Point(924, 246);
            btnAcknowledge.Margin = new Padding(4, 3, 4, 3);
            btnAcknowledge.Name = "btnAcknowledge";
            btnAcknowledge.Size = new System.Drawing.Size(80, 80);
            btnAcknowledge.TabIndex = 119;
            btnAcknowledge.Text = "Confirm Alarm";
            btnAcknowledge.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnAcknowledge.UseVisualStyleBackColor = true;
            btnAcknowledge.Click += btnAcknowledge_Click;
            // 
            // lvAlarms
            // 
            lvAlarms.Activation = ItemActivation.OneClick;
            lvAlarms.Columns.AddRange(new ColumnHeader[] { colAlarmId, colMessageType, colState, colId, colTimestamp, colAlarmText });
            lvAlarms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvAlarms.FullRowSelect = true;
            lvAlarms.Location = new System.Drawing.Point(23, 20);
            lvAlarms.Margin = new Padding(4, 3, 4, 3);
            lvAlarms.Name = "lvAlarms";
            lvAlarms.ShowItemToolTips = true;
            lvAlarms.Size = new System.Drawing.Size(980, 220);
            lvAlarms.TabIndex = 118;
            lvAlarms.UseCompatibleStateImageBehavior = false;
            lvAlarms.View = View.Details;
            lvAlarms.SelectedIndexChanged += lvAlarms_SelectedIndexChanged;
            lvAlarms.MouseDoubleClick += lvAlarms_MouseDoubleClick;
            // 
            // colAlarmId
            // 
            colAlarmId.Text = "";
            colAlarmId.Width = 0;
            // 
            // colMessageType
            // 
            colMessageType.Text = "MessageType";
            colMessageType.Width = 150;
            // 
            // colState
            // 
            colState.Text = "State";
            colState.Width = 150;
            // 
            // colId
            // 
            colId.Text = "Id";
            colId.Width = 40;
            // 
            // colTimestamp
            // 
            colTimestamp.Text = "Timestamp";
            colTimestamp.Width = 120;
            // 
            // colAlarmText
            // 
            colAlarmText.Text = "Alarmtext";
            colAlarmText.Width = 500;
            // 
            // panelStatusStrip
            // 
            panelStatusStrip.AutoSize = true;
            panelStatusStrip.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelStatusStrip.BorderStyle = BorderStyle.FixedSingle;
            panelStatusStrip.Controls.Add(statusStrip);
            panelStatusStrip.Dock = DockStyle.Bottom;
            panelStatusStrip.Location = new System.Drawing.Point(0, 769);
            panelStatusStrip.Margin = new Padding(4, 3, 4, 3);
            panelStatusStrip.Name = "panelStatusStrip";
            panelStatusStrip.Size = new System.Drawing.Size(1054, 24);
            panelStatusStrip.TabIndex = 101;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = System.Drawing.SystemColors.Control;
            statusStrip.Items.AddRange(new ToolStripItem[] { lblDeviceType });
            statusStrip.Location = new System.Drawing.Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(1052, 22);
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
            btnClose.Location = new System.Drawing.Point(940, 680);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(79, 78);
            btnClose.TabIndex = 114;
            btnClose.Text = "close window";
            btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(14, 2);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(130, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 138;
            pictureBox2.TabStop = false;
            // 
            // txtInfoAlarms
            // 
            txtInfoAlarms.BackColor = System.Drawing.SystemColors.Info;
            txtInfoAlarms.BorderStyle = BorderStyle.None;
            txtInfoAlarms.Location = new System.Drawing.Point(59, 3);
            txtInfoAlarms.Margin = new Padding(4, 3, 4, 3);
            txtInfoAlarms.Multiline = true;
            txtInfoAlarms.Name = "txtInfoAlarms";
            txtInfoAlarms.ReadOnly = true;
            txtInfoAlarms.Size = new System.Drawing.Size(500, 65);
            txtInfoAlarms.TabIndex = 137;
            txtInfoAlarms.Text = "In this window, you can start and stop the PLC. In addition, you can reading basic data from hardware, get and set PLC-clock and retrieve diagnostic data.";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Info;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtInfoAlarms);
            panel1.Location = new System.Drawing.Point(227, 7);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(566, 69);
            panel1.TabIndex = 139;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(6, 5);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 151;
            pictureBox1.TabStop = false;
            // 
            // grbInformations
            // 
            grbInformations.Controls.Add(lvInformations);
            grbInformations.Location = new System.Drawing.Point(13, 421);
            grbInformations.Margin = new Padding(4, 3, 4, 3);
            grbInformations.Name = "grbInformations";
            grbInformations.Padding = new Padding(4, 3, 4, 3);
            grbInformations.Size = new System.Drawing.Size(1026, 253);
            grbInformations.TabIndex = 140;
            grbInformations.TabStop = false;
            grbInformations.Text = "Information Messages, doubleclick for details";
            // 
            // lvInformations
            // 
            lvInformations.Activation = ItemActivation.OneClick;
            lvInformations.Columns.AddRange(new ColumnHeader[] { colInfoAlarmId, colInfoMessageType, colInfoTimestamp, colInfoAlarmText });
            lvInformations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lvInformations.FullRowSelect = true;
            lvInformations.Location = new System.Drawing.Point(23, 20);
            lvInformations.Margin = new Padding(4, 3, 4, 3);
            lvInformations.Name = "lvInformations";
            lvInformations.ShowItemToolTips = true;
            lvInformations.Size = new System.Drawing.Size(980, 220);
            lvInformations.TabIndex = 118;
            lvInformations.UseCompatibleStateImageBehavior = false;
            lvInformations.View = View.Details;
            lvInformations.MouseDoubleClick += lvInformations_MouseDoubleClick;
            // 
            // colInfoAlarmId
            // 
            colInfoAlarmId.Text = "";
            colInfoAlarmId.Width = 0;
            // 
            // colInfoMessageType
            // 
            colInfoMessageType.Text = "MessageType";
            colInfoMessageType.Width = 120;
            // 
            // colInfoTimestamp
            // 
            colInfoTimestamp.Text = "Timestamp";
            colInfoTimestamp.Width = 120;
            // 
            // colInfoAlarmtext
            // 
            colInfoAlarmText.Text = "Alarmtext";
            colInfoAlarmText.Width = 770;
            // 
            // AlarmFunctions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1054, 793);
            Controls.Add(grbInformations);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(btnClose);
            Controls.Add(panelStatusStrip);
            Controls.Add(grbAlarms);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AlarmFunctions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AlarmFunctions";
            FormClosing += AlarmFunctions_FormClosing;
            Load += AlarmFunctions_Load;
            grbAlarms.ResumeLayout(false);
            panelStatusStrip.ResumeLayout(false);
            panelStatusStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grbInformations.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grbAlarms;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvAlarms;
        private System.Windows.Forms.ColumnHeader colAlarmId;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtInfoAlarms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ColumnHeader colId;
        private ColumnHeader colTimestamp;
        private ColumnHeader colState;
        private ColumnHeader colAlarmText;
        private ColumnHeader colMessageType;
        internal Button btnAcknowledge;
        private GroupBox grbInformations;
        private ListView lvInformations;
        private ColumnHeader colInfoAlarmId;
        private ColumnHeader colInfoMessageType;
        private ColumnHeader colInfoTimestamp;
        private ColumnHeader colInfoAlarmText;
    }
}