#nullable disable

namespace DomainComputersInfo
{
    public partial class LogicalDisk
    {
        public int Id { get; set; }
        public int? DriveType { get; set; }
        public string FileSystem { get; set; }
        public long? FreeSpace { get; set; }
        public string Name { get; set; }
        public long? Size { get; set; }
        public string MainId { get; set; }

        public virtual MainInfo Main { get; set; }
    }
}
