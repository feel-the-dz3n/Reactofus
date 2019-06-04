namespace Reactofus
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRamDisk = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseISORamDisk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRamDiskISOPath = new System.Windows.Forms.TextBox();
            this.tabPageMore = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBugReport = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnGitHub = new System.Windows.Forms.Button();
            this.cbAvailableDevices = new System.Windows.Forms.ComboBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.cbPause = new System.Windows.Forms.CheckBox();
            this.cbFormatDrive = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.cbVolume = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPageRamDisk.SuspendLayout();
            this.tabPageMore.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageRamDisk);
            this.tabControl1.Controls.Add(this.tabPageMore);
            this.tabControl1.Location = new System.Drawing.Point(12, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(361, 190);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageRamDisk
            // 
            this.tabPageRamDisk.Controls.Add(this.label3);
            this.tabPageRamDisk.Controls.Add(this.btnBrowseISORamDisk);
            this.tabPageRamDisk.Controls.Add(this.label2);
            this.tabPageRamDisk.Controls.Add(this.tbRamDiskISOPath);
            this.tabPageRamDisk.Location = new System.Drawing.Point(4, 22);
            this.tabPageRamDisk.Name = "tabPageRamDisk";
            this.tabPageRamDisk.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRamDisk.Size = new System.Drawing.Size(353, 164);
            this.tabPageRamDisk.TabIndex = 0;
            this.tabPageRamDisk.Text = "RamDisk ISO";
            this.tabPageRamDisk.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(0, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Required file system: FAT32";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBrowseISORamDisk
            // 
            this.btnBrowseISORamDisk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowseISORamDisk.Location = new System.Drawing.Point(315, 62);
            this.btnBrowseISORamDisk.Name = "btnBrowseISORamDisk";
            this.btnBrowseISORamDisk.Size = new System.Drawing.Size(32, 23);
            this.btnBrowseISORamDisk.TabIndex = 2;
            this.btnBrowseISORamDisk.Text = "...";
            this.btnBrowseISORamDisk.UseVisualStyleBackColor = true;
            this.btnBrowseISORamDisk.Click += new System.EventHandler(this.btnBrowseISORamDisk_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ReactOS ISO Path (livecd/bootcd):";
            // 
            // tbRamDiskISOPath
            // 
            this.tbRamDiskISOPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRamDiskISOPath.Location = new System.Drawing.Point(6, 64);
            this.tbRamDiskISOPath.Name = "tbRamDiskISOPath";
            this.tbRamDiskISOPath.Size = new System.Drawing.Size(303, 20);
            this.tbRamDiskISOPath.TabIndex = 0;
            // 
            // tabPageMore
            // 
            this.tabPageMore.Controls.Add(this.label1);
            this.tabPageMore.Controls.Add(this.btnBugReport);
            this.tabPageMore.Controls.Add(this.btnSettings);
            this.tabPageMore.Controls.Add(this.btnGitHub);
            this.tabPageMore.Location = new System.Drawing.Point(4, 22);
            this.tabPageMore.Name = "tabPageMore";
            this.tabPageMore.Size = new System.Drawing.Size(353, 191);
            this.tabPageMore.TabIndex = 1;
            this.tabPageMore.Text = "More";
            this.tabPageMore.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(0, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Reactofus";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBugReport
            // 
            this.btnBugReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBugReport.Location = new System.Drawing.Point(121, 133);
            this.btnBugReport.Name = "btnBugReport";
            this.btnBugReport.Size = new System.Drawing.Size(112, 23);
            this.btnBugReport.TabIndex = 13;
            this.btnBugReport.Text = "Report a bug";
            this.btnBugReport.UseVisualStyleBackColor = true;
            this.btnBugReport.Click += new System.EventHandler(this.btnBugReport_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSettings.Location = new System.Drawing.Point(121, 104);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(112, 23);
            this.btnSettings.TabIndex = 12;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnGitHub
            // 
            this.btnGitHub.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGitHub.Location = new System.Drawing.Point(121, 75);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new System.Drawing.Size(112, 23);
            this.btnGitHub.TabIndex = 11;
            this.btnGitHub.Text = "GitHub Repo";
            this.btnGitHub.UseVisualStyleBackColor = true;
            this.btnGitHub.Click += new System.EventHandler(this.btnGitHub_Click);
            // 
            // cbAvailableDevices
            // 
            this.cbAvailableDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAvailableDevices.FormattingEnabled = true;
            this.cbAvailableDevices.Location = new System.Drawing.Point(12, 12);
            this.cbAvailableDevices.Name = "cbAvailableDevices";
            this.cbAvailableDevices.Size = new System.Drawing.Size(361, 21);
            this.cbAvailableDevices.TabIndex = 1;
            this.cbAvailableDevices.Text = "Choose USB device";
            this.cbAvailableDevices.DropDown += new System.EventHandler(this.cbAvailableDevices_DropDown);
            this.cbAvailableDevices.SelectedIndexChanged += new System.EventHandler(this.cbAvailableDevices_SelectedIndexChanged);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.Location = new System.Drawing.Point(294, 260);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "Start (stop)";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // cbPause
            // 
            this.cbPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbPause.Location = new System.Drawing.Point(258, 260);
            this.cbPause.Name = "cbPause";
            this.cbPause.Size = new System.Drawing.Size(30, 23);
            this.cbPause.TabIndex = 4;
            this.cbPause.Text = "| |";
            this.cbPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbPause.UseVisualStyleBackColor = true;
            // 
            // cbFormatDrive
            // 
            this.cbFormatDrive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFormatDrive.AutoSize = true;
            this.cbFormatDrive.Location = new System.Drawing.Point(194, 264);
            this.cbFormatDrive.Name = "cbFormatDrive";
            this.cbFormatDrive.Size = new System.Drawing.Size(58, 17);
            this.cbFormatDrive.TabIndex = 8;
            this.cbFormatDrive.Text = "Format";
            this.cbFormatDrive.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbStatus,
            this.statusProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 288);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(385, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbStatus
            // 
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(223, 17);
            this.tbStatus.Spring = true;
            this.tbStatus.Text = "Ready";
            this.tbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusProgress
            // 
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(145, 16);
            this.statusProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // cbVolume
            // 
            this.cbVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVolume.FormattingEnabled = true;
            this.cbVolume.Location = new System.Drawing.Point(12, 39);
            this.cbVolume.Name = "cbVolume";
            this.cbVolume.Size = new System.Drawing.Size(361, 21);
            this.cbVolume.TabIndex = 10;
            this.cbVolume.Text = "Choose volume";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 310);
            this.Controls.Add(this.cbVolume);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbFormatDrive);
            this.Controls.Add(this.cbPause);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.cbAvailableDevices);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reactofus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRamDisk.ResumeLayout(false);
            this.tabPageRamDisk.PerformLayout();
            this.tabPageMore.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRamDisk;
        private System.Windows.Forms.ComboBox cbAvailableDevices;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.CheckBox cbPause;
        private System.Windows.Forms.CheckBox cbFormatDrive;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tbStatus;
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
        private System.Windows.Forms.Button btnBrowseISORamDisk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRamDiskISOPath;
        private System.Windows.Forms.TabPage tabPageMore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBugReport;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnGitHub;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVolume;
    }
}

