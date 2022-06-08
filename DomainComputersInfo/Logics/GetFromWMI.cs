using System;
using System.Management;
using WMIClasses;

namespace DomainComputersInfo
{
    public static class GetFromWMI
    {
        //===============================================================================================
        public static BaseBoard GetBaseBoardInfo(ManagementObject CurrentManagementObject, String PCName)
        {
            BaseBoard Info = new()
            {
                Manufacturer = CurrentManagementObject["Manufacturer"].ToString(),
                Product = CurrentManagementObject["Product"].ToString(),
                MainId = PCName
            };

            return Info;
        }
        //===============================================================================================
        public static DiskDrive GetDiskDriveInfo(ManagementObject CurrentManagementObject, String PCName)
        {
            DiskDrive Info = new()
            {
                InterfaceType = CurrentManagementObject["InterfaceType"].ToString(),
                MediaType = CurrentManagementObject["MediaType"].ToString(),
                Model = CurrentManagementObject["Model"].ToString(),
                Size = Convert.ConvertToGb(CurrentManagementObject["Size"]),
                MainId = PCName
            };

            return Info;
        }
        //===============================================================================================
        public static LogicalDisk GetLogicalDiskInfo(ManagementObject CurrentManagementObject, String PCName)
        {
            try { WMILogicalDisk.FileSystem = CurrentManagementObject["FileSystem"].ToString(); }
            catch (NullReferenceException) { WMILogicalDisk.FileSystem = ""; }

            try { WMILogicalDisk.FreeSpace = (ulong)CurrentManagementObject["FreeSpace"]; }
            catch (NullReferenceException) { WMILogicalDisk.FreeSpace = 0; }

            try { WMILogicalDisk.ProviderName = CurrentManagementObject["ProviderName"].ToString(); }
            catch (NullReferenceException) { WMILogicalDisk.ProviderName = ""; }

            try { WMILogicalDisk.Size = (ulong)CurrentManagementObject["Size"]; }
            catch (NullReferenceException) { WMILogicalDisk.Size = 0; }

            LogicalDisk Info = new()
            {
                DriveType = (int?)(uint)CurrentManagementObject["DriveType"],
                FileSystem = WMILogicalDisk.FileSystem,
                FreeSpace = Convert.ConvertToGb(WMILogicalDisk.FreeSpace),
                Name = CurrentManagementObject["Name"].ToString(),
                Size = Convert.ConvertToGb(WMILogicalDisk.Size),
                MainId = PCName
            };

            return Info;
        }
        //===============================================================================================
        public static NetworkAdapter GetNetworkAdapterInfo(ManagementObject CurrentManagementObject, String PCName)
        {
            String ip;

            try { ip = ((string[])CurrentManagementObject["IPAddress"])[0]; }
            catch (NullReferenceException) { ip = ""; }

            try { WMINetworkAdapterConfiguration.MACAddress = CurrentManagementObject["MACAddress"].ToString(); }
            catch (NullReferenceException) { WMINetworkAdapterConfiguration.MACAddress = ""; }

            NetworkAdapter Info = new()
            {
                Ipaddress = ip,
                Macaddress = WMINetworkAdapterConfiguration.MACAddress,
                MainId = PCName
            };

            return Info;
        }
        //===============================================================================================
        public static OperatingSystem GetOperatingSystemInfo(ManagementObject CurrentManagementObject, String PCName)
        {
            WMIOperatingSystem.Version = CurrentManagementObject["Version"].ToString();

            OperatingSystem Info = new()
            {
                Caption = CurrentManagementObject["Caption"].ToString(),
                Version = WMIOperatingSystem.Version,
                MainId = PCName
            };

            return Info;
        }
        //===============================================================================================
        public static PhysicalMemory GetPhysicalMemoryInfo(ManagementObject CurrentManagementObject, String PCName)
        {
            try { WMIPhysicalMemory.SMBIOSMemoryType = (uint)CurrentManagementObject["SMBIOSMemoryType"]; }
            catch (ManagementException) { WMIPhysicalMemory.SMBIOSMemoryType = 0; }
            catch (System.Runtime.InteropServices.COMException) { WMIPhysicalMemory.SMBIOSMemoryType = 0; }
            catch (NullReferenceException) { WMIPhysicalMemory.SMBIOSMemoryType = 0; }

            PhysicalMemory Info = new()
            {
                BankLabel = CurrentManagementObject["BankLabel"].ToString(),
                Capacity = (long?)Convert.ConvertToGb(CurrentManagementObject["Capacity"]),
                DeviceLocator = CurrentManagementObject["DeviceLocator"].ToString(),
                FormFactor = (ushort)CurrentManagementObject["FormFactor"],
                Manufacturer = CurrentManagementObject["Manufacturer"].ToString(),
                MemoryType = (int?)WMIPhysicalMemory.SMBIOSMemoryType,
                Speed = (int?)(uint)CurrentManagementObject["Speed"],
                MainId = PCName
            };

            return Info;
        }
        //===============================================================================================
        public static Processor GetProcessorInfo(ManagementObject CurrentManagementObject, String PCName)
        {
            try { WMIProcessor.NumberOfCores = (uint)CurrentManagementObject["NumberOfCores"]; }
            catch (ManagementException) { WMIProcessor.NumberOfCores = 0; }

            try { WMIProcessor.NumberOfEnabledCore = (uint)CurrentManagementObject["NumberOfEnabledCore"]; }
            catch (ManagementException) { WMIProcessor.NumberOfEnabledCore = 0; }

            try { WMIProcessor.SocketDesignation = CurrentManagementObject["SocketDesignation"].ToString(); }
            catch (ManagementException) { WMIProcessor.SocketDesignation = ""; }

            try { WMIProcessor.VirtualizationFirmwareEnabled = (bool)CurrentManagementObject["VirtualizationFirmwareEnabled"]; }
            catch (ManagementException) { WMIProcessor.VirtualizationFirmwareEnabled = false; }

            Processor Info = new()
            {
                Manufacturer = CurrentManagementObject["Manufacturer"].ToString(),
                Name = CurrentManagementObject["Name"].ToString().Replace("Intel(R) Core(TM)", ""),
                Cores = (int?)WMIProcessor.NumberOfCores,
                EnabledCore = (int?)WMIProcessor.NumberOfEnabledCore,
                LogicalProcessors = (int?)(uint)CurrentManagementObject["NumberOfLogicalProcessors"],
                Socket = WMIProcessor.SocketDesignation,
                VirtualizationEnabled = WMIProcessor.VirtualizationFirmwareEnabled,
                MainId = PCName
            };

            return Info;
        }
        //===============================================================================================
        public static UserProfile GetUserProfileInfo(ManagementObject CurrentManagementObject, String PCName)
        {

            UserProfile Info = new()
            {
                LocalPath = CurrentManagementObject["LocalPath"].ToString(),
                Sid = CurrentManagementObject["SID"].ToString(),
                MainId = PCName
            };
            return Info;
        }
        //===============================================================================================
        public static TotalMemory GetTotalMemoryInfo(ManagementObject CurrentManagementObject, int t, String PCName)
        {
            TotalMemory Info = new()
            {
                Capacity = (long?)Convert.ConvertToGb(CurrentManagementObject["TotalPhysicalMemory"]),
                MemoryType = t,
                MainId = PCName
            };

            return Info;
        }
        //===============================================================================================
    }
}