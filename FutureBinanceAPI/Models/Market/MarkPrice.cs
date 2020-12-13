using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Market
{
    public class MarkPrice
    {
        public TradingPair Symbol { get; set; }

        [JsonProperty("MarkPrice")]
        public decimal MarkPriceValue { get; set; }

        public decimal IndexPrice { get; set; }

        public decimal LastFundingRate { get; set; }

        public ulong NextFundingTime { get; set; }

        public decimal InterestRate { get; set; }

        public ulong Time { get; set; }
    }
}
