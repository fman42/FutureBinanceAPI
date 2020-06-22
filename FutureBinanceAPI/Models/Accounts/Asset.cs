using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Accounts
{
    public class Asset
    {
        [JsonProperty("asset")]
        public Assets AssetName { get; set; }
        public decimal WalletBalance { get; set; }
    }
}
