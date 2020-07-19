using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events.General
{
    public class AccountBalance
    {
        [JsonProperty("a")]
        public Assets Symbol { get; set; }

        [JsonProperty("wb")]
        public decimal WalletBalance { get; set; }

        [JsonProperty("cw")]
        public decimal CrossWalletBalance { get; set; }
    }
}
