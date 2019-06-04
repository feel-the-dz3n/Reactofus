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
        object drive = Program.SelectedDrive;
        FileInfo installerFile;

        //public RamDiskISOWorker CheckDriveFormat()
        //{
        //    if (!drive.DriveFormat.Equals("fat32", StringComparison.CurrentCultureIgnoreCase))
        //        throw new Exception("Drive must be formatted in FAT32.");

        //    return null;
        //}

        //public RamDiskISOWorker _Install_FreeLDR()
        //{
        //    Program.WriteResourceToFile("Reactofus.Resources.installfreeldr.exe", "installfreeldr.exe");
        //    installerFile = new FileInfo("installfreeldr.exe");

        //    ProcessStartInfo installer = new ProcessStartInfo();
        //    installer.FileName = installerFile.FullName;
        //    installer.Arguments = drive.Name[0] + ":" + " fat32";
        //    installer.CreateNoWindow = true;
        //    installer.UseShellExecute = false;
        //    Process.Start(installer).WaitForExit();

        //    installerFile.Delete();

        //    return null;
        //}

        //public RamDiskISOWorker _Copy_FreeLDR_SYS()
        //{
        //    Program.WriteResourceToFile("Reactofus.Resources.freeldr.sys", Path.Combine(drive.RootDirectory.FullName, "freeldr.sys"));

        //    return null;
        //}

        //public RamDiskISOWorker _Create_INI_File()
        //{
        //    Program.WriteResourceToFile("Reactofus.Resources.freeldr_RAM.ini", Path.Combine(drive.RootDirectory.FullName, "freeldr.ini"));

        //    return null;
        //}

        //public RamDiskISOWorker _Copy_ISO_File()
        //{
        //    File.Copy(Program.MainWnd.RamDiskISOPath, Path.Combine(drive.RootDirectory.FullName, "reactos.iso"), true);

        //    return null;
        //}
    }
}
