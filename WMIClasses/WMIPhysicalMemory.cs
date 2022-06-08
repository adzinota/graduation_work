using System;
using System.Collections.Generic;
using System.Text;

namespace WMIClasses
{
    public static class WMIPhysicalMemory
    {
        public static String BankLabel { get; set; }
        public static UInt64 Capacity { get; set; }
        public static String DeviceLocator { get; set; }
        public static UInt16 FormFactor { get; set; }
        public static String Manufacturer { get; set; }
        public static UInt32 SMBIOSMemoryType { get; set; }
        public static UInt32 Speed { get; set; }
        public static String MainId { get; set; }
    }
}
