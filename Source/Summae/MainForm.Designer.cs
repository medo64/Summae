namespace Summae {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnu = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.lsvFiles = new System.Windows.Forms.ListView();
            this.lsvFiles_colFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvFiles_colDirectory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bwCheckForUpgrade = new System.ComponentModel.BackgroundWorker();
            this.mnuApp = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuAppOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppOptionsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAppFeedback = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAppAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripButton();
            this.mnuOpen = new System.Windows.Forms.ToolStripButton();
            this.mnuCalculate = new System.Windows.Forms.ToolStripSplitButton();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuApp,
            this.mnuNew,
            this.mnuOpen,
            this.toolStripSeparator2,
            this.mnuCalculate});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.mnu.Size = new System.Drawing.Size(622, 27);
            this.mnu.TabIndex = 2;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // ofd
            // 
            this.ofd.Filter = "All files|*.*";
            this.ofd.Multiselect = true;
            this.ofd.RestoreDirectory = true;
            // 
            // lsvFiles
            // 
            this.lsvFiles.AllowDrop = true;
            this.lsvFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lsvFiles_colFile,
            this.lsvFiles_colDirectory});
            this.lsvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvFiles.FullRowSelect = true;
            this.lsvFiles.GridLines = true;
            this.lsvFiles.Location = new System.Drawing.Point(0, 27);
            this.lsvFiles.MultiSelect = false;
            this.lsvFiles.Name = "lsvFiles";
            this.lsvFiles.ShowItemToolTips = true;
            this.lsvFiles.Size = new System.Drawing.Size(622, 328);
            this.lsvFiles.TabIndex = 0;
            this.lsvFiles.UseCompatibleStateImageBehavior = false;
            this.lsvFiles.View = System.Windows.Forms.View.Details;
            this.lsvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsvFiles_DragDrop);
            this.lsvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lsvFiles_DragEnter);
            this.lsvFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvFiles_KeyDown);
            // 
            // lsvFiles_colFile
            // 
            this.lsvFiles_colFile.Text = "File";
            this.lsvFiles_colFile.Width = 240;
            // 
            // lsvFiles_colDirectory
            // 
            this.lsvFiles_colDirectory.Text = "Folder";
            this.lsvFiles_colDirectory.Width = 180;
            // 
            // bwCheckForUpgrade
            // 
            this.bwCheckForUpgrade.WorkerSupportsCancellation = true;
            this.bwCheckForUpgrade.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCheckForUpgrade_DoWork);
            this.bwCheckForUpgrade.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCheckForUpgrade_RunWorkerCompleted);
            // 
            // mnuApp
            // 
            this.mnuApp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAppOptions,
            this.mnuAppOptionsSeparator,
            this.mnuAppFeedback,
            this.mnuAppUpgrade,
            this.toolStripMenuItem1,
            this.mnuAppAbout});
            this.mnuApp.Image = global::Summae.Properties.Resources.mnuApp_16;
            this.mnuApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuApp.Name = "mnuApp";
            this.mnuApp.Size = new System.Drawing.Size(34, 24);
            this.mnuApp.Text = "Application";
            // 
            // mnuAppOptions
            // 
            this.mnuAppOptions.Name = "mnuAppOptions";
            this.mnuAppOptions.Size = new System.Drawing.Size(182, 26);
            this.mnuAppOptions.Text = "Options";
            this.mnuAppOptions.Click += new System.EventHandler(this.mnuAppOptions_Click);
            // 
            // mnuAppOptionsSeparator
            // 
            this.mnuAppOptionsSeparator.Name = "mnuAppOptionsSeparator";
            this.mnuAppOptionsSeparator.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuAppFeedback
            // 
            this.mnuAppFeedback.Name = "mnuAppFeedback";
            this.mnuAppFeedback.Size = new System.Drawing.Size(182, 26);
            this.mnuAppFeedback.Text = "Send &feedback";
            this.mnuAppFeedback.Click += new System.EventHandler(this.mnuAppFeedback_Click);
            // 
            // mnuAppUpgrade
            // 
            this.mnuAppUpgrade.Name = "mnuAppUpgrade";
            this.mnuAppUpgrade.Size = new System.Drawing.Size(182, 26);
            this.mnuAppUpgrade.Text = "&Upgrade";
            this.mnuAppUpgrade.Click += new System.EventHandler(this.mnuAppUpgrade_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuAppAbout
            // 
            this.mnuAppAbout.Name = "mnuAppAbout";
            this.mnuAppAbout.Size = new System.Drawing.Size(182, 26);
            this.mnuAppAbout.Text = "&About";
            this.mnuAppAbout.Click += new System.EventHandler(this.mnuAppAbout_Click);
            // 
            // mnuNew
            // 
            this.mnuNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuNew.Image = global::Summae.Properties.Resources.mnuNew_16;
            this.mnuNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(24, 24);
            this.mnuNew.Text = "Clear list";
            this.mnuNew.ToolTipText = "Clear list (Ctrl+N)";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = global::Summae.Properties.Resources.mnuOpen_16;
            this.mnuOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(86, 24);
            this.mnuOpen.Text = "Add file";
            this.mnuOpen.ToolTipText = "Add file (Ctrl+O)";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuCalculate
            // 
            this.mnuCalculate.Enabled = false;
            this.mnuCalculate.Image = global::Summae.Properties.Resources.mnuCalculate_16;
            this.mnuCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCalculate.Name = "mnuCalculate";
            this.mnuCalculate.Size = new System.Drawing.Size(109, 24);
            this.mnuCalculate.Text = "Calculate";
            this.mnuCalculate.ToolTipText = "Calculate (F5)";
            this.mnuCalculate.ButtonClick += new System.EventHandler(this.mnuCalculate_ButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 355);
            this.Controls.Add(this.lsvFiles);
            this.Controls.Add(this.mnu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.Text = "Summae";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnu;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ToolStripButton mnuNew;
        private System.Windows.Forms.ToolStripButton mnuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ListView lsvFiles;
        private System.Windows.Forms.ColumnHeader lsvFiles_colFile;
        private System.Windows.Forms.ColumnHeader lsvFiles_colDirectory;
        private System.Windows.Forms.ToolStripDropDownButton mnuApp;
        private System.Windows.Forms.ToolStripMenuItem mnuAppFeedback;
        private System.Windows.Forms.ToolStripSeparator mnuAppOptionsSeparator;
        private System.Windows.Forms.ToolStripMenuItem mnuAppAbout;
        private System.Windows.Forms.ToolStripSplitButton mnuCalculate;
        private System.Windows.Forms.ToolStripMenuItem mnuAppUpgrade;
        private System.ComponentModel.BackgroundWorker bwCheckForUpgrade;
        private System.Windows.Forms.ToolStripMenuItem mnuAppOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}

