using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events.General
{
    public class Position
    {
        [JsonProperty("s")]
        public TradingPair Symbol { get; set; }

        [JsonProperty("ps")]
        public PositionSide Side { get; set; }

        [JsonProperty("pa")]
        public decimal Ammount { get; set; }

        [JsonProperty("mt")]
        public MarginType MarginType { get; set; }

        [JsonProperty("iw")]
        public decimal IsolatedWallet { get; set; }

        [JsonProperty("mp")]
        public decimal MarkPrice { get; set; }

        [JsonProperty("ep")]
        public decimal EntryPrice { get; set; }

        [JsonProperty("up")]
        public decimal UnrealPNL { get; set; }

        [JsonProperty("mm")]
        public decimal MaintenanceMargin { get; set; }
    }
}
