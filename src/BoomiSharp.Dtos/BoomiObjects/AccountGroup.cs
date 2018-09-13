using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class AccountGroup : IBoomiObject, ICanGet, ICanQuery, ICanCreate, ICanUpdate
    {
        public string GetId() => this.Id.ToString();
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public bool DefaultGroup { get; set; }
        public string AutoSubscribeAlertLevel { get; set; }
        
    }
}
