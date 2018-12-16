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
            this.groupContextMenu = new System.Windows.Forms.GroupBox();
            this.chbJustApplication = new System.Windows.Forms.CheckBox();
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
            this.chbSpacedHash = new System.Windows.Forms.CheckBox();
            this.chbUppercaseHash = new System.Windows.Forms.CheckBox();
            this.groupContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupContextMenu
            // 
            this.groupContextMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupContextMenu.Controls.Add(this.chbJustApplication);
            this.groupContextMenu.Controls.Add(this.chbSha512);
            this.groupContextMenu.Controls.Add(this.chbSha384);
            this.groupContextMenu.Controls.Add(this.chbSha256);
            this.groupContextMenu.Controls.Add(this.chbSha1);
            this.groupContextMenu.Controls.Add(this.chbRipeMd160);
            this.groupContextMenu.Controls.Add(this.chbMd5);
            this.groupContextMenu.Controls.Add(this.chbCrc32);
            this.groupContextMenu.Controls.Add(this.chbCrc16);
            this.groupContextMenu.Location = new System.Drawing.Point(12, 12);
            this.groupContextMenu.Name = "groupContextMenu";
            this.groupContextMenu.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupContextMenu.Size = new System.Drawing.Size(250, 146);
            this.groupContextMenu.TabIndex = 1;
            this.groupContextMenu.TabStop = false;
            this.groupContextMenu.Text = "Show on system context menu";
            // 
            // chbJustApplication
            // 
            this.chbJustApplication.AutoSize = true;
            this.chbJustApplication.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbJustApplication.Location = new System.Drawing.Point(5, 27);
            this.chbJustApplication.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.chbJustApplication.Name = "chbJustApplication";
            this.chbJustApplication.Size = new System.Drawing.Size(105, 18);
            this.chbJustApplication.TabIndex = 0;
            this.chbJustApplication.Text = "Just application";
            this.chbJustApplication.UseVisualStyleBackColor = true;
            this.chbJustApplication.CheckedChanged += new System.EventHandler(this.chbContextMenu_CheckedChanged);
            // 
            // chbSha512
            // 
            this.chbSha512.AutoSize = true;
            this.chbSha512.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbSha512.Location = new System.Drawing.Point(127, 123);
            this.chbSha512.Name = "chbSha512";
            this.chbSha512.Size = new System.Drawing.Size(75, 18);
            this.chbSha512.TabIndex = 8;
            this.chbSha512.Text = "SHA-512";
            this.chbSha512.UseVisualStyleBackColor = true;
            this.chbSha512.CheckedChanged += new System.EventHandler(this.chbContextMenu_CheckedChanged);
            // 
            // chbSha384
            // 
            this.chbSha384.AutoSize = true;
            this.chbSha384.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbSha384.Location = new System.Drawing.Point(127, 99);
            this.chbSha384.Name = "chbSha384";
            this.chbSha384.Size = new System.Drawing.Size(75, 18);
            this.chbSha384.TabIndex = 7;
            this.chbSha384.Text = "SHA-384";
            this.chbSha384.UseVisualStyleBackColor = true;
            this.chbSha384.CheckedChanged += new System.EventHandler(this.chbContextMenu_CheckedChanged);
            // 
            // chbSha256
            // 
            this.chbSha256.AutoSize = true;
            this.chbSha256.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbSha256.Location = new System.Drawing.Point(127, 75);
            this.chbSha256.Name = "chbSha256";
            this.chbSha256.Size = new System.Drawing.Size(75, 18);
            this.chbSha256.TabIndex = 6;
            this.chbSha256.Text = "SHA-256";
            this.chbSha256.UseVisualStyleBackColor = true;
            this.chbSha256.CheckedChanged += new System.EventHandler(this.chbContextMenu_CheckedChanged);
            // 
            // chbSha1
            // 
            this.chbSha1.AutoSize = true;
            this.chbSha1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbSha1.Location = new System.Drawing.Point(127, 51);
            this.chbSha1.Name = "chbSha1";
            this.chbSha1.Size = new System.Drawing.Size(63, 18);
            this.chbSha1.TabIndex = 5;
            this.chbSha1.Text = "SHA-1";
            this.chbSha1.UseVisualStyleBackColor = true;
            this.chbSha1.CheckedChanged += new System.EventHandler(this.chbContextMenu_CheckedChanged);
            // 
            // chbRipeMd160
            // 
            this.chbRipeMd160.AutoSize = true;
            this.chbRipeMd160.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbRipeMd160.Location = new System.Drawing.Point(5, 123);
            this.chbRipeMd160.Name = "chbRipeMd160";
            this.chbRipeMd160.Size = new System.Drawing.Size(98, 18);
            this.chbRipeMd160.TabIndex = 4;
            this.chbRipeMd160.Text = "RIPE MD-160";
            this.chbRipeMd160.UseVisualStyleBackColor = true;
            this.chbRipeMd160.CheckedChanged += new System.EventHandler(this.chbContextMenu_CheckedChanged);
            // 
            // chbMd5
            // 
            this.chbMd5.AutoSize = true;
            this.chbMd5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbMd5.Location = new System.Drawing.Point(5, 99);
            this.chbMd5.Name = "chbMd5";
            this.chbMd5.Size = new System.Drawing.Size(58, 18);
            this.chbMd5.TabIndex = 3;
            this.chbMd5.Text = "MD-5";
            this.chbMd5.UseVisualStyleBackColor = true;
            this.chbMd5.CheckedChanged += new System.EventHandler(this.chbContextMenu_CheckedChanged);
            // 
            // chbCrc32
            // 
            this.chbCrc32.AutoSize = true;
            this.chbCrc32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbCrc32.Location = new System.Drawing.Point(5, 75);
            this.chbCrc32.Name = "chbCrc32";
            this.chbCrc32.Size = new System.Drawing.Size(69, 18);
            this.chbCrc32.TabIndex = 2;
            this.chbCrc32.Text = "CRC-32";
            this.chbCrc32.UseVisualStyleBackColor = true;
            this.chbCrc32.CheckedChanged += new System.EventHandler(this.chbContextMenu_CheckedChanged);
            // 
            // chbCrc16
            // 
            this.chbCrc16.AutoSize = true;
            this.chbCrc16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbCrc16.Location = new System.Drawing.Point(5, 51);
            this.chbCrc16.Name = "chbCrc16";
            this.chbCrc16.Size = new System.Drawing.Size(69, 18);
            this.chbCrc16.TabIndex = 1;
            this.chbCrc16.Text = "CRC-16";
            this.chbCrc16.UseVisualStyleBackColor = true;
            this.chbCrc16.CheckedChanged += new System.EventHandler(this.chbContextMenu_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(106, 228);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(187, 228);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chbSpacedHash
            // 
            this.chbSpacedHash.AutoSize = true;
            this.chbSpacedHash.Location = new System.Drawing.Point(12, 173);
            this.chbSpacedHash.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.chbSpacedHash.Name = "chbSpacedHash";
            this.chbSpacedHash.Size = new System.Drawing.Size(120, 17);
            this.chbSpacedHash.TabIndex = 2;
            this.chbSpacedHash.Text = "Add spaces to hash";
            this.chbSpacedHash.UseVisualStyleBackColor = true;
            // 
            // chbUppercaseHash
            // 
            this.chbUppercaseHash.AutoSize = true;
            this.chbUppercaseHash.Location = new System.Drawing.Point(12, 196);
            this.chbUppercaseHash.Name = "chbUppercaseHash";
            this.chbUppercaseHash.Size = new System.Drawing.Size(104, 17);
            this.chbUppercaseHash.TabIndex = 3;
            this.chbUppercaseHash.Text = "Uppercase hash";
            this.chbUppercaseHash.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(274, 263);
            this.Controls.Add(this.chbUppercaseHash);
            this.Controls.Add(this.chbSpacedHash);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupContextMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupContextMenu.ResumeLayout(false);
            this.groupContextMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.CheckBox chbJustApplication;
        private System.Windows.Forms.CheckBox chbSpacedHash;
        private System.Windows.Forms.CheckBox chbUppercaseHash;
    }
}