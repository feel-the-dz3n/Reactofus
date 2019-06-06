using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Reactofus
{
    public class DefaultWorker
    {
        public DriveManagerLogicalDisk drive => Program.SelectedDrive as DriveManagerLogicalDisk;

        /// <summary>
        /// Check for pause/abort
        /// </summary>
        public void Check()
        {
            if (Program.MainWnd.ProgressPaused)
            {
                while (Program.MainWnd.ProgressPaused)
                    Thread.Sleep(500);
            }

            if (Program.MainWnd.Aborted)
                throw new Exception("Aborted.");
        }
    }
}
