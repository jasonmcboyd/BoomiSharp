using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class AtomConnectorVersions : IBoomiObject, ICanGet
    {
        public string GetId() => this.Id.ToString();

        public Guid Id { get; set; }
        public string Version { get; set; }
        public string Name { get; set; }
    }
}
