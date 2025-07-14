namespace PLCCom_Full_Test_App.Classic
{
    partial class OtherFunctionsInputBox
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
            this.lblDate = new System.Windows.Forms.Label();
            this.txtSSL_ID = new System.Windows.Forms.TextBox();
            this.lblSSL_ID = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtSSL_Index = new System.Windows.Forms.TextBox();
            this.lblSSL_Index = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtSSL_Index_Hex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSSL_ID_Hex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(26, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(53, 13);
            this.lblDate.TabIndex = 61;
            this.lblDate.Text = "DateTime";
            // 
            // txtSSL_ID
            // 
            this.txtSSL_ID.Location = new System.Drawing.Point(85, 46);
            this.txtSSL_ID.Name = "txtSSL_ID";
            this.txtSSL_ID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSSL_ID.Size = new System.Drawing.Size(38, 20);
            this.txtSSL_ID.TabIndex = 62;
            this.txtSSL_ID.Text = "306";
            this.txtSSL_ID.TextChanged += new System.EventHandler(this.txtSSL_ID_TextChanged);
            // 
            // lblSSL_ID
            // 
            this.lblSSL_ID.AutoSize = true;
            this.lblSSL_ID.Location = new System.Drawing.Point(20, 49);
            this.lblSSL_ID.Name = "lblSSL_ID";
            this.lblSSL_ID.Size = new System.Drawing.Size(58, 13);
            this.lblSSL_ID.TabIndex = 63;
            this.lblSSL_ID.Text = "SSL / SZL";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(131, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 64;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtSSL_Index
            // 
            this.txtSSL_Index.Location = new System.Drawing.Point(85, 72);
            this.txtSSL_Index.Name = "txtSSL_Index";
            this.txtSSL_Index.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSSL_Index.Size = new System.Drawing.Size(38, 20);
            this.txtSSL_Index.TabIndex = 65;
            this.txtSSL_Index.Text = "4";
            this.txtSSL_Index.TextChanged += new System.EventHandler(this.txtSSL_Index_TextChanged);
            // 
            // lblSSL_Index
            // 
            this.lblSSL_Index.AutoSize = true;
            this.lblSSL_Index.Location = new System.Drawing.Point(2, 75);
            this.lblSSL_Index.Name = "lblSSL_Index";
            this.lblSSL_Index.Size = new System.Drawing.Size(81, 13);
            this.lblSSL_Index.TabIndex = 66;
            this.lblSSL_Index.Text = "SSL/SZL Index";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(85, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker.TabIndex = 140;
            // 
            // txtSSL_Index_Hex
            // 
            this.txtSSL_Index_Hex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSSL_Index_Hex.Location = new System.Drawing.Point(168, 74);
            this.txtSSL_Index_Hex.Name = "txtSSL_Index_Hex";
            this.txtSSL_Index_Hex.ReadOnly = true;
            this.txtSSL_Index_Hex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSSL_Index_Hex.Size = new System.Drawing.Size(38, 20);
            this.txtSSL_Index_Hex.TabIndex = 143;
            this.txtSSL_Index_Hex.Text = "0x04";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 144;
            this.label2.Text = "hex";
            // 
            // txtSSL_ID_Hex
            // 
            this.txtSSL_ID_Hex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSSL_ID_Hex.Location = new System.Drawing.Point(168, 47);
            this.txtSSL_ID_Hex.Name = "txtSSL_ID_Hex";
            this.txtSSL_ID_Hex.ReadOnly = true;
            this.txtSSL_ID_Hex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSSL_ID_Hex.Size = new System.Drawing.Size(38, 20);
            this.txtSSL_ID_Hex.TabIndex = 141;
            this.txtSSL_ID_Hex.Text = "0x132";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 142;
            this.label3.Text = "hex";
            // 
            // OtherFunctionsInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 138);
            this.ControlBox = false;
            this.Controls.Add(this.txtSSL_Index_Hex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSSL_ID_Hex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.txtSSL_Index);
            this.Controls.Add(this.lblSSL_Index);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtSSL_ID);
            this.Controls.Add(this.lblSSL_ID);
            this.Name = "OtherFunctionsInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inputbox";
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblDate;
        internal System.Windows.Forms.TextBox txtSSL_ID;
        internal System.Windows.Forms.Label lblSSL_ID;
        private System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.TextBox txtSSL_Index;
        internal System.Windows.Forms.Label lblSSL_Index;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        internal System.Windows.Forms.TextBox txtSSL_Index_Hex;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtSSL_ID_Hex;
        internal System.Windows.Forms.Label label3;
    }
}