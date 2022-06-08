using System;
using System.Collections.Generic;
using System.Text;

namespace WMIClasses
{
    public static class WMILogicalDisk
    {
        public static UInt32 DriveType { get; set; }
        public static String FileSystem { get; set; }
        public static UInt64 FreeSpace { get; set; }
        public static String Name { get; set; }
        public static String ProviderName { get; set; }
        public static UInt64 Size { get; set; }
        public static String MainId { get; set; }
    }
}
