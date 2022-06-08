#nullable disable

namespace DomainComputersInfo
{
    public partial class UserProfile
    {
        public int Id { get; set; }
        public string LocalPath { get; set; }
        public string Sid { get; set; }
        public string MainId { get; set; }

        public virtual MainInfo Main { get; set; }
    }
}
