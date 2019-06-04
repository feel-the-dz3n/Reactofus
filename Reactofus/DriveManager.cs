using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace Reactofus
{
    public class DriveManager
    {
        public static DriveManagerDisk[] GetDisks()
        {
            List<DriveManagerDisk> result = new List<DriveManagerDisk>();

            using (ManagementObjectSearcher disks = new ManagementObjectSearcher("SELECT DeviceID FROM Win32_DiskDrive"))
            {
                foreach (ManagementObject disk in disks.Get())
                {
                    result.Add(new DriveManagerDisk(disk["DeviceID"].ToString()));
                }
            }

            return result.ToArray();
        }
    }
    public class DriveManagerVolume : ProtectedForQuery
    {
        public uint SerialNumber { get; private set; }

        private string DefaultSearchQuery => $"SELECT * FROM Win32_Volume Where SerialNumber=\"{SerialNumber}\"";

        public string DeviceID => GetObject<string>("DeviceID");
        public bool BootVolume => GetObject<bool>("BootVolume");
        public string Caption => GetObject<string>("Caption");
        public string DriveLetter => GetObject<string>("DriveLetter");
        public uint DriveType => GetObject<uint>("DriveType");
        public string Label => GetObject<string>("Label");

        private T GetObject<T>(string element)
        {
            using (ManagementObjectSearcher disks = new ManagementObjectSearcher(new ManagementScope("\\\\.\\ROOT\\cimv2"), new ObjectQuery(DefaultSearchQuery)))
            {
                foreach (ManagementObject disk in disks.Get())
                {
                    return (T)disk[element];
                }
            }

            return default(T);
        }

        public DriveManagerVolume(uint serial)
        {
            SerialNumber = serial;
        }

        public override string ToString()
            => $"[{DriveLetter} - {Label}] Volume - {(BootVolume ? "Boot - " : "")}";
    }

    public class DriveManagerLogicalDisk : ProtectedForQuery
    {
        public string DeviceID { get; private set; }

        private string DefaultSearchQuery => $"SELECT * FROM Win32_LogicalDisk Where DeviceID=\"{Protect(DeviceID)}\"";

        public uint DriveType => GetObject<uint>("DriveType");
        public string FileSystem => GetObject<string>("FileSystem");
        public uint MediaType => GetObject<uint>("MediaType");
        public ulong Size => GetObject<ulong>("Size");
        public ulong FreeSpace => GetObject<ulong>("FreeSpace");
        public string VolumeName => GetObject<string>("VolumeName");
        public uint VolumeSerialNumber => uint.Parse(GetObject<string>("VolumeSerialNumber"), System.Globalization.NumberStyles.HexNumber);

        public DriveManagerVolume Volume => new DriveManagerVolume(VolumeSerialNumber);

        private T GetObject<T>(string element)
        {
            using (ManagementObjectSearcher disks = new ManagementObjectSearcher(new ManagementScope("\\\\.\\ROOT\\cimv2"), new ObjectQuery(DefaultSearchQuery)))
            {
                foreach (ManagementObject disk in disks.Get())
                {
                    return (T)disk[element];
                }
            }

            return default(T);
        }

        public DriveManagerLogicalDisk(string devid)
        {
            DeviceID = devid;
        }

        public override string ToString()
            => $"[{VolumeName}] Logical Disk - {FileSystem} - {Size / 1024 / 1024} MB - Free: {FreeSpace / 1024 /1024} MB";
    }

    public class DriveManagerPartition : ProtectedForQuery
    {
        public string DeviceID { get; private set; }

        private string DefaultSearchQuery => $"SELECT * FROM Win32_DiskPartition Where DeviceID=\"{Protect(DeviceID)}\"";

        public uint DiskIndex => GetObject<uint>("DiskIndex");
        public uint PartitionIndex => GetObject<uint>("Index");
        public ulong Size => GetObject<ulong>("Size");
        public string Manufacturer => GetObject<string>("Manufacturer");
        public string Description => GetObject<string>("Description");
        public string Type => GetObject<string>("Type");

        public DriveManagerLogicalDisk LogicalDisk
        {
            get
            {
                using (ManagementObjectSearcher items = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + Protect(DeviceID) + "'} WHERE AssocClass = Win32_LogicalDiskToPartition"))
                {
                    foreach (ManagementObject item in items.Get())
                    {
                        return new DriveManagerLogicalDisk(item["DeviceID"].ToString());
                    }
                }

                return null;
            }
        }

        private T GetObject<T>(string element)
        {
            using (ManagementObjectSearcher disks = new ManagementObjectSearcher(new ManagementScope("\\\\.\\ROOT\\cimv2"), new ObjectQuery(DefaultSearchQuery)))
            {
                foreach (ManagementObject disk in disks.Get())
                {
                    return (T)disk[element];
                }
            }

            return default(T);
        }

        public DriveManagerPartition(string devid)
        {
            DeviceID = devid;
        }

        public override string ToString()
            => $"[{DiskIndex}, {PartitionIndex}] Partition - {Size / 1024 / 1024} MB";
    }

    public class DriveManagerDisk : ProtectedForQuery
    {
        public string DeviceID { get; private set; }

        private string DefaultSearchQuery => $"SELECT * FROM Win32_DiskDrive Where DeviceID=\"{Protect(DeviceID)}\"";

        public uint Index => GetObject<uint>("Index");
        public ulong Size => GetObject<ulong>("Size");
        public uint PartitionsCount => GetObject<uint>("Partitions");
        public string InterfaceType => GetObject<string>("InterfaceType");
        public string MediaType => GetObject<string>("MediaType");
        public string Manufacturer => GetObject<string>("Manufacturer");
        public string Description => GetObject<string>("Description");
        public string Model => GetObject<string>("Model");
        public string Status => GetObject<string>("Status");
        public bool IsOK => Status == "OK";
        public bool IsRemovable => MediaType == "Removable Media";

        private T GetObject<T>(string element)
        {
            using (ManagementObjectSearcher disks = new ManagementObjectSearcher(new ManagementScope("\\\\.\\ROOT\\cimv2"), new ObjectQuery(DefaultSearchQuery)))
            {
                foreach (ManagementObject disk in disks.Get())
                {
                    return (T)disk[element];
                }
            }

            return default(T);
        }

        public DriveManagerPartition[] GetPartitions()
        {
            List<DriveManagerPartition> result = new List<DriveManagerPartition>();

            using (ManagementObjectSearcher items = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + DeviceID + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition"))
            {
                foreach (ManagementObject item in items.Get())
                {
                    result.Add(new DriveManagerPartition(item["DeviceID"].ToString()));
                }
            }

            return result.ToArray();
        }

        public DriveManagerDisk(string devid)
        {
            DeviceID = devid;
        }

        public override string ToString()
            => $"[{Index}] Disk - {Model} - {MediaType}";
    }

    public class ProtectedForQuery
    {
        public string Protect(string input)
        {
            StringBuilder b = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                b.Append(c);
                if (c == '\\') b.Append('\\');
            }

            return b.ToString();
        }
    }
}
