using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Reactofus
{
    public class RamDiskISOWorker : DefaultWorker
    {
        DriveManagerLogicalDisk drive = Program.SelectedDrive as DriveManagerLogicalDisk;
        FileInfo installerFile;

        public RamDiskISOWorker CheckDriveFormat()
        {
            if (drive == null)
                throw new Exception("Something went wrong");

            if (!drive.FileSystem.Equals("fat32", StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Drive must be formatted in FAT32.");

            return null;
        }

        public RamDiskISOWorker _Install_FreeLDR()
        {
            Program.WriteResourceToFile("Reactofus.Resources.installfreeldr.exe", "installfreeldr.exe");
            installerFile = new FileInfo("installfreeldr.exe");

            ProcessStartInfo installer = new ProcessStartInfo();
            installer.FileName = installerFile.FullName;
            installer.Arguments = drive.Volume.DriveLetter + " fat32";
            installer.CreateNoWindow = true;
            installer.UseShellExecute = false;
            Process.Start(installer).WaitForExit();

            installerFile.Delete();

            return null;
        }

        public RamDiskISOWorker _Copy_FreeLDR_SYS()
        {
            Program.WriteResourceToFile("Reactofus.Resources.freeldr.sys", Path.Combine(drive.Volume.DriveLetter, "freeldr.sys"));

            return null;
        }

        public RamDiskISOWorker _Create_INI_File()
        {
            Program.WriteResourceToFile("Reactofus.Resources.freeldr_RAM.ini", Path.Combine(drive.Volume.DriveLetter, "freeldr.ini"));

            return null;
        }

        public RamDiskISOWorker _Copy_ISO_File()
        {
            File.Copy(Program.MainWnd.RamDiskISOPath, Path.Combine(drive.Volume.DriveLetter, "reactos.iso"), true);

            return null;
        }
    }
}
