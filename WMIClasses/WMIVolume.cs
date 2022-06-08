using System;
using System.Collections.Generic;
using System.Text;

namespace WMIClasses
{
    public static class WMIVolume
    {
        public static UInt32 DriveType { get; set; }
        public static String FileSystem { get; set; }
        public static UInt64 FreeSpace { get; set; }
        public static String DriveLetter { get; set; }
        public static String Label { get; set; }
        public static UInt64 Capacity { get; set; }
        public static String MainId { get; set; }
    }
}
