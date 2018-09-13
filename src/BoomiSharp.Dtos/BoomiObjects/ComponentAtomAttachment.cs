using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ComponentAtomAttachment : IBoomiObject, ICanQuery, ICanCreate, ICanDelete
    {
        public string GetId() => this.Id;
        public string Id { get; set; }
        public Guid AtomId { get; set; }
        public Guid ComponentId { get; set; }
        public ComponentType ComponentType { get; set; }
    }
}
