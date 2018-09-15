using System;
using System.Linq;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ProcessExecution
    {
        public ProcessExecution()
        {
        }

        public ProcessExecution(Guid processId, Guid atomId, params (string Name, string Value)[] processProperties)
        {
            this.ProcessId = processId;
            this.AtomId = AtomId;
            if (ProcessProperties != null)
            {
                this.ProcessProperties =
                    processProperties
                    .Select(x => new ProcessExecution.ProcessProperty
                    {
                        Name = x.Name,
                        Value = x.Value
                    })
                    .ToArray();
            }
        }

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
