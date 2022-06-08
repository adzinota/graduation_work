#nullable disable

namespace DomainComputersInfo
{
    public partial class NetworkAdapter
    {
        public int Id { get; set; }
        public string Ipaddress { get; set; }
        public string Macaddress { get; set; }
        public string MainId { get; set; }

        public virtual MainInfo Main { get; set; }
    }
}
