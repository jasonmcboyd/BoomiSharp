using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class Connection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Field[] Field { get; set; }
    }
}
