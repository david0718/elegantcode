namespace ElegantCode.BeSure.Common.View
{
    partial class ConfirmationView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmationView));
            this.label1 = new System.Windows.Forms.Label();
            this._btnSendIt = new System.Windows.Forms.Button();
            this._btnDontSendIt = new System.Windows.Forms.Button();
            this._lblAccountName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._lbTo = new System.Windows.Forms.ListBox();
            this._lbBcc = new System.Windows.Forms.ListBox();
            this._lbCc = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._lblNumberOfAttachments = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account";
            // 
            // _btnSendIt
            // 
            this._btnSendIt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSendIt.BackColor = System.Drawing.Color.Lime;
            this._btnSendIt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._btnSendIt.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this._btnSendIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnSendIt.Location = new System.Drawing.Point(13, 437);
            this._btnSendIt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnSendIt.Name = "_btnSendIt";
            this._btnSendIt.Size = new System.Drawing.Size(116, 123);
            this._btnSendIt.TabIndex = 2;
            this._btnSendIt.Text = "Send It";
            this._btnSendIt.UseVisualStyleBackColor = false;
            // 
            // _btnDontSendIt
            // 
            this._btnDontSendIt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDontSendIt.BackColor = System.Drawing.Color.Red;
            this._btnDontSendIt.DialogResult = System.Windows.Forms.DialogResult.No;
            this._btnDontSendIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnDontSendIt.Location = new System.Drawing.Point(137, 437);
            this._btnDontSendIt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnDontSendIt.Name = "_btnDontSendIt";
            this._btnDontSendIt.Size = new System.Drawing.Size(644, 123);
            this._btnDontSendIt.TabIndex = 1;
            this._btnDontSendIt.Text = "Oops. I Need to Change Something";
            this._btnDontSendIt.UseVisualStyleBackColor = false;
            // 
            // _lblAccountName
            // 
            this._lblAccountName.AutoSize = true;
            this._lblAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblAccountName.ForeColor = System.Drawing.Color.Red;
            this._lblAccountName.Location = new System.Drawing.Point(137, 9);
            this._lblAccountName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblAccountName.Name = "_lblAccountName";
            this._lblAccountName.Size = new System.Drawing.Size(204, 31);
            this._lblAccountName.TabIndex = 3;
            this._lblAccountName.Text = "Account Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(81, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(54, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "BCC";
            // 
            // _lbTo
            // 
            this._lbTo.FormattingEnabled = true;
            this._lbTo.ItemHeight = 20;
            this._lbTo.Location = new System.Drawing.Point(143, 102);
            this._lbTo.Name = "_lbTo";
            this._lbTo.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this._lbTo.Size = new System.Drawing.Size(638, 124);
            this._lbTo.Sorted = true;
            this._lbTo.TabIndex = 6;
            this._lbTo.TabStop = false;
            // 
            // _lbBcc
            // 
            this._lbBcc.FormattingEnabled = true;
            this._lbBcc.ItemHeight = 20;
            this._lbBcc.Location = new System.Drawing.Point(143, 362);
            this._lbBcc.Name = "_lbBcc";
            this._lbBcc.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this._lbBcc.Size = new System.Drawing.Size(638, 64);
            this._lbBcc.Sorted = true;
            this._lbBcc.TabIndex = 10;
            this._lbBcc.TabStop = false;
            this._lbBcc.SelectedIndexChanged += new System.EventHandler(this._lbBccRecipients_SelectedIndexChanged);
            // 
            // _lbCc
            // 
            this._lbCc.FormattingEnabled = true;
            this._lbCc.ItemHeight = 20;
            this._lbCc.Location = new System.Drawing.Point(143, 232);
            this._lbCc.Name = "_lbCc";
            this._lbCc.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this._lbCc.Size = new System.Drawing.Size(638, 124);
            this._lbCc.Sorted = true;
            this._lbCc.TabIndex = 12;
            this._lbCc.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(73, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "CC";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(479, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // _lblNumberOfAttachments
            // 
            this._lblNumberOfAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblNumberOfAttachments.AutoSize = true;
            this._lblNumberOfAttachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblNumberOfAttachments.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._lblNumberOfAttachments.Location = new System.Drawing.Point(93, 47);
            this._lblNumberOfAttachments.Name = "_lblNumberOfAttachments";
            this._lblNumberOfAttachments.Size = new System.Drawing.Size(30, 31);
            this._lblNumberOfAttachments.TabIndex = 17;
            this._lblNumberOfAttachments.Text = "0";
            this._lblNumberOfAttachments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(137, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 31);
            this.label5.TabIndex = 16;
            this.label5.Text = "Attachments";
            // 
            // ConfirmationView
            // 
            this.AcceptButton = this._btnDontSendIt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._btnDontSendIt;
            this.ClientSize = new System.Drawing.Size(794, 574);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._lblNumberOfAttachments);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._lbCc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._lbBcc);
            this.Controls.Add(this._lbTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._lblAccountName);
            this.Controls.Add(this._btnDontSendIt);
            this.Controls.Add(this._btnSendIt);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConfirmationView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirm This Email";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConfirmationDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnSendIt;
        private System.Windows.Forms.Button _btnDontSendIt;
        private System.Windows.Forms.Label _lblAccountName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox _lbTo;
        private System.Windows.Forms.ListBox _lbBcc;
        private System.Windows.Forms.ListBox _lbCc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label _lblNumberOfAttachments;
        private System.Windows.Forms.Label label5;
    }
}