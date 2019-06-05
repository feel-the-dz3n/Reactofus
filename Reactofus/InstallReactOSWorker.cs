using CabinetManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Reactofus
{
    public class InstallReactOSWorker : DefaultWorker
    {
        ICabManager cabManager = CabManager.New();

        public ROSInstallEdition Edition = Program.MainWnd.Edition;
        public Dictionary<string, FileInfo> FileList = new Dictionary<string, FileInfo>();

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
                var files = reactosInf.GetSection("Files");

                foreach(var file in files.Values)
                {
                    var dirId = file.Value;
                    var fileName = file.Key;

                    var result = Path.Combine(dirs.Values[dirId], fileName);
                    // todo...
                }
            }

            return null;
        }

        public InstallReactOSWorker ExtractingFiles()
        {
            if (Edition.Edition != ROSInstallEdition.ROSEdition.Setup)
                return null;

            cabManager.SetCompressionLevel(CabCompressionLevel.None);
            cabManager.SetCancellationToken(null);

            cabManager.OnProgress += CabManagerOnProgress;

            var nbProcessed = cabManager.ExtractFileSet(new List<IFileInCabToExtract>
                {
                    CabFile.NewToExtract(@"archive.cab", @"folder\file.txt", @"extraction_path.txt")
                });

            return null;
        }

        public InstallReactOSWorker CopyingFiles()
        {
            if (Edition.Edition != ROSInstallEdition.ROSEdition.MiniNT)
                return null;

            return null;
        }

        private void CabManagerOnProgress(object sender, ICabProgressionEventArgs e)
        {
            switch (e.EventType)
            {
                case CabEventType.GlobalProgression:
                    Program.MainWnd.SetProgress((int)e.PercentageDone);
                    break;
                //case CabEventType.GlobalProgression:
                //    Console.WriteLine($"Global progression : {e.PercentageDone}%, current file is {e.RelativePathInCab}");
                //    break;
                //case CabEventType.FileProcessed:
                //    Console.WriteLine($"New file processed : {e.RelativePathInCab}");
                //    break;
                //case CabEventType.CabinetCompleted:
                //    Console.WriteLine($"New cabinet completed : {e.CabPath}");
                //    break;
            }
        }
    }

    public class CabFile : IFileInCabToExtract
    {
        public string CabPath { get; private set; }
        public string RelativePathInCab { get; private set; }
        public bool Processed { get; set; }
        public string ExtractionPath { get; private set; }
        public string SourcePath { get; private set; }
        public string NewRelativePathInCab { get; private set; }

        public static CabFile NewToExtract(string cabPath, string relativePathInCab, string extractionPath)
        {
            return new CabFile
            {
                CabPath = cabPath,
                RelativePathInCab = relativePathInCab,
                ExtractionPath = extractionPath
            };
        }
    }
}
