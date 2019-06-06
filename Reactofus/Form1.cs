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

        public ROSInstallEdition Edition
        {
            get
            {
                if (InvokeRequired)
                    return (ROSInstallEdition)this.Invoke(new Func<ROSInstallEdition>(() => Edition));

                return (ROSInstallEdition)cbReactOSEditions.SelectedItem;
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
                else if (tabControl1.SelectedTab == tabPageInstallReactOS && cbEnableBetaInstall.Checked)
                    Worker.InstallROSWorkerStart();
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
            // Update editions
            try
            {
                cbReactOSEditions.Items.Clear();
                cbReactOSEditions.SelectedItem = null;

                var path = tbPathInstallReactOS.Text;

                if (path.Length <= 2)
                {
                    SetInstallReactOSStatus("Wrong path", false);
                    return;
                }

                var ntoskrnlPath = Path.Combine(path, "reactos", "system32", "ntoskrnl.exe");
                var freeldrPath = Path.Combine(path, "freeldr.ini");

                if (!File.Exists(ntoskrnlPath) &&
                    !File.Exists(freeldrPath))
                {
                    SetInstallReactOSStatus("ReactOS system files not found", false);
                    return;
                }
                else // kernel & boot info found
                {
                    List<ROSInstallEdition> Editions = new List<ROSInstallEdition>();

                    // check freeldr.ini to detect bootcd or livecd
                    var freeldrConfig = new INIParser(freeldrPath);

                    foreach(var section in freeldrConfig.Sections)
                    {
                        var IsSetup = section.Name.Equals("Setup", StringComparison.OrdinalIgnoreCase);
                        var IsLive = section.Name.Equals("LiveCD", StringComparison.OrdinalIgnoreCase);

                        if (IsSetup || IsLive)
                        {
                            ROSInstallEdition edition = new ROSInstallEdition(
                                IsSetup ?
                                ROSInstallEdition.ROSEdition.Setup :
                                ROSInstallEdition.ROSEdition.MiniNT,
                                path);

                            foreach (var row in section.Values)
                                if (row.Name.Equals("SystemPath", StringComparison.OrdinalIgnoreCase))
                                    edition.SystemPath = Path.Combine(path, row.Value.TrimStart(new char[] { '\\' }));

                            Editions.Add(edition);
                        }
                    }

                    foreach(var edition in Editions)
                        cbReactOSEditions.Items.Add(edition);

                    cbReactOSEditions.SelectedItem = Editions.First();

                    SetInstallReactOSStatus("Choose edition from the box below", true);
                }
            }
            catch
            {
                SetInstallReactOSStatus("Something wrong", false);
            }
        }


        void SetInstallReactOSStatus(string text, bool isOK)
        {
            lblInstallReactOSStatus.Text = text;

            if (!isOK)
                lblInstallReactOSStatus.ForeColor = Color.DarkRed;
            else
                lblInstallReactOSStatus.ForeColor = Color.DarkBlue;
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

        private void CbEnableBetaInstall_CheckedChanged(object sender, EventArgs e)
            => panel1.Enabled = cbEnableBetaInstall.Checked;
    }
}
