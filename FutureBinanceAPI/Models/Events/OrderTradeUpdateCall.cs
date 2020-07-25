using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events
{
    public class OrderTradeUpdateCall : IEventModel
    {
        [JsonProperty("e")]
        public EventType EventType { get; } = EventType.ORDER_TRADE_UPDATE;

        [JsonProperty("E")]
        public long Time { get; set; }

        [JsonProperty("T")]
        public long TransactionTime { get; set; }

        [JsonProperty("o")]
        public General.Order Order { get; set; }
    }
}
