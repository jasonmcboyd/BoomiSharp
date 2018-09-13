using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class Environment : IBoomiObject, ICanGet, ICanQuery, ICanCreate, ICanUpdate, ICanDelete
    {
        public string GetId() => this.Id.ToString();
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnvironmentClassification Classification { get; set; }
    }
}
