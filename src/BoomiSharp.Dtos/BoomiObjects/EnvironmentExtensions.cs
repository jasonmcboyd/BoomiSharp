using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class EnvironmentExtensions : IBoomiObject, ICanGet, ICanQuery, ICanUpdate
    {
        public string GetId() => this.Id;
        public string Id { get; set; }
        public Guid? ExtensionGroupId { get; set; }
        public Guid EnvironmentId { get; set; }
        public Connections Connections { get; set; }
        public TradingPartners TradingPartners { get; set; }
        public ProcessProperties ProcessProperties { get; set; }
        public Properties Properties { get; set; }
    }
}
