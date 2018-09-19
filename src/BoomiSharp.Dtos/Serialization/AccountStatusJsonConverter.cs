using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Dtos.Extensions;
using Newtonsoft.Json;
using System;

namespace BoomiSharp.Dtos.Serialization
{
    internal class AccountStatusJsonConverter : JsonConverter<AccountStatus>
    {
        public override bool CanRead => true;

        public override AccountStatus ReadJson(JsonReader reader, Type objectType, AccountStatus existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            return (AccountStatus)Enum.Parse(typeof(AccountStatus), value.ToProperCase());
            
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, AccountStatus value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString().ToLower());
        }
    }
}
