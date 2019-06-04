using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reactofus
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            cbNotOnlyRemovable.Checked = Properties.Settings.Default.ShowAllDrives;
        }

        private void cbNotOnlyRemovable_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowAllDrives = cbNotOnlyRemovable.Checked;
            Properties.Settings.Default.Save();

            Program.MainWnd.SelectedDrive = null;
        }
    }
}
