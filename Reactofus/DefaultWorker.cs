using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reactofus
{
    public class DefaultWorker
    {
        public DriveManagerLogicalDisk drive => Program.SelectedDrive as DriveManagerLogicalDisk;

    }
}
