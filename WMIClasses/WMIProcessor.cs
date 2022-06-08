using System;

namespace WMIClasses
{
    public static class WMIProcessor
    {
        public static String Manufacturer { get; set; }
        public static String Name { get; set; }
        public static UInt32 NumberOfCores { get; set; }
        public static UInt32 NumberOfEnabledCore { get; set; }
        public static UInt32 NumberOfLogicalProcessors { get; set; }
        public static String SocketDesignation { get; set; }
        public static Boolean VirtualizationFirmwareEnabled { get; set; }
        public static String MainId { get; set; }
    }
}
