using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events.General
{
    public class Order
    {
        [JsonProperty("s")]
        public TraidingPair Symbol { get; set; }

        [JsonProperty("c")]
        public string ClientId { get; set; }

        [JsonProperty("S")]
        public Side Side { get; set; }

        [JsonProperty("o")]
        public OrderType OrderType { get; set; }

        [JsonProperty("f")]
        public TimeInForceType TimeInForce { get; set; }

        [JsonProperty("q")]
        public decimal OriginalQuantity { get; set; }

        [JsonProperty("p")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("sp")]
        public decimal StopPrice { get; set; }

        [JsonProperty("x")]
        public OrderStatus ExecutedOrderStatus { get; set; }

        [JsonProperty("X")]
        public OrderStatus OrderStatus { get; set; }

        [JsonProperty("i")]
        public long OrderId { get; set; }

        [JsonProperty("wt")]
        public WorkingType WorkingType { get; set; }

        [JsonProperty("rp")]
        public decimal RealizedProfit { get; set; }
    }
}
