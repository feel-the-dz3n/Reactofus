using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Reactofus
{
    public partial class FormDriveSelector : Form
    {
        public FormDriveSelector()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormDriveSelector_Load(object sender, EventArgs e)
            => PerformUpdate();

        public void PerformUpdate()
        {
            treeView1.Nodes.Clear();
            var loadingNode = treeView1.Nodes.Add("Loading...");
            treeView1.Cursor = Cursors.AppStarting;
            linkUpdate.Enabled = false;

            new Thread(() =>
            {
                var disks = DriveManager.GetDisks();

                foreach (var disk in disks)
                {
                    var diskIndex = disk.Index;
                    var diskSize = disk.Size;
                    TreeNode diskNode = null;

                    this.Invoke(new Action(() =>
                    {
                        diskNode = new TreeNode();
                        diskNode.Tag = disk;
                        diskNode.Text = $"[Disk {diskIndex}] - Size: {diskSize / 1024 / 1024 / 1024} GB";

                        treeView1.Nodes.Add(diskNode);
                    }));

                    foreach(var part in disk.GetPartitions())
                    {
                        var partIndex = part.PartitionIndex;
                        var partSize = part.Size;
                        var partType = part.Type;
                        TreeNode partNode = null;

                        this.Invoke(new Action(() =>
                        {
                            partNode = new TreeNode();
                            partNode.Tag = part;
                            partNode.Text = $"[Partition {partIndex}] - Size: {partSize / 1024 / 1024} MB - Type: {partType}";

                            diskNode.Nodes.Add(partNode);
                        }));

                        var logical = part.LogicalDisk;

                        if(logical != null)
                        {
                            var logFree = logical.FreeSpace;
                            var logLetter = logical.Volume.DriveLetter;
                            var logName = logical.VolumeName;
                            var logBoot = logical.Volume.BootVolume;
                            TreeNode logicalNode = null;

                            if (logName == null) logName = "No Name";

                            this.Invoke(new Action(() =>
                            {
                                logicalNode = new TreeNode();
                                logicalNode.Tag = logical;
                                logicalNode.Text = $"[Drive {logLetter} \"{logName}\"] - Boot: {logBoot} - Free Space: {logFree / 1024 / 1024} MB";

                                partNode.Nodes.Add(logicalNode);
                            }));
                        }
                    }
                }

                this.Invoke(new Action(() =>
                {
                    treeView1.Nodes.Remove(loadingNode);
                    treeView1.Cursor = Cursors.Default;
                    linkUpdate.Enabled = true;
                }));
            }).Start();
        }

        private void linkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => PerformUpdate();
    }
}
