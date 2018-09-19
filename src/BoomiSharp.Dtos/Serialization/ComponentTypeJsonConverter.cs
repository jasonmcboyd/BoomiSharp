using BoomiSharp.Dtos.BoomiObjects;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Dtos.Serialization
{
    internal class ComponentTypeJsonConverter : JsonConverter<ComponentType>
    {
        public override bool CanRead => true;

        public override ComponentType ReadJson(JsonReader reader, Type objectType, ComponentType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            return (ComponentType)Enum.Parse(typeof(ComponentType), value, true);
            
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, ComponentType value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString().ToUpper());
        }
    }
}
