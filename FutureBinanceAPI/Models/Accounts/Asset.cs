using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Accounts
{
    public class Asset
    {
        [JsonProperty("asset")]
        public Enums.Asset AssetName { get; set; }

        public decimal WalletBalance { get; set; }
    }
}
