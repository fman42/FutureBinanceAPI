using System;
using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Tools.Converters
{
    public class TraidingPairConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            TraidingPair pair = Enum.TryParse<TraidingPair>(reader.Value.ToString(), out pair) ? pair : TraidingPair.Unknown;
            return pair;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
