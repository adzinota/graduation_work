#nullable disable

namespace DomainComputersInfo
{
    public partial class TotalMemory
    {
        public int Id { get; set; }
        public long? Capacity { get; set; }
        public int? MemoryType { get; set; }
        public string MainId { get; set; }

        public virtual MainInfo Main { get; set; }
    }
}
