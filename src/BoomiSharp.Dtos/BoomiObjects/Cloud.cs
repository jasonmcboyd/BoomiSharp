using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class Cloud : IBoomiObject, ICanGet, ICanQuery
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid AtomId { get; set; }

        public string GetId() => this.Id;
    }
}
