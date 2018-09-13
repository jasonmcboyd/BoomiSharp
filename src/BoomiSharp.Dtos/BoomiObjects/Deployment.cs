using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class Deployment : IBoomiObject, ICanGet, ICanQuery, ICanCreate
    {
        public string GetId() => this.Id.ToString();
        public Guid Id { get; set; }
        public string Digest { get; set; }
        public Guid EnvironmentId { get; set; }
        public Guid ProcessId { get; set; }
        public Guid ComponentId { get; set; }
        public ComponentType ComponentType { get; set; }
        public bool Current { get; set; }
        public string Notes { get; set; }
        public int Version { get; set; }
        public DateTime DeployedOn { get; set; }
        public string DeployedBy { get; set; }
        public string ListenerStatus { get; set; }
    }
}
