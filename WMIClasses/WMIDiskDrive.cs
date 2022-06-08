using System;
using System.Collections.Generic;
using System.Text;

namespace WMIClasses
{
    public static class WMIDiskDrive
    {
        public static String InterfaceType { get; set; }
        public static String MediaType { get; set; }
        public static String Model { get; set; }
        public static UInt64 Size { get; set; }
        public static String MainId { get; set; }
    }
}
