using System;
using FutureBinanceAPI.Models.Enums;
using static FutureBinanceAPI.Models.Enums.Asset;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Tools.Converters
{
    public class AssetsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => Enum.TryParse(reader.Value.ToString(), out Asset pair) ? pair : Unknown;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}