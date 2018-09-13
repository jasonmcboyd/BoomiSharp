using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ProcessSchedules : IBoomiObject, ICanGet, ICanQuery, ICanUpdate
    {
        public string GetId() => this.Id;
        public string Id { get; set; }
        public Guid AtomId { get; set; }
        public Guid ProcessId { get; set; }
        public Schedule[] Schedule { get; set; }
        public RetrySchedules Retry { get; set; }
    }
}
