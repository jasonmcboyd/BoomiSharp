using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ProcessExecution
    {
        public Guid ProcessId { get; set; }
        public Guid AtomId { get; set; }
        public ProcessProperty[] ProcessProperties { get; set; }

        public class ProcessProperty
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
