using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class Atom : IBoomiObject, ICanGet, ICanQuery, ICanCreate, ICanUpdate, ICanDelete
    {
        public string GetId() => this.Id.ToString();
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AtomStatus Status { get; set; }
        public AtomType Type { get; set; }
        public string Hostname { get; set; }
        public DateTime DateInstalled { get; set; }
        public string CurrentVersion { get; set; }
        public int PurgeHistoryDays { get; set; }
        public bool PurgeImmediate { get; set; }
        public int ForceRestartTime { get; set; }
    }
}
