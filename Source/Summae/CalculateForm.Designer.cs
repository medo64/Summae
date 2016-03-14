namespace Summae {
    partial class CalculateForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculateForm));
            this.progress = new System.Windows.Forms.ProgressBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.bwFileReader = new System.ComponentModel.BackgroundWorker();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 166);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(431, 23);
            this.progress.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(343, 207);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // bwFileReader
            // 
            this.bwFileReader.WorkerReportsProgress = true;
            this.bwFileReader.WorkerSupportsCancellation = true;
            this.bwFileReader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFileReader_DoWork);
            this.bwFileReader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwFileReader_ProgressChanged);
            this.bwFileReader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFileReader_RunWorkerCompleted);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(9, 218);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(12, 17);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = " ";
            this.labelSpeed.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(9, 15);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(73, 17);
            this.labelFileName.TabIndex = 1;
            this.labelFileName.Text = "File name:";
            // 
            // textFileName
            // 
            this.textFileName.Location = new System.Drawing.Point(98, 12);
            this.textFileName.Name = "textFileName";
            this.textFileName.ReadOnly = true;
            this.textFileName.Size = new System.Drawing.Size(345, 22);
            this.textFileName.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(455, 247);
            this.Controls.Add(this.textFileName);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Summae";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Button buttonCancel;
        private System.ComponentModel.BackgroundWorker bwFileReader;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.TextBox textFileName;
        private System.Windows.Forms.ToolTip toolTip;
    }
}