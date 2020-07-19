using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events.General
{
    public class Order
    {
        [JsonProperty("s")]
        public Symbols Symbol { get; set; }

        [JsonProperty("c")]
        public string ClientId { get; set; }

        [JsonProperty("S")]
        public SideTypes Side { get; set; }

        [JsonProperty("o")]
        public Types OrderType { get; set; }

        [JsonProperty("f")]
        public TimeInForceTypes TimeInForce { get; set; }

        [JsonProperty("q")]
        public decimal OriginalQuantity { get; set; }

        [JsonProperty("p")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("sp")]
        public decimal StopPrice { get; set; }

        [JsonProperty("x")]
        public OrderStatuses ExecutedOrderStatus { get; set; }

        [JsonProperty("X")]
        public OrderStatuses OrderStatus { get; set; }

        [JsonProperty("i")]
        public long OrderId { get; set; }

        [JsonProperty("wt")]
        public WorkingType WorkingType { get; set; }

        [JsonProperty("rp")]
        public decimal RealizedProfit { get; set; }
    }
}
