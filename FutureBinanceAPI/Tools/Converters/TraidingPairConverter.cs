using System;
using FutureBinanceAPI.Models.Enums;
using static FutureBinanceAPI.Models.Enums.TradingPair;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Tools.Converters
{
    public class TradingPairConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => Enum.TryParse(reader.Value.ToString(), out TradingPair pair) ? pair : Unknown;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}