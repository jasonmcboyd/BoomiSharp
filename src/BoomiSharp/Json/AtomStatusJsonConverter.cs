using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Extensions;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Json
{
    internal class AtomStatusJsonConverter : JsonConverter<AtomStatus>
    {
        public override bool CanRead => true;

        public override AtomStatus ReadJson(JsonReader reader, Type objectType, AtomStatus existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            return (AtomStatus)Enum.Parse(typeof(AtomStatus), value.ToProperCase());
            
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, AtomStatus value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString().ToSnakeCase().ToUpper());
        }
    }
}
