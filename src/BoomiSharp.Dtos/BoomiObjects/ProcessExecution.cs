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
            if (processProperties != null)
            {
                this.ProcessProperties =
                    processProperties
                    .Select(x => new Property
                    {
                        Name = x.Name,
                        Value = x.Value
                    })
                    .ToArray();
            }
        }

        public Guid ProcessId { get; set; }
        public Guid AtomId { get; set; }
        public Property[] ProcessProperties { get; set; }
    }
}
