#nullable disable

namespace DomainComputersInfo
{
    public partial class DiskDrive
    {
        public int Id { get; set; }
        public string InterfaceType { get; set; }
        public string MediaType { get; set; }
        public string Model { get; set; }
        public long? Size { get; set; }
        public string MainId { get; set; }

        public virtual MainInfo Main { get; set; }
    }
}
