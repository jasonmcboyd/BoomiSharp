using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class DeployedPackage : IBoomiObject, ICanGet, ICanQuery, ICanCreate, ICanDelete
    {
        public Guid DeploymentId { get; set; }
        public int Version { get; set; }
        public Guid PackageId { get; set; }
        public string PackageVersion { get; set; }
        public Guid EnvironmentId { get; set; }
        public Guid ComponentId { get; set; }
        public ComponentType ComponentType { get; set; }
        public string DeployedBy { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public string ListenerStatus { get; set; }

        public string GetId()
        {
            return this.DeploymentId.ToString();
        }
    }
}
