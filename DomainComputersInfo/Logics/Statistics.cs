using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainComputersInfo
{
    class Statistics
    {
        //===============================================================================================
        public static void GetFromDB()
        {

            using ComputersContext db = new();

            var Statistics = from main in db.MainInfos
                             join processor in db.Processors on main.Id equals processor.MainId
                             join memory in db.TotalMemories on main.Id equals memory.MainId
                             join os in db.OperatingSystems on main.Id equals os.MainId
                             select new
                             {
                                 proc = processor.Name,
                                 socket = processor.Socket,
                                 virt = processor.VirtualizationEnabled,
                                 memory = memory.Capacity,
                                 memtype = memory.MemoryType,
                                 osname = os.Caption,
                             };

            List<String> procname = new();
            List<String> socket = new();
            List<bool> virtualization = new();
            List<long> memsize = new();
            List<int> memtype = new();
            List<String> osName = new();

            foreach (var p in Statistics)
            {
                procname.Add(p.proc);
                socket.Add(p.socket);
                virtualization.Add((bool)p.virt);
                memsize.Add((long)(p.memory + 1));
                memtype.Add((int)p.memtype);
                osName.Add(p.osname);
            }

            Logics.StatValues.Processor = GetProcessorStatistics(procname);
            Logics.StatValues.Socket = GetSocketStatistics(socket);
            Logics.StatValues.Virtualization = GetVirtualizationStatistics(virtualization);
            Logics.StatValues.MemorySize = GetMemorySizeStatistics(memsize);
            Logics.StatValues.MemoryType = GetMemoryTypeStatistics(memtype);
            Logics.StatValues.OSName = GetOSNameStatistics(osName);
            Logics.StatValues.OSType = GetOSTypeStatistics(osName);

        }
        //===============================================================================================
        private static List<int> GetProcessorStatistics(List<String> items)
        {
            var (i3, i5, i7, i9, other) = (0, 0, 0, 0, 0);
            foreach (var p in items)
            {
                if (p.Contains("i3")) i3++;
                else if (p.Contains("i5")) i5++;
                else if (p.Contains("i7")) i7++;
                else if (p.Contains("i9")) i9++;
                else other++;
            }

            List<int> result = new() { i3, i5, i7, i9, other };
            return result;
        }
        //===============================================================================================
        private static List<int> GetSocketStatistics(List<String> items)
        {
            var (lga1156, lga1155, lga1150, lga1151, lgaOther) = (0, 0, 0, 0, 0);

            foreach (var p in items)
            {
                if (p.Contains("1156")) lga1156++;
                else if (p.Contains("1155")) lga1155++;
                else if (p.Contains("1150")) lga1150++;
                else if (p.Contains("1151")) lga1151++;
                else lgaOther++;
            }

            List<int> result = new() { lga1156, lga1155, lga1150, lga1151, lgaOther };
            return result;
        }
        //===============================================================================================
        private static List<int> GetVirtualizationStatistics(List<bool> items)
        {
            var (vTrue, vFalse) = (0, 0);

            foreach (var p in items)
            {
                if (p) vTrue++;
                else vFalse++;
            }

            List<int> result = new() { vTrue, vFalse };
            return result;
        }
        //===============================================================================================
        private static List<int> GetMemorySizeStatistics(List<long> items)
        {
            var (gb4, gb8, gb16, gb32, gb64, other) = (0, 0, 0, 0, 0, 0);
            foreach (var p in items)
            {
                if (p == 4) gb4++;
                else if (p == 8) gb8++;
                else if (p == 16) gb16++;
                else if (p == 32) gb32++;
                else if (p == 64) gb64++;
                else other++;
            }

            List<int> result = new() { gb4, gb8, gb16, gb32, gb64, other };
            return result;
        }
        //===============================================================================================
        private static List<int> GetMemoryTypeStatistics(List<int> items)
        {
            var (ddr3, ddr4, other) = (0, 0, 0);
            foreach (var p in items)
            {
                if (p == 24) ddr3++;
                else if (p == 26) ddr4++;
                else other++;
            }

            List<int> result = new() { ddr3, ddr4, other };
            return result;
        }
        //===============================================================================================
        private static List<int> GetOSNameStatistics(List<String> items)
        {
            var (w7, w10, other) = (0, 0, 0);
            foreach (var p in items)
            {
                if (p.Contains("Windows 7")) w7++;
                else if (p.Contains("Windows 10")) w10++;
                else other++;
            }

            List<int> result = new() { w7, w10, other };
            return result;
        }
        //===============================================================================================
        private static List<int> GetOSTypeStatistics(List<String> items)
        {
            var (pro, ent, other) = (0, 0, 0);
            foreach (var p in items)
            {
                if (p.Contains("Pro") || p.Contains("Про")) pro++;
                else if (p.Contains("Ent") || p.Contains("Корп")) ent++;
                else other++;
            }

            List<int> result = new() { pro, ent, other };
            return result;
        }
        //===============================================================================================
    }
}