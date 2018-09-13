using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ProcessScheduleStatus : IBoomiObject, ICanGet, ICanQuery, ICanUpdate
    {
        public string GetId() => this.Id;
        public string Id { get; set; }
        public bool Enabled { get; set; }
        public Guid AtomId { get; set; }
        public Guid ProcessId { get; set; }
    }
}
