using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class EnvironmentMapExtensionsSummary : IBoomiObject, ICanQuery
    {
        public string GetId() => this.Id.ToString();

        public string Name { get; set; }
        public Guid MapId { get; set; }
        public Guid ProcessId { get; set; }
        public Guid Id { get; set; }
        public Guid ExtensionGroupId { get; set; }
        public Guid EnvironmentId { get; set; }
        public string DestinationFieldSet { get; set; }
        public string SourceFieldSet { get; set; }
    }
}
