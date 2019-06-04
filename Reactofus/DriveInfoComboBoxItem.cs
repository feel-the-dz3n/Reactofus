using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reactofus
{
    public class ComboBoxDisk
    {
        public object DiskOrVolume;
        public string OverrideString;

        public ComboBoxDisk(object DiskOrVolume)
            => this.DiskOrVolume = DiskOrVolume;

        public ComboBoxDisk(string overrideString = "Choose a drive")
            => OverrideString = overrideString;

        public bool IsOK
        {
            get
            {
                // fix me
                return false;
            }
        }

        public override string ToString()
        {
            // Text used for ComboBox

            if (DiskOrVolume == null) return OverrideString;

            if (DiskOrVolume is DriveManagerDisk)
            {
                var disk = (DriveManagerDisk)DiskOrVolume;

                if (disk.IsOK)
                    return $"[{disk.Index}] {disk.Model} - {disk.Size / 1024 / 1024} MB";
                else
                    return $"[{disk.Index}] {disk.Model} - {disk.Status}";
            }
            else if (DiskOrVolume is DriveManagerPartition)
            {
                var part = (DriveManagerDisk)DiskOrVolume;

                return "Partition";
                //if (disk.IsOK)
                //    return $"{disk.Model} - {disk.Size / 1024 / 1024} MB";
                //else
                //    return $"{disk.Model} - {disk.Status}";
            }
            else return "Unknown";
        }
    }
}
