using BoomiSharp.Dtos.BoomiObjects;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Dtos.Serialization
{
    internal class EnvironmentClassificationJsonConverter : JsonConverter<EnvironmentClassification>
    {
        public override bool CanRead => true;

        public override EnvironmentClassification ReadJson(JsonReader reader, Type objectType, EnvironmentClassification existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            switch (value)
            {
                case "PROD":
                    return EnvironmentClassification.Production;
                case "TEST":
                    return EnvironmentClassification.Test;
                default:
                    throw new NotImplementedException($"Unknown environment classification: {value}.");
            }
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, EnvironmentClassification value, JsonSerializer serializer)
        {
            switch (value)
            {
                case EnvironmentClassification.Production:
                    writer.WriteValue("PROD");
                    break;
                case EnvironmentClassification.Test:
                    writer.WriteValue("TEST");
                    break;
                default:
                    throw new NotImplementedException($"Unknown environment classification: {Enum.GetName(typeof(EnvironmentClassification), value)}.");
            }
        }
    }
}
