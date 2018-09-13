using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class AuditLog : IBoomiObject, ICanQuery
    {
        public string GetId()
        {
            throw new NotImplementedException();
        }

        public Guid ContainerId { get; set; }
        public string AccountId { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string Modifier { get; set; }
        public string Level { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
