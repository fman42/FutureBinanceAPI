using FutureBinanceAPI.Models.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events
{
    public class StreamMarginCall : IEventModel
    {
        [JsonProperty("e")]
        public EventTypes EventType { get; } = EventTypes.MARGIN_CALL;

        [JsonProperty("E")]
        public long Time { get; set; }

        [JsonProperty("cw")]
        public decimal? CrossWalletBalance { get; set; }

        [JsonProperty("p")]
        public List<General.Position> Positions { get; set; }
    }
}
