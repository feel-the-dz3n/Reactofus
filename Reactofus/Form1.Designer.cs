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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMore = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBugReport = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnGitHub = new System.Windows.Forms.Button();
            this.tabPageInstallReactOS = new System.Windows.Forms.TabPage();
            this.cbReactOSEditions = new System.Windows.Forms.ComboBox();
            this.lblInstallReactOSStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBrowseInsatallReactOS = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPathInstallReactOS = new System.Windows.Forms.TextBox();
            this.tabPageRamDisk = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseISORamDisk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRamDiskISOPath = new System.Windows.Forms.TextBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.cbPause = new System.Windows.Forms.CheckBox();
            this.cbFormatDrive = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.linkSetDrive = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbEnableBetaInstall = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPageMore.SuspendLayout();
            this.tabPageInstallReactOS.SuspendLayout();
            this.tabPageRamDisk.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageMore);
            this.tabControl1.Controls.Add(this.tabPageInstallReactOS);
            this.tabControl1.Controls.Add(this.tabPageRamDisk);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(536, 253);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageMore
            // 
            this.tabPageMore.Controls.Add(this.label4);
            this.tabPageMore.Controls.Add(this.label1);
            this.tabPageMore.Controls.Add(this.btnBugReport);
            this.tabPageMore.Controls.Add(this.btnSettings);
            this.tabPageMore.Controls.Add(this.btnGitHub);
            this.tabPageMore.Location = new System.Drawing.Point(4, 22);
            this.tabPageMore.Name = "tabPageMore";
            this.tabPageMore.Size = new System.Drawing.Size(528, 227);
            this.tabPageMore.TabIndex = 1;
            this.tabPageMore.Text = "Main";
            this.tabPageMore.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(522, 40);
            this.label4.TabIndex = 15;
            this.label4.Text = "Reactofus uses some licensed products:\r\nCab Compression - Copyright (c) 1999, Mic" +
    "rosoft Corporation.  All rights reserved.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(0, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Reactofus";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBugReport
            // 
            this.btnBugReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBugReport.Location = new System.Drawing.Point(209, 133);
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
            this.btnSettings.Location = new System.Drawing.Point(209, 66);
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
            this.btnGitHub.Location = new System.Drawing.Point(209, 104);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new System.Drawing.Size(112, 23);
            this.btnGitHub.TabIndex = 11;
            this.btnGitHub.Text = "GitHub Repo";
            this.btnGitHub.UseVisualStyleBackColor = true;
            this.btnGitHub.Click += new System.EventHandler(this.btnGitHub_Click);
            // 
            // tabPageInstallReactOS
            // 
            this.tabPageInstallReactOS.Controls.Add(this.cbEnableBetaInstall);
            this.tabPageInstallReactOS.Controls.Add(this.panel1);
            this.tabPageInstallReactOS.Location = new System.Drawing.Point(4, 22);
            this.tabPageInstallReactOS.Name = "tabPageInstallReactOS";
            this.tabPageInstallReactOS.Size = new System.Drawing.Size(528, 227);
            this.tabPageInstallReactOS.TabIndex = 2;
            this.tabPageInstallReactOS.Text = "Install ReactOS (WIP)";
            this.tabPageInstallReactOS.UseVisualStyleBackColor = true;
            // 
            // cbReactOSEditions
            // 
            this.cbReactOSEditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReactOSEditions.FormattingEnabled = true;
            this.cbReactOSEditions.Location = new System.Drawing.Point(6, 101);
            this.cbReactOSEditions.Name = "cbReactOSEditions";
            this.cbReactOSEditions.Size = new System.Drawing.Size(519, 21);
            this.cbReactOSEditions.TabIndex = 9;
            // 
            // lblInstallReactOSStatus
            // 
            this.lblInstallReactOSStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInstallReactOSStatus.AutoSize = true;
            this.lblInstallReactOSStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblInstallReactOSStatus.Location = new System.Drawing.Point(3, 85);
            this.lblInstallReactOSStatus.Name = "lblInstallReactOSStatus";
            this.lblInstallReactOSStatus.Size = new System.Drawing.Size(67, 13);
            this.lblInstallReactOSStatus.TabIndex = 8;
            this.lblInstallReactOSStatus.Text = "Choose path";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(2, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(523, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "Required file system: FAT32";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBrowseInsatallReactOS
            // 
            this.btnBrowseInsatallReactOS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowseInsatallReactOS.Location = new System.Drawing.Point(493, 58);
            this.btnBrowseInsatallReactOS.Name = "btnBrowseInsatallReactOS";
            this.btnBrowseInsatallReactOS.Size = new System.Drawing.Size(32, 23);
            this.btnBrowseInsatallReactOS.TabIndex = 6;
            this.btnBrowseInsatallReactOS.Text = "...";
            this.btnBrowseInsatallReactOS.UseVisualStyleBackColor = true;
            this.btnBrowseInsatallReactOS.Click += new System.EventHandler(this.BtnBrowseInsatallReactOS_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "ReactOS Installation/LiveCD Files:";
            // 
            // tbPathInstallReactOS
            // 
            this.tbPathInstallReactOS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPathInstallReactOS.Location = new System.Drawing.Point(6, 60);
            this.tbPathInstallReactOS.Name = "tbPathInstallReactOS";
            this.tbPathInstallReactOS.Size = new System.Drawing.Size(481, 20);
            this.tbPathInstallReactOS.TabIndex = 4;
            this.tbPathInstallReactOS.TextChanged += new System.EventHandler(this.TbPathInstallReactOS_TextChanged);
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
            this.tabPageRamDisk.Size = new System.Drawing.Size(528, 227);
            this.tabPageRamDisk.TabIndex = 0;
            this.tabPageRamDisk.Text = "Create bootable drive with RamDisk ISO";
            this.tabPageRamDisk.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(0, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(525, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Required file system: FAT32";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBrowseISORamDisk
            // 
            this.btnBrowseISORamDisk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowseISORamDisk.Location = new System.Drawing.Point(490, 91);
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
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ReactOS ISO Path (livecd/bootcd):";
            // 
            // tbRamDiskISOPath
            // 
            this.tbRamDiskISOPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRamDiskISOPath.Location = new System.Drawing.Point(6, 93);
            this.tbRamDiskISOPath.Name = "tbRamDiskISOPath";
            this.tbRamDiskISOPath.Size = new System.Drawing.Size(478, 20);
            this.tbRamDiskISOPath.TabIndex = 0;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.Location = new System.Drawing.Point(469, 271);
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
            this.cbPause.Location = new System.Drawing.Point(433, 271);
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
            this.cbFormatDrive.Location = new System.Drawing.Point(369, 275);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 299);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(560, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbStatus
            // 
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(398, 17);
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
            // linkSetDrive
            // 
            this.linkSetDrive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkSetDrive.AutoSize = true;
            this.linkSetDrive.Location = new System.Drawing.Point(9, 276);
            this.linkSetDrive.Name = "linkSetDrive";
            this.linkSetDrive.Size = new System.Drawing.Size(85, 13);
            this.linkSetDrive.TabIndex = 10;
            this.linkSetDrive.TabStop = true;
            this.linkSetDrive.Text = "[0] Disk - 500GB";
            this.toolTip1.SetToolTip(this.linkSetDrive, "Click to change...");
            this.linkSetDrive.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSetDrive_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbReactOSEditions);
            this.panel1.Controls.Add(this.tbPathInstallReactOS);
            this.panel1.Controls.Add(this.lblInstallReactOSStatus);
            this.panel1.Controls.Add(this.btnBrowseInsatallReactOS);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 192);
            this.panel1.TabIndex = 10;
            // 
            // cbEnableBetaInstall
            // 
            this.cbEnableBetaInstall.AutoSize = true;
            this.cbEnableBetaInstall.Location = new System.Drawing.Point(6, 12);
            this.cbEnableBetaInstall.Name = "cbEnableBetaInstall";
            this.cbEnableBetaInstall.Size = new System.Drawing.Size(122, 17);
            this.cbEnableBetaInstall.TabIndex = 11;
            this.cbEnableBetaInstall.Text = "Enable beta content";
            this.cbEnableBetaInstall.UseVisualStyleBackColor = true;
            this.cbEnableBetaInstall.CheckedChanged += new System.EventHandler(this.CbEnableBetaInstall_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 321);
            this.Controls.Add(this.linkSetDrive);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbFormatDrive);
            this.Controls.Add(this.cbPause);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reactofus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageMore.ResumeLayout(false);
            this.tabPageInstallReactOS.ResumeLayout(false);
            this.tabPageInstallReactOS.PerformLayout();
            this.tabPageRamDisk.ResumeLayout(false);
            this.tabPageRamDisk.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRamDisk;
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
        private System.Windows.Forms.LinkLabel linkSetDrive;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPageInstallReactOS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBrowseInsatallReactOS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPathInstallReactOS;
        private System.Windows.Forms.Label lblInstallReactOSStatus;
        private System.Windows.Forms.ComboBox cbReactOSEditions;
        private System.Windows.Forms.CheckBox cbEnableBetaInstall;
        private System.Windows.Forms.Panel panel1;
    }
}

