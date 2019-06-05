using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Reactofus
{
    public class ROSInstallEdition
    {
        public enum ROSEdition
        {
            Setup, MiniNT
        }

        public string SystemPath = "\\reactos";
        public ROSEdition Edition;

        public ROSInstallEdition(ROSEdition edition, string DefaultPath)
        {
            Edition = edition;
            SystemPath = DefaultPath;
        }

        public string GetVersion()
        {
            if(Edition == ROSEdition.Setup)
            {
                // reactos.exe - ReactOS Setup
                return FileVersionInfo.GetVersionInfo(Path.Combine(SystemPath, "reactos", "reactos.exe")).ProductVersion;
            }
            else if(Edition == ROSEdition.MiniNT)
            {
                // syssetup.dll - ReactOS Setup (LiveCD)
                return FileVersionInfo.GetVersionInfo(Path.Combine(SystemPath, "system32", "syssetup.dll")).ProductVersion;
            }

            return null;
        }

        public override string ToString()
        {
            return $"ReactOS {Edition.ToString()} {GetVersion()}";
        }
    }
}
