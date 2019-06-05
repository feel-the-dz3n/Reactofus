﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Reactofus
{
    public partial class Form1 : Form
    {
        public string RamDiskISOPath => tbRamDiskISOPath.Text;

        public bool ProgressPaused
        {
            get => cbPause.Checked;
            set
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => ProgressPaused = value));
                    return;
                }

                cbPause.Checked = value;
            }
        }


        public bool Aborted = false;

        private bool _inProgress = false;
        public bool Working
        {
            get => _inProgress;
            set
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => Working = value));
                    return;
                }

                Aborted = false;

                _inProgress = value;

                cbPause.Checked = false;
                cbPause.Enabled = value;

                tabControl1.Enabled = !value;
                cbFormatDrive.Enabled = !value;
                linkSetDrive.Enabled = !value;

                if (value) 
                    btnStartStop.Text = "Abort";
                else
                    btnStartStop.Text = "Start";
            }
        }

        public bool ForceFormatDrive
        {
            get => cbFormatDrive.Checked;
        }

        public Form1()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            Program.MainWnd = this;

            InitializeComponent();
            this.Text = $"Reactofus v{version}";

            SelectedDrive = null;
        }

        private DriveManagerObject _selectedDrive = null;
        public DriveManagerObject SelectedDrive
        {
            get => _selectedDrive;
            set
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => SelectedDrive = value));
                    return;
                }

                _selectedDrive = value;

                if (value == null)
                {
                    linkSetDrive.Text = "Select drive...";

                    cbFormatDrive.Checked = false;
                    cbFormatDrive.Enabled = false;
                    btnStartStop.Enabled = false;
                }
                else if (value is DriveManagerDisk || value is DriveManagerLogicalDisk)
                {
                    linkSetDrive.Text = value.GetName();
                    btnStartStop.Enabled = true;

                    if (value is DriveManagerDisk)
                    {
                        cbFormatDrive.Checked = true;
                        cbFormatDrive.Enabled = false;
                    }
                    else if (value is DriveManagerLogicalDisk)
                    {
                        cbFormatDrive.Checked = false;
                        cbFormatDrive.Enabled = true;
                    }
                }
                else throw new NotSupportedException();
            }
        }

        public void SetStatus(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetStatus(text)));
                return;
            }

            tbStatus.Text = text;
        }

        public void SetProgressFromValues(double value, double total)
        {
            var percentage = value / total * 100;

            SetProgress((int)percentage);
        }

        public void SetProgress(int value, int max = 100, ProgressBarStyle style = ProgressBarStyle.Continuous)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetProgress(value, max, style)));
                return;
            }

            statusProgress.Maximum = max;
            statusProgress.Value = value;
            statusProgress.Style = style;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!Working)
            {
                if (tabControl1.SelectedTab == tabPageRamDisk)
                    Worker.RamDiskISOWorkerStart();
                else
                    MessageBox.Show("Wrong selection", "Reactofus");
            }
            else
            {
                btnStartStop.Enabled = false;
                cbPause.Enabled = false;

                Aborted = true;
            }
        }

        private void btnBrowseISORamDisk_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog d = new OpenFileDialog())
            {
                d.Filter = "ISO Files|*.iso|All Files|*.*";

                if (d.ShowDialog() == DialogResult.OK)
                {
                    tbRamDiskISOPath.Text = d.FileName;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Working)
            {
                var ans = MessageBox.Show("Are you sure that you want to exit?", "Reactofus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (ans == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            Environment.Exit(0);
        }

        private void btnGitHub_Click(object sender, EventArgs e)
            => Process.Start("https://github.com/feel-the-dz3n/Reactofus");

        private void btnBugReport_Click(object sender, EventArgs e)
            => Process.Start("https://github.com/feel-the-dz3n/Reactofus/issues");

        private void btnSettings_Click(object sender, EventArgs e)
            => new FormSettings().ShowDialog();

        private void linkSetDrive_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var d = new FormDriveSelector();

            if (d.ShowDialog() == DialogResult.OK)
                SelectedDrive = d.SelectedDrive;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Version.Major <= 5 && Environment.OSVersion.Version.Minor <= 1)
                MessageBox.Show("Unsupported Windows version.\r\nWindows Server 2003 required.", "Reactofus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void TbPathInstallReactOS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var path = tbPathInstallReactOS.Text;
                var ntoskrnlPath = Path.Combine(path, "reactos", "system32", "ntoskrnl.exe");
                var freeldrPath = Path.Combine(path, "freeldr.ini");

                if (!File.Exists(ntoskrnlPath) &&
                    !File.Exists(freeldrPath))
                {
                    SetInstallReactOSStatus("ReactOS system files not found", RosInstallStatus.Error);
                    return;
                }
                else // kernel & boot info found
                {
                    string freeldrConfig = "";
                    bool bootcd = false, livecd = false;

                    // check freeldr.ini to detect bootcd or livecd
                    using (StreamReader r = new StreamReader(freeldrPath))
                        freeldrConfig = r.ReadToEnd();

                    string[] freeldrRows = freeldrConfig.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < freeldrRows.Length; i++)
                    {
                        var row = freeldrRows[i];

                        if (row.Contains('='))
                        {
                            string[] rowValues = row.Split('=');
                            string name = rowValues[0];
                            string value = rowValues[1];

                            if (name.Equals("LiveCD", StringComparison.OrdinalIgnoreCase))
                                livecd = true;

                            if (name.Equals("Setup", StringComparison.OrdinalIgnoreCase))
                                bootcd = true;
                        }
                    }

                    if(!bootcd && !livecd)
                    {
                        SetInstallReactOSStatus("LiveCD/BootCD files not found", RosInstallStatus.Error);
                        return;
                    }


                }
            }
            catch
            {
                SetInstallReactOSStatus("Something wrong", RosInstallStatus.Error);
            }
        }

        enum RosInstallStatus
        {
            Error,
            BootCD,
            LiveCD
        }

        void SetInstallReactOSStatus(string text, RosInstallStatus status)
        {
            lblInstallReactOSStatus.Text = text;

            if (status == RosInstallStatus.Error)
                lblInstallReactOSStatus.ForeColor = Color.DarkRed;
            else if (status == RosInstallStatus.BootCD)
                lblInstallReactOSStatus.ForeColor = Color.DarkBlue;
            else if (status == RosInstallStatus.LiveCD)
                lblInstallReactOSStatus.ForeColor = Color.DarkSeaGreen;
        }

        private void BtnBrowseInsatallReactOS_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog d = new FolderBrowserDialog())
            {
                d.Description = "Choose ReactOS Installation/LiveCD files";

                if (d.ShowDialog() == DialogResult.OK)
                {
                    tbPathInstallReactOS.Text = d.SelectedPath;
                }
            }
        }
    }
}
