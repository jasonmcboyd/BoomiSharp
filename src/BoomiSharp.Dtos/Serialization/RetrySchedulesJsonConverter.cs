using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Dtos.Extensions;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Dtos.Serialization
{
    public class RetrySchedulesJsonConverter : JsonConverter<RetrySchedules>
    {
        public override bool CanRead => false;

        public override RetrySchedules ReadJson(JsonReader reader, Type objectType, RetrySchedules existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, RetrySchedules value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(RetrySchedules.MaxRetry).ToCamelCase());
            serializer.Serialize(writer, value.MaxRetry);
            writer.WritePropertyName(nameof(RetrySchedules.Schedule));
            serializer.Serialize(writer, value.Schedule);
            writer.WriteEndObject();
        }
    }
}
