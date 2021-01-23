using Newtonsoft.Json;
using FutureBinanceAPI.Tools.Converters;

namespace FutureBinanceAPI.Models.Enums
{
    [JsonConverter(typeof(AssetsConverter))]
    public enum Asset
    {
        Unknown,
        USDT,
        BNB,
        BUSD,
        DOTECO
    }
}
