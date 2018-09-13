using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class CustomTrackedField : IBoomiObject, ICanQuery
    {
        public string GetId() => throw new NotImplementedException();

        public int Position { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
    }
}
