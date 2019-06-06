using Microsoft.PackageManagement.Archivers.Internal.Compression;
using Microsoft.PackageManagement.Archivers.Internal.Compression.Cab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Reactofus
{
    public class InstallReactOSWorker : DefaultWorker
    {
        public ROSInstallEdition Edition = Program.MainWnd.Edition;
        public List<FileListInfo> FileList = new List<FileListInfo>();

        public InstallReactOSWorker CheckingDriveFormat()
        {
            if (!drive.FileSystem.Equals("FAT32", StringComparison.CurrentCultureIgnoreCase))
                throw new TrivialException("Drive must be formatted in FAT32.");

            return null;
        }

        public InstallReactOSWorker LoadingFiles()
        {
            if (Edition.Edition == ROSInstallEdition.ROSEdition.Setup)
            {
                var reactosInf = new INIParser(Path.Combine(Edition.SystemPath, "reactos", "reactos.inf"));

                var dirs = reactosInf.GetSection("Directories");
                var files = reactosInf.GetSection("SourceFiles");
                var drivePath = drive.Volume.DriveLetter + '\\';

                for (int i = 0; i < files.Values.Count; i++)
                {
                    var file = files.Values[i];
                    var dirId = file.Value;
                    var fileName = file.Name;

                    Program.MainWnd.SetProgressFromValues(i, files.Values.Count);

                    var result = Path.Combine(dirs.Values.First(x => x.Name == dirId).Value, fileName);

                    FileList.Add(new FileListInfo(fileName, new FileInfo(Path.Combine(drivePath, "reactos", result))));
                }
            }

            return null;
        }

        public InstallReactOSWorker ExtractingFiles()
        {
            if (Edition.Edition != ROSInstallEdition.ROSEdition.Setup)
                return null;

            var ReactosCabPath = Path.Combine(Edition.SystemPath, "reactos", "reactos.cab");

            CabInfo archive = new CabInfo(ReactosCabPath);

            for (int i = 0; i < FileList.Count; i++)
            {
                var file = FileList[i];

                this.Check();

                Program.MainWnd.SetStatus($"Extracting {file.Local.Name} ({i + 1}/{FileList.Count})");
                Program.MainWnd.SetProgressFromValues(i, FileList.Count);

                if (file.Local.Exists)
                    file.Local.Delete();

                archive.UnpackFile(file.InCab, file.Local.FullName);
            }

            return null;
        }

        public InstallReactOSWorker CopyingFiles()
        {
            if (Edition.Edition != ROSInstallEdition.ROSEdition.MiniNT)
                return null;

            return null;
        }

        public class FileListInfo
        {
            public string InCab;
            public FileInfo Local;

            public FileListInfo(string inCab, FileInfo local)
            {
                InCab = inCab;
                Local = local;
            }
        }
    }
}
