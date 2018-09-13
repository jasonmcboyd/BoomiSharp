using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Extensions;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Json
{
    internal class AtomTypeJsonConverter : JsonConverter<AtomType>
    {
        public override bool CanRead => true;

        public override AtomType ReadJson(JsonReader reader, Type objectType, AtomType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            return (AtomType)Enum.Parse(typeof(AtomType), value.ToProperCase());
            
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, AtomType value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString().ToSnakeCase().ToUpper());
        }
    }
}
