using System;
using System.Collections.Generic;

namespace DomainComputersInfo.Logics
{
    //===============================================================================================
    public class DisplayData
    {
        public String PCname { get; set; }
        public String OSname { get; set; }
        public String OSversion { get; set; }
        public String ProcName { get; set; }
        public String Socket { get; set; }
        public String VirtEn { get; set; }
        public String BBname { get; set; }
        public String Ipaddr { get; set; }
        public String Macaddr { get; set; }
        public String Memory { get; set; }
        public String Memtype { get; set; }
    }
    //===============================================================================================
    public static class Credentials
    {
        public static String Login { get; set; }
        public static String Password { get; set; }
        public static String Domain { get; set; }
    }
    //===============================================================================================
    public static class WMI
    {
        public static readonly List<String> Path = new()
        {
            "Win32_BaseBoard",
            "Win32_DiskDrive",
            "Win32_LogicalDisk",
            "Win32_NetworkAdapterConfiguration",
            "Win32_OperatingSystem",
            "Win32_PhysicalMemory",
            "Win32_Processor",
            "Win32_UserProfile",
            "Win32_ComputerSystem"
        };
    }
    //===============================================================================================
    public static class StatValues
    {
        public static List<int> Processor { get; set; }
        public static List<int> Socket { get; set; }
        public static List<int> Virtualization { get; set; }
        public static List<int> MemorySize { get; set; }
        public static List<int> MemoryType { get; set; }
        public static List<int> OSName { get; set; }
        public static List<int> OSType { get; set; }
    }
    //===============================================================================================
}
