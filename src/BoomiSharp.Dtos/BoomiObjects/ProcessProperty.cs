using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ProcessProperty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProcessPropertyValue[] ProcessPropertyValue { get; set; }
    }
}
