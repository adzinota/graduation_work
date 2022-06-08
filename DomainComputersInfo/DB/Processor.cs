#nullable disable

namespace DomainComputersInfo
{
    public partial class Processor
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public int? Cores { get; set; }
        public int? EnabledCore { get; set; }
        public int? LogicalProcessors { get; set; }
        public string Socket { get; set; }
        public bool? VirtualizationEnabled { get; set; }
        public string MainId { get; set; }

        public virtual MainInfo Main { get; set; }
    }
}
