using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainComputersInfo
{
    public static class Convert
    {
        //===============================================================================================
        public static long? ConvertToGb(object Bytes)
        {
            return (long?)((ulong)Bytes / (ulong)Math.Pow(2, 30));
        }
        //===============================================================================================
        public static String ConvertMemoryType(int? MemoryType)
        {
            List<String> Type = new()
            {
                "DDR",
                "DDR2",
                "DDR3",
                "DDR4",
                "Unknown"
            };
            string Value = MemoryType switch
            {
                20 => Type.ElementAt(0),
                21 => Type.ElementAt(1),
                24 => Type.ElementAt(2),
                26 => Type.ElementAt(3),
                _ => Type.ElementAt(4),
            };
            return Value;
        }
        //===============================================================================================
        public static String ConvertWinVer(String Version)
        {
            if (Version.StartsWith("10"))
            {
                Version = Version[5..];
                List<String> Codename = new() { "1507", "1511", "1607", "1703", "1709", "1803", "1809", "1903", "1909", "2004", "20H2" };
                List<String> Build = new() { "10240", "10586", "14393", "15063", "16299", "17134", "17763", "18362", "18363", "19041", "19042" };
                int i = Build.IndexOf(Version);
                Version = Codename[i];
            }
            else if (Version.StartsWith("6.1.7601"))
            {
                Version = "SP1";
            }
            return Version;
        }
        //===============================================================================================
        public static String ConvertFormFactor(int? FormFactor)
        {
            List<String> Type = new()
            {
                "DIMM",
                "SODIMM",
                "Unknown"
            };
            string Value = FormFactor switch
            {
                8 => Type.ElementAt(0),
                12 => Type.ElementAt(1),
                _ => Type.ElementAt(2),
            };
            return Value;
        }
        //===============================================================================================
        public static String ConvertMediaType(int? MediaType)
        {
            List<String> Type = new()
            {
                "Unknown",
                "No Root Directory",
                "Removable Disk",
                "Local Disk",
                "Network Drive",
                "Compact Disc",
                "RAM Disk"
            };
            string Value = MediaType switch
            {
                1 => Type.ElementAt(1),
                2 => Type.ElementAt(2),
                3 => Type.ElementAt(3),
                4 => Type.ElementAt(4),
                5 => Type.ElementAt(5),
                6 => Type.ElementAt(6),
                _ => Type.ElementAt(0),
            };
            return Value;
        }
        //===============================================================================================
    }
}