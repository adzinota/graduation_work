using System;
using System.Collections.Generic;
using System.Text;

namespace WMIClasses
{
    public static class WMINetworkAdapterConfiguration
    {
        public static String[] IPAddress { get; set; }
        public static String MACAddress { get; set; }
        public static String MainId { get; set; }
    }
}
