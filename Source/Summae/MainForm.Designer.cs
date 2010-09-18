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
            this.tool = new System.Windows.Forms.ToolStrip();
            this.toolHelpAbout = new System.Windows.Forms.ToolStripButton();
            this.toolHelpReportABug = new System.Windows.Forms.ToolStripButton();
            this.toolToolsSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolFileNew = new System.Windows.Forms.ToolStripButton();
            this.toolFileOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolFileCalculate = new System.Windows.Forms.ToolStripButton();
            this.checkedMethods = new System.Windows.Forms.CheckedListBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.lsvFiles = new System.Windows.Forms.ListView();
            this.lsvFiles_colFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvFiles_colDirectory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tool.SuspendLayout();
            this.SuspendLayout();
            // 
            // tool
            // 
            this.tool.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolHelpAbout,
            this.toolHelpReportABug,
            this.toolToolsSettings,
            this.toolStripSeparator1,
            this.toolFileNew,
            this.toolFileOpen,
            this.toolStripSeparator2,
            this.toolFileCalculate});
            this.tool.Location = new System.Drawing.Point(0, 0);
            this.tool.Name = "tool";
            this.tool.Size = new System.Drawing.Size(622, 27);
            this.tool.TabIndex = 2;
            // 
            // toolHelpAbout
            // 
            this.toolHelpAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolHelpAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolHelpAbout.Image")));
            this.toolHelpAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolHelpAbout.Name = "toolHelpAbout";
            this.toolHelpAbout.Size = new System.Drawing.Size(70, 24);
            this.toolHelpAbout.Text = "&About";
            this.toolHelpAbout.Click += new System.EventHandler(this.toolHelpAbout_Click);
            // 
            // toolHelpReportABug
            // 
            this.toolHelpReportABug.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolHelpReportABug.Image = ((System.Drawing.Image)(resources.GetObject("toolHelpReportABug.Image")));
            this.toolHelpReportABug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolHelpReportABug.Name = "toolHelpReportABug";
            this.toolHelpReportABug.Size = new System.Drawing.Size(116, 24);
            this.toolHelpReportABug.Text = "&Report a bug";
            this.toolHelpReportABug.Click += new System.EventHandler(this.toolHelpReportABug_Click);
            // 
            // toolToolsSettings
            // 
            this.toolToolsSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolToolsSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolToolsSettings.Image")));
            this.toolToolsSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolToolsSettings.Name = "toolToolsSettings";
            this.toolToolsSettings.Size = new System.Drawing.Size(81, 24);
            this.toolToolsSettings.Text = "&Options";
            this.toolToolsSettings.Click += new System.EventHandler(this.toolToolsSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolFileNew
            // 
            this.toolFileNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFileNew.Image = ((System.Drawing.Image)(resources.GetObject("toolFileNew.Image")));
            this.toolFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFileNew.Name = "toolFileNew";
            this.toolFileNew.Size = new System.Drawing.Size(23, 24);
            this.toolFileNew.Text = "Clear list";
            this.toolFileNew.ToolTipText = "Clear list (Ctrl+N)";
            this.toolFileNew.Click += new System.EventHandler(this.toolFileNew_Click);
            // 
            // toolFileOpen
            // 
            this.toolFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolFileOpen.Image")));
            this.toolFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFileOpen.Name = "toolFileOpen";
            this.toolFileOpen.Size = new System.Drawing.Size(82, 24);
            this.toolFileOpen.Text = "Add file";
            this.toolFileOpen.ToolTipText = "Add file (Ctrl+O)";
            this.toolFileOpen.Click += new System.EventHandler(this.toolFileOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolFileCalculate
            // 
            this.toolFileCalculate.Enabled = false;
            this.toolFileCalculate.Image = ((System.Drawing.Image)(resources.GetObject("toolFileCalculate.Image")));
            this.toolFileCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFileCalculate.Name = "toolFileCalculate";
            this.toolFileCalculate.Size = new System.Drawing.Size(90, 24);
            this.toolFileCalculate.Text = "Calculate";
            this.toolFileCalculate.ToolTipText = "Calculate (F5)";
            this.toolFileCalculate.Click += new System.EventHandler(this.toolFileCalculate_Click);
            // 
            // checkedMethods
            // 
            this.checkedMethods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedMethods.CheckOnClick = true;
            this.checkedMethods.FormattingEnabled = true;
            this.checkedMethods.IntegralHeight = false;
            this.checkedMethods.Location = new System.Drawing.Point(482, 30);
            this.checkedMethods.Name = "checkedMethods";
            this.checkedMethods.Size = new System.Drawing.Size(128, 313);
            this.checkedMethods.TabIndex = 1;
            this.checkedMethods.ThreeDCheckBoxes = true;
            this.checkedMethods.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedMethods_ItemCheck);
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
            this.lsvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lsvFiles_colFile,
            this.lsvFiles_colDirectory});
            this.lsvFiles.FullRowSelect = true;
            this.lsvFiles.GridLines = true;
            this.lsvFiles.Location = new System.Drawing.Point(12, 30);
            this.lsvFiles.MultiSelect = false;
            this.lsvFiles.Name = "lsvFiles";
            this.lsvFiles.ShowItemToolTips = true;
            this.lsvFiles.Size = new System.Drawing.Size(464, 313);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 355);
            this.Controls.Add(this.lsvFiles);
            this.Controls.Add(this.checkedMethods);
            this.Controls.Add(this.tool);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.Text = "Summae";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tool.ResumeLayout(false);
            this.tool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool;
        private System.Windows.Forms.ToolStripButton toolHelpReportABug;
        private System.Windows.Forms.ToolStripButton toolHelpAbout;
        private System.Windows.Forms.ToolStripButton toolToolsSettings;
        private System.Windows.Forms.CheckedListBox checkedMethods;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolFileNew;
        private System.Windows.Forms.ToolStripButton toolFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolFileCalculate;
        private System.Windows.Forms.ListView lsvFiles;
        private System.Windows.Forms.ColumnHeader lsvFiles_colFile;
        private System.Windows.Forms.ColumnHeader lsvFiles_colDirectory;
    }
}

