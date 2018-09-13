using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class Role : IBoomiObject, ICanGet, ICanQuery, ICanCreate, ICanUpdate, ICanDelete
    {
        public string GetId() => this.Id.ToString();
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public string AccountId { get; set; }
        public Privilege[] Privileges { get; set; }
    }
}
