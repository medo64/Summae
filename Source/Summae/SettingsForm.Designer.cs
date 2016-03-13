namespace Summae {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblWarning = new System.Windows.Forms.Label();
            this.groupContextMenu = new System.Windows.Forms.GroupBox();
            this.chbSha512 = new System.Windows.Forms.CheckBox();
            this.chbSha384 = new System.Windows.Forms.CheckBox();
            this.chbSha256 = new System.Windows.Forms.CheckBox();
            this.chbSha1 = new System.Windows.Forms.CheckBox();
            this.chbRipeMd160 = new System.Windows.Forms.CheckBox();
            this.chbMd5 = new System.Windows.Forms.CheckBox();
            this.chbCrc32 = new System.Windows.Forms.CheckBox();
            this.chbCrc16 = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.Location = new System.Drawing.Point(12, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(330, 70);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "Changing context (right-click) menu for files is system-wide operation that will " +
    "affect all users. Take care.";
            // 
            // groupContextMenu
            // 
            this.groupContextMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupContextMenu.Controls.Add(this.chbSha512);
            this.groupContextMenu.Controls.Add(this.chbSha384);
            this.groupContextMenu.Controls.Add(this.chbSha256);
            this.groupContextMenu.Controls.Add(this.chbSha1);
            this.groupContextMenu.Controls.Add(this.chbRipeMd160);
            this.groupContextMenu.Controls.Add(this.chbMd5);
            this.groupContextMenu.Controls.Add(this.chbCrc32);
            this.groupContextMenu.Controls.Add(this.chbCrc16);
            this.groupContextMenu.Location = new System.Drawing.Point(12, 82);
            this.groupContextMenu.Name = "groupContextMenu";
            this.groupContextMenu.Size = new System.Drawing.Size(330, 133);
            this.groupContextMenu.TabIndex = 2;
            this.groupContextMenu.TabStop = false;
            this.groupContextMenu.Text = "Show on system context menu";
            // 
            // chbSha512
            // 
            this.chbSha512.AutoSize = true;
            this.chbSha512.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbSha512.Location = new System.Drawing.Point(171, 105);
            this.chbSha512.Name = "chbSha512";
            this.chbSha512.Size = new System.Drawing.Size(90, 22);
            this.chbSha512.TabIndex = 8;
            this.chbSha512.Text = "SHA-512";
            this.chbSha512.UseVisualStyleBackColor = true;
            // 
            // chbSha384
            // 
            this.chbSha384.AutoSize = true;
            this.chbSha384.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbSha384.Location = new System.Drawing.Point(171, 77);
            this.chbSha384.Name = "chbSha384";
            this.chbSha384.Size = new System.Drawing.Size(90, 22);
            this.chbSha384.TabIndex = 7;
            this.chbSha384.Text = "SHA-384";
            this.chbSha384.UseVisualStyleBackColor = true;
            // 
            // chbSha256
            // 
            this.chbSha256.AutoSize = true;
            this.chbSha256.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbSha256.Location = new System.Drawing.Point(171, 49);
            this.chbSha256.Name = "chbSha256";
            this.chbSha256.Size = new System.Drawing.Size(90, 22);
            this.chbSha256.TabIndex = 6;
            this.chbSha256.Text = "SHA-256";
            this.chbSha256.UseVisualStyleBackColor = true;
            // 
            // chbSha1
            // 
            this.chbSha1.AutoSize = true;
            this.chbSha1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbSha1.Location = new System.Drawing.Point(171, 21);
            this.chbSha1.Name = "chbSha1";
            this.chbSha1.Size = new System.Drawing.Size(74, 22);
            this.chbSha1.TabIndex = 5;
            this.chbSha1.Text = "SHA-1";
            this.chbSha1.UseVisualStyleBackColor = true;
            // 
            // chbRipeMd160
            // 
            this.chbRipeMd160.AutoSize = true;
            this.chbRipeMd160.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbRipeMd160.Location = new System.Drawing.Point(6, 105);
            this.chbRipeMd160.Name = "chbRipeMd160";
            this.chbRipeMd160.Size = new System.Drawing.Size(118, 22);
            this.chbRipeMd160.TabIndex = 4;
            this.chbRipeMd160.Text = "RIPE MD-160";
            this.chbRipeMd160.UseVisualStyleBackColor = true;
            // 
            // chbMd5
            // 
            this.chbMd5.AutoSize = true;
            this.chbMd5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbMd5.Location = new System.Drawing.Point(6, 77);
            this.chbMd5.Name = "chbMd5";
            this.chbMd5.Size = new System.Drawing.Size(67, 22);
            this.chbMd5.TabIndex = 3;
            this.chbMd5.Text = "MD-5";
            this.chbMd5.UseVisualStyleBackColor = true;
            // 
            // chbCrc32
            // 
            this.chbCrc32.AutoSize = true;
            this.chbCrc32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbCrc32.Location = new System.Drawing.Point(6, 49);
            this.chbCrc32.Name = "chbCrc32";
            this.chbCrc32.Size = new System.Drawing.Size(82, 22);
            this.chbCrc32.TabIndex = 2;
            this.chbCrc32.Text = "CRC-32";
            this.chbCrc32.UseVisualStyleBackColor = true;
            // 
            // chbCrc16
            // 
            this.chbCrc16.AutoSize = true;
            this.chbCrc16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbCrc16.Location = new System.Drawing.Point(6, 21);
            this.chbCrc16.Name = "chbCrc16";
            this.chbCrc16.Size = new System.Drawing.Size(82, 22);
            this.chbCrc16.TabIndex = 1;
            this.chbCrc16.Text = "CRC-16";
            this.chbCrc16.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(136, 227);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(242, 227);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 267);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupContextMenu);
            this.Controls.Add(this.lblWarning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupContextMenu.ResumeLayout(false);
            this.groupContextMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.GroupBox groupContextMenu;
        private System.Windows.Forms.CheckBox chbSha512;
        private System.Windows.Forms.CheckBox chbSha384;
        private System.Windows.Forms.CheckBox chbSha256;
        private System.Windows.Forms.CheckBox chbSha1;
        private System.Windows.Forms.CheckBox chbRipeMd160;
        private System.Windows.Forms.CheckBox chbMd5;
        private System.Windows.Forms.CheckBox chbCrc32;
        private System.Windows.Forms.CheckBox chbCrc16;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}