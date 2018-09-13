using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ComponentEnvironmentAttachment : IBoomiObject, ICanQuery, ICanCreate, ICanDelete
    {
        public string GetId() => this.Id;
        public string Id { get; set; }
        public Guid EnvironmentId { get; set; }
        public Guid ComponentId { get; set; }
        public ComponentType ComponentType { get; set; }
    }
}
