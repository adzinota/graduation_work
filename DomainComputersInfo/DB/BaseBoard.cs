#nullable disable

namespace DomainComputersInfo
{
    public partial class BaseBoard
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Product { get; set; }
        public string MainId { get; set; }

        public virtual MainInfo Main { get; set; }
    }
}
