using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;

namespace DomainComputersInfo.Logics
{
    class GetFromDB
    {
        //===============================================================================================
        public static void GetMainInfo(ListView listView)
        {
            using ComputersContext db = new();

            var computers = from main in db.MainInfos
                            join baseboard in db.BaseBoards on main.Id equals baseboard.MainId
                            join processor in db.Processors on main.Id equals processor.MainId
                            join os in db.OperatingSystems on main.Id equals os.MainId
                            join memory in db.TotalMemories on main.Id equals memory.MainId
                            join network in db.NetworkAdapters on main.Id equals network.MainId
                            where network.Ipaddress.StartsWith("10.70") || network.Ipaddress.StartsWith("10.50")
                            select new
                            {
                                pcname = main.Id,
                                osname = os.Caption,
                                osver = os.Version,
                                proc = processor.Name,
                                socket = processor.Socket,
                                virt = processor.VirtualizationEnabled,
                                product = baseboard.Product,
                                ipaddr = network.Ipaddress,
                                macaddr = network.Macaddress,
                                memory = memory.Capacity,
                                memtype = memory.MemoryType
                            };

            List<Logics.DisplayData> items = new();

            foreach (var p in computers)
            {
                items.Add(new Logics.DisplayData()
                {
                    PCname = p.pcname,
                    OSname = p.osname,
                    OSversion = Convert.ConvertWinVer(p.osver),
                    ProcName = p.proc,
                    Socket = p.socket,
                    VirtEn = p.virt.ToString(),
                    BBname = p.product,
                    Ipaddr = p.ipaddr,
                    Macaddr = p.macaddr,
                    Memory = (1 + p.memory).ToString(),
                    Memtype = Convert.ConvertMemoryType(p.memtype)
                });
            }

            listView.Items.Refresh();
            listView.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("PCname", ListSortDirection.Ascending));
        }
        //
        //public static void GetMainInfo(ListView listView)
        //{
        //    using ComputersContext db = new();

        //    var computers = from main in db.MainInfos
        //                      join logicaldisk in db.LogicalDisks on main.Id equals logicaldisk.MainId
        //                      where logicaldisk.Name=="C:"
        //                      select new
        //                      {
        //                          MainId = logicaldisk.MainId,
        //                          FreeSpace = logicaldisk.FreeSpace,
        //                          Name = logicaldisk.Name,
        //                          Size = logicaldisk.Size
        //                      };

        //    List<Logics.DisplayData> items = new();

        //    foreach (var p in computers)
        //    {
        //        items.Add(new Logics.DisplayData()
        //        {
        //            PCname = p.MainId,
        //            OSname = p.FreeSpace.ToString(),
        //            OSversion = p.Size.ToString(),
        //            ProcName = p.Name,
        //            Socket = "",
        //            VirtEn = "",
        //            BBname = "",
        //            Ipaddr = "",
        //            Macaddr = "",
        //            Memory = "",
        //            Memtype = ""
        //        });
        //    }

        //    listView.Items.Refresh();
        //    listView.ItemsSource = items;

