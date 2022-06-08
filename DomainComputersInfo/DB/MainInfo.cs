using System.Collections.Generic;

#nullable disable

namespace DomainComputersInfo
{
    public partial class MainInfo
    {
        public MainInfo()
        {
            DiskDrives = new HashSet<DiskDrive>();
            LogicalDisks = new HashSet<LogicalDisk>();
            NetworkAdapters = new HashSet<NetworkAdapter>();
            PhysicalMemories = new HashSet<PhysicalMemory>();
            UserProfiles = new HashSet<UserProfile>();
        }

        public string Id { get; set; }
        public string Domain { get; set; }

        public virtual BaseBoard BaseBoard { get; set; }
        public virtual OperatingSystem OperatingSystem { get; set; }
        public virtual Processor Processor { get; set; }
        public virtual TotalMemory TotalMemory { get; set; }
        public virtual ICollection<DiskDrive> DiskDrives { get; set; }
        public virtual ICollection<LogicalDisk> LogicalDisks { get; set; }
        public virtual ICollection<NetworkAdapter> NetworkAdapters { get; set; }
        public virtual ICollection<PhysicalMemory> PhysicalMemories { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
