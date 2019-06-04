using System;
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

                if (value)
                    btnStartStop.Text = "Abort";
                else
                    btnStartStop.Text = "Start";
            }
        }

        public DriveInfo SelectedDrive => null;// ((ComboBoxDisk)cbAvailableDevices.SelectedItem).DriveInfo;

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

            UpdateDrives();
        }

        public void UpdateDrives()
        {
            cbAvailableDevices.Items.Clear();

            IEnumerable<DriveManagerDisk> disks;

            //if (!Properties.Settings.Default.ShowAllDrives)
            //    disks = DriveManager.GetDisks().Where(x => x.IsRemovable);
            //else
                disks = DriveManager.GetDisks();

            var chooseDrive = new ComboBoxDisk(disks.Count() >= 1 ? "Choose a disk" : "No disks found!");
            cbAvailableDevices.Items.Add(chooseDrive);
            cbAvailableDevices.SelectedItem = chooseDrive;

            foreach (var disk in disks)
            {
                cbAvailableDevices.Items.Add(disk);

                foreach(var part in disk.GetPartitions())
                {
                    cbAvailableDevices.Items.Add(part);

                    var logical = part.LogicalDisk;
                    if (logical != null)
                    {
                        cbAvailableDevices.Items.Add(logical);

                        var vol = part.LogicalDisk.Volume;

                        if(vol != null)
                            cbAvailableDevices.Items.Add(vol);
                    }
                }
            }// new ComboBoxDisk(disk));
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

        private void cbAvailableDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedDriveIsFine())
            {
                cbPause.Enabled = false;
                btnStartStop.Enabled = false;
            }
            else
            {
                cbPause.Enabled = true;
                btnStartStop.Enabled = true;
            }
        }

        public bool SelectedDriveIsFine()
        {
            var item = (ComboBoxDisk)cbAvailableDevices.SelectedItem;

            if (item.IsOK)
                return true;
            else
                return false;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!Working)
            {
                if (!SelectedDriveIsFine())
                {
                    MessageBox.Show("Selected drive is not fine");
                    UpdateDrives();
                    return;
                }

                if (tabControl1.SelectedTab == tabPageRamDisk)
                    Worker.RamDiskISOWorkerStart();
                // else...
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

        private void cbAvailableDevices_DropDown(object sender, EventArgs e)
            => UpdateDrives();

        private void btnGitHub_Click(object sender, EventArgs e)
            => Process.Start("https://github.com/feel-the-dz3n/Reactofus");

        private void btnBugReport_Click(object sender, EventArgs e)
            => Process.Start("https://github.com/feel-the-dz3n/Reactofus/issues");

        private void btnSettings_Click(object sender, EventArgs e)
            => new FormSettings().ShowDialog();
    }
}