        //    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
        //    view.SortDescriptions.Add(new SortDescription("OSname", ListSortDirection.Ascending));
        //}
        //===============================================================================================
        public static void GetAllInfo(ListBox ListBoxProcessor, ListBox ListBoxBaseBoard, ListBox ListBoxOperatingSystem, ListBox ListBoxUserProfile, ListBox ListBoxNetworkAdapter, ListBox ListBoxLogicalDisks, ListBox ListBoxPhysicalDisks, ListBox ListBoxMemory)
        {
            using ComputersContext db = new();
            GetMbProcessor(ListBoxProcessor, ListBoxBaseBoard, db);
            GetOSNetwork(ListBoxOperatingSystem, ListBoxUserProfile, ListBoxNetworkAdapter, db);
            GetDisks(ListBoxLogicalDisks, ListBoxPhysicalDisks, db);
            GetMemory(ListBoxMemory, db);
        }
        //===============================================================================================
        private static void GetMbProcessor(ListBox ListBoxProcessor, ListBox ListBoxBaseBoard, ComputersContext db)
        {
            var Processor = from main in db.MainInfos
                            where main.Id == Windows.CommonInfoWindow.ComputerName
                            join processor in db.Processors on main.Id equals processor.MainId
                            select new
                            {
                                processor.Manufacturer,
                                processor.Name,
                                processor.Cores,
                                processor.EnabledCore,
                                processor.LogicalProcessors,
                                processor.Socket,
                                Virtualization = processor.VirtualizationEnabled,
                            };

            var BaseBoard = from main in db.MainInfos
                            where main.Id == Windows.CommonInfoWindow.ComputerName
                            join baseboard in db.BaseBoards on main.Id equals baseboard.MainId
                            select new
                            {
                                baseboard.Manufacturer,
                                baseboard.Product,
                            };

            ListBoxProcessor.Items.Add("ИНФОРМАЦИЯ О ПРОЦЕССОРЕ\n");

            foreach (var p in Processor)
            {
                ListBoxProcessor.Items.Add(string.Format("Производитель: {0}", p.Manufacturer.Replace("Genuine", "")));
                ListBoxProcessor.Items.Add(string.Format("Модель: {0}", p.Name));
                ListBoxProcessor.Items.Add(string.Format("Количество ядер: {0}", p.Cores));
                ListBoxProcessor.Items.Add(string.Format("Количество задействованных ядер: {0}", p.EnabledCore));
                ListBoxProcessor.Items.Add(string.Format("Количество логических процессоров: {0}", p.LogicalProcessors));
                ListBoxProcessor.Items.Add(string.Format("Сокет процессора: {0}", p.Socket));

                if ((bool)p.Virtualization)
                    ListBoxProcessor.Items.Add("Виртуализация включена: да\n");
                else
                    ListBoxProcessor.Items.Add("Виртуализация включена: нет\n");
            }

            ListBoxBaseBoard.Items.Add("ИНФОРМАЦИЯ О МАТЕРИНСКОЙ ПЛАТЕ\n");

            foreach (var p in BaseBoard)
            {
                ListBoxBaseBoard.Items.Add(string.Format("Производитель: {0}", p.Manufacturer));
                ListBoxBaseBoard.Items.Add(string.Format("Модель: {0}\n", p.Product));
            }
        }
        //===============================================================================================
        private static void GetOSNetwork(ListBox ListBoxOperatingSystem, ListBox ListBoxUserProfile, ListBox ListBoxNetworkAdapter, ComputersContext db)
        {
            var OperatingSystem = from main in db.MainInfos
                                  where main.Id == Windows.CommonInfoWindow.ComputerName
                                  join operatingsystem in db.OperatingSystems on main.Id equals operatingsystem.MainId
                                  select new
                                  {
                                      operatingsystem.Caption,
                                      operatingsystem.Version,
                                  };

            var UserProfile = from main in db.MainInfos
                              where main.Id == Windows.CommonInfoWindow.ComputerName
                              join userprofile in db.UserProfiles on main.Id equals userprofile.MainId
                              where !userprofile.LocalPath.StartsWith("C:\\Windows")
                              select new
                              {
                                  userprofile.LocalPath,
                                  SID = userprofile.Sid,
                              };

            var NetworkAdapter = from main in db.MainInfos
                                 where main.Id == Windows.CommonInfoWindow.ComputerName
                                 join network in db.NetworkAdapters on main.Id equals network.MainId
                                 select new
                                 {
                                     IP = network.Ipaddress,
                                     MAC = network.Macaddress
                                 };

            ListBoxOperatingSystem.Items.Add("ИНФОРМАЦИЯ ОБ ОПЕРАЦИОННОЙ СИСТЕМЕ\n");

            foreach (var p in OperatingSystem)
            {
                ListBoxOperatingSystem.Items.Add(string.Format("Операционная система:\n{0}", p.Caption));
                ListBoxOperatingSystem.Items.Add(string.Format("Версия (сборка): {0}\n", Convert.ConvertWinVer(p.Version)));

            }

            ListBoxUserProfile.Items.Add("ИНФОРМАЦИЯ О ПРОФИЛЯХ ПОЛЬЗОВАТЕЛЕЙ\n");

            foreach (var p in UserProfile)
            {
                ListBoxUserProfile.Items.Add(string.Format("Путь к профилю: {0}", p.LocalPath));
                ListBoxUserProfile.Items.Add(string.Format("Идентификатор: {0}\n", p.SID));
            }

            ListBoxNetworkAdapter.Items.Add("ИНФОРМАЦИЯ О СЕТЕВЫХ АДАПТЕРАХ\n");

            foreach (var p in NetworkAdapter)
            {
                ListBoxNetworkAdapter.Items.Add(string.Format("IP адрес: {0}", p.IP));
                ListBoxNetworkAdapter.Items.Add(string.Format("MAC адрес: {0}\n", p.MAC));
            }
        }
        //===============================================================================================
        private static void GetDisks(ListBox ListBoxLogicalDisks, ListBox ListBoxPhysicalDisks, ComputersContext db)
        {
            var DiskDrive = from main in db.MainInfos
                            where main.Id == Windows.CommonInfoWindow.ComputerName
                            join diskdrive in db.DiskDrives on main.Id equals diskdrive.MainId
                            select new
                            {
                                Interface = diskdrive.InterfaceType,
                                diskdrive.MediaType,
                                diskdrive.Model,
                                diskdrive.Size
                            };

            var LogicalDisk = from main in db.MainInfos
                              where main.Id == Windows.CommonInfoWindow.ComputerName
                              join logicaldisk in db.LogicalDisks on main.Id equals logicaldisk.MainId
                              select new
                              {
                                  DriveType = Convert.ConvertMediaType(logicaldisk.DriveType),
                                  logicaldisk.FileSystem,
                                  logicaldisk.FreeSpace,
                                  logicaldisk.Name,
                                  logicaldisk.Size
                              };

            ListBoxPhysicalDisks.Items.Add("ИНФОРМАЦИЯ О ФИЗИЧЕСКИХ ДИСКАХ\n");

            foreach (var p in DiskDrive)
            {
                ListBoxPhysicalDisks.Items.Add(string.Format("Интерфейс: {0}", p.Interface));
                ListBoxPhysicalDisks.Items.Add(string.Format("Тип: {0}", p.MediaType));
                ListBoxPhysicalDisks.Items.Add(string.Format("Модель: {0}", p.Model));
                ListBoxPhysicalDisks.Items.Add(string.Format("Размер: {0} Гб\n", p.Size));
            }

            ListBoxLogicalDisks.Items.Add("ИНФОРМАЦИЯ О ЛОГИЧЕСКИХ ДИСКАХ\n");

            foreach (var p in LogicalDisk)
            {
                ListBoxLogicalDisks.Items.Add(string.Format("Тип: {0}", p.DriveType));
                ListBoxLogicalDisks.Items.Add(string.Format("Файловая система: {0}", p.FileSystem));
                ListBoxLogicalDisks.Items.Add(string.Format("Свободное место: {0} Гб", p.FreeSpace));
                ListBoxLogicalDisks.Items.Add(string.Format("Имя: {0}", p.Name));
                ListBoxLogicalDisks.Items.Add(string.Format("Объем: {0} Гб\n", p.Size));
            }
        }
        //===============================================================================================
        private static void GetMemory(ListBox listBox, ComputersContext db)
        {
            var Memory = from main in db.MainInfos
                         where main.Id == Windows.CommonInfoWindow.ComputerName
                         join memory in db.PhysicalMemories on main.Id equals memory.MainId
                         select new
                         {
                             memory.BankLabel,
                             memory.Capacity,
                             memory.DeviceLocator,
                             FormFactor = Convert.ConvertFormFactor(memory.FormFactor),
                             memory.Manufacturer,
                             MemoryType = Convert.ConvertMemoryType(memory.MemoryType),
                             memory.Speed

                         };

            listBox.Items.Add("ИНФОРМАЦИЯ ОБ ОПЕРАТИВНОЙ ПАМЯТИ\n");

            foreach (var p in Memory)
            {
                listBox.Items.Add(string.Format("Слот: {0}", p.BankLabel));
                listBox.Items.Add(string.Format("Емкость: {0} Гб", p.Capacity));
                listBox.Items.Add(string.Format("Расположение: {0}", p.DeviceLocator));
                listBox.Items.Add(string.Format("Форм-фактор: {0}", p.FormFactor));
                listBox.Items.Add(string.Format("Производитель: {0}", p.Manufacturer));
                listBox.Items.Add(string.Format("Скорость: {0} МГц", p.Speed));
                listBox.Items.Add(string.Format("Тип: {0}\n", p.MemoryType));
            }
        }
        //===============================================================================================
    }
}