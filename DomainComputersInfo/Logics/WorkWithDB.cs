using System;
using System.Collections.Generic;
using System.Management;
using System.Linq;

namespace DomainComputersInfo
{
    public class WorkWithDB
    {        
        //===============================================================================================
        public static void RecreateDB()
        {
            using ComputersContext db = new();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
        //===============================================================================================
        public static void DeleteEntry()
        {
            using ComputersContext db = new();

            var remove = db.MainInfos
                .Where(o => o.Id == Windows.CommonInfoWindow.ComputerName)
                .FirstOrDefault();

            db.MainInfos.Remove(remove);
            db.SaveChanges();
        }
        //===============================================================================================
        public static void GetAllInfo(List<String> arrComputers, String username, String password)
        {
            ConnectionOptions CurrentConnectionOptions = new()
            {
                Username = username,
                Password = password,
                Impersonation = ImpersonationLevel.Impersonate,
                EnablePrivileges = true
            };

            using ComputersContext db = new();

            foreach (string strComputer in arrComputers)
            {
                try
                {
                    ManagementScope CurrentManagementScope = new(string.Format("\\\\{0}\\root\\cimv2", strComputer), CurrentConnectionOptions);
                    CurrentManagementScope.Connect();
                    ObjectGetOptions CurrentObjectGetOptions = new();

                    MainInfo mi = new()
                    {
                        Id = strComputer,
                        Domain = ""
                    };

                    db.MainInfos.Add(mi);

                    for (int i = 0; i < Logics.WMI.Path.Count; i++)
                    {
                        ManagementPath CurrentManagementPath = new(Logics.WMI.Path[i]);
                        ManagementClass CurrentManagementClass = new(CurrentManagementScope, CurrentManagementPath, CurrentObjectGetOptions);

                        foreach (ManagementObject CurrentManagementObject in CurrentManagementClass.GetInstances())
                        {
                            switch (i)
                            {
                                case 0:
                                    db.BaseBoards.Add(GetFromWMI.GetBaseBoardInfo(CurrentManagementObject, strComputer));
                                    break;
                                case 1:
                                    db.DiskDrives.Add(GetFromWMI.GetDiskDriveInfo(CurrentManagementObject, strComputer));
                                    break;
                                case 2:
                                    db.LogicalDisks.Add(GetFromWMI.GetLogicalDiskInfo(CurrentManagementObject, strComputer));
                                    break;
                                case 3:
                                    NetworkAdapter Info = new();
                                    Info = GetFromWMI.GetNetworkAdapterInfo(CurrentManagementObject, strComputer);
                                    if (Info.Ipaddress.StartsWith("10.")) { db.NetworkAdapters.Add(Info); }
                                    break;
                                case 4:
                                    db.OperatingSystems.Add(GetFromWMI.GetOperatingSystemInfo(CurrentManagementObject, strComputer));
                                    break;
                                case 5:
                                    db.PhysicalMemories.Add(GetFromWMI.GetPhysicalMemoryInfo(CurrentManagementObject, strComputer));
                                    break;
                                case 6:
                                    db.Processors.Add(GetFromWMI.GetProcessorInfo(CurrentManagementObject, strComputer));
                                    break;
                                case 7:
                                    db.UserProfiles.Add(GetFromWMI.GetUserProfileInfo(CurrentManagementObject, strComputer));
                                    break;
                                case 8:
                                    db.TotalMemories.Add(GetFromWMI.GetTotalMemoryInfo(CurrentManagementObject, (int)WMIClasses.WMIPhysicalMemory.SMBIOSMemoryType, strComputer));
                                    break;
                            }
                        }
                        db.SaveChanges();
                    }
                }
                catch (UnauthorizedAccessException) { }
                catch (System.Runtime.InteropServices.COMException) { }
                catch (System.Management.ManagementException) { }
                catch (System.OutOfMemoryException) { }
            }
        }
        //===============================================================================================
    }
}