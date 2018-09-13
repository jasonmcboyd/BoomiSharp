using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class Process : IBoomiObject, ICanGet, ICanQuery
    {
        public string GetId() => this.Id.ToString();
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IntegrationPackId { get; set; }
        public Guid IntegrationPackInstanceId { get; set; }
    }
}
