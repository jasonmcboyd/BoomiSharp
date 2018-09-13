using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ProcessEnvironmentAttachment : IBoomiObject, ICanQuery, ICanCreate, ICanDelete
    {
        public string GetId() => this.Id;
        public string Id { get; set; }
        public Guid EnvironmentId { get; set; }
        public Guid ExtensionGroupId { get; set; }
    }
}
