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
        public bool Finished => linkUpdate.Enabled;
        private bool ExitOnFinish = false;

        public DriveManagerObject SelectedDrive => (DriveManagerObject)treeView1.SelectedNode.Tag; 

        public FormDriveSelector()
        {
            InitializeComponent();
            btnOK.Enabled = false;

            if (!Properties.Settings.Default.ShowAllDrives)
                this.Text += " (only removable media!)";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(SelectedDrive is DriveManagerDisk)
            {
                // FIX ME
                MessageBox.Show("Disk operations not implemented yet. Choose volume instead.", "Reactofus", MessageBoxButtons.OK);
                return;

                var ans = MessageBox.Show("WARNING! You selected a whole disk! All data will be erased after starting process. Continue?", "Reactofus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ans == DialogResult.No) return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormDriveSelector_Load(object sender, EventArgs e)
            => PerformUpdate();

        public void PerformUpdate()
        {
            treeView1.Nodes.Clear();
            treeView1.Cursor = Cursors.AppStarting;
            linkUpdate.Enabled = false;

            new Thread(() =>
            {
                var disks = DriveManager.GetDisks();

                foreach (var disk in disks)
                {
                    if (!Properties.Settings.Default.ShowAllDrives && !disk.IsRemovable)
                        continue;
                    
                    var diskText = disk.ToString();
                    TreeNode diskNode = null;

                    this.Invoke(new Action(() =>
                    {
                        diskNode = new TreeNode();
                        diskNode.Tag = disk;
                        diskNode.Text = diskText;

                        treeView1.Nodes.Add(diskNode);
                    }));

                    foreach(var part in disk.GetPartitions())
                    {
                        var partText = part.ToString();
                        TreeNode partNode = null;

                        this.Invoke(new Action(() =>
                        {
                            partNode = new TreeNode();
                            partNode.Tag = part;
                            partNode.Text = partText;

                            diskNode.Nodes.Add(partNode);
                            diskNode.ExpandAll();
                        }));

                        var logical = part.LogicalDisk;

                        if(logical != null)
                        {
                            var logText = logical.ToString();
                            TreeNode logicalNode = null;

                            this.Invoke(new Action(() =>
                            {
                                logicalNode = new TreeNode();
                                logicalNode.Tag = logical;
                                logicalNode.Text = logText;

                                partNode.Nodes.Add(logicalNode);
                                partNode.ExpandAll();
                            }));
                        }
                    }
                }

                this.Invoke(new Action(() =>
                {
                    treeView1.Cursor = Cursors.Default;
                    linkUpdate.Enabled = true;

                    if (ExitOnFinish)
                    {
                        this.Enabled = true;
                        this.Close();
                    }
                }));
            }).Start();
        }

        private void linkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => PerformUpdate();

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var item = treeView1.SelectedNode;

            if (item.Tag is DriveManagerDisk || item.Tag is DriveManagerLogicalDisk)
                btnOK.Enabled = true;
            else
                btnOK.Enabled = false;
        }

        private void FormDriveSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Finished)
            {
                this.Enabled = false;
                e.Cancel = true;
                ExitOnFinish = true;
            }
        }
    }
}
