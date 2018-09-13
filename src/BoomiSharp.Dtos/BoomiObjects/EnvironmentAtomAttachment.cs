using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class EnvironmentAtomAttachment : IBoomiObject, ICanQuery, ICanCreate, ICanDelete
    {
        public string GetId() => this.Id;
        public string Id { get; set; }
        public Guid AtomId { get; set; }
        public Guid EnvironmentId { get; set; }
    }
}
