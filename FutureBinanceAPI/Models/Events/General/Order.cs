using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events.General
{
    public class Order
    {
        [JsonProperty("s")]
        public TradingPair Symbol { get; set; }

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

        [JsonProperty("ps")]
        public PositionSide PositionSide { get; set; }

        [JsonProperty("l")]
        public decimal LastFilledQuantity { get; set; }

        [JsonProperty("z")]
        public decimal FilledQuantity { get; set; }

        [JsonProperty("L")]
        public decimal LastFilledPrice { get; set; }

        [JsonProperty("cp")]
        public bool CloseAll { get; set; }

        [JsonProperty("N")]
        public Asset ComissionAsset { get; set; }

        [JsonProperty("n")]
        public decimal Comission { get; set; }

        [JsonProperty("T")]
        public long TradeTime { get; set; }

        [JsonProperty("t")]
        public long TradeId { get; set; }

        [JsonProperty("b")]
        public decimal BidsNotional { get; set; }

        [JsonProperty("a")]
        public decimal AskNotional { get; set; }

        [JsonProperty("m")]
        public bool IsTradeMakerSide { get; set; }

        [JsonProperty("R")]
        public bool IsReduce { get; set; }

        [JsonProperty("AP")]
        public decimal ActivationPrice { get; set; }

        [JsonProperty("cr")]
        public decimal CallbackRate { get; set; }

        [JsonProperty("rp")]
        public decimal RealizedProfit { get; set; }
    }
}
