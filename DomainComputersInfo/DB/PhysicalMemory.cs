#nullable disable

namespace DomainComputersInfo
{
    public partial class PhysicalMemory
    {
        public int Id { get; set; }
        public string BankLabel { get; set; }
        public long? Capacity { get; set; }
        public string DeviceLocator { get; set; }
        public int? FormFactor { get; set; }
        public string Manufacturer { get; set; }
        public int? MemoryType { get; set; }
        public int? Speed { get; set; }
        public string MainId { get; set; }

        public virtual MainInfo Main { get; set; }
    }
}
