#nullable disable

namespace DomainComputersInfo
{
    public partial class OperatingSystem
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Version { get; set; }
        public string MainId { get; set; }

        public virtual MainInfo Main { get; set; }
    }
}
