using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models
{
    public class Order
    {
        public string ClientOrderId { get; set; }

        public decimal CumQty { get; set; }

        public decimal CumQuote { get; set; }

        public decimal ExecutedQty { get; set; }

        public long OrderId { get; set; }

        public long UpdateTime { get; set; }

        public decimal OrigQty { get; set; }

        public decimal AvgPrice { get; set; }

        public decimal Price { get; set; }

        public decimal StopPrice { get; set; }

        public decimal ActivatePrice { get; set; }

        public decimal PriceRate { get; set; }

        public bool ReduceOnly { get; set; }

        public bool ClosePosition { get; set; }

        public bool PriceProtect { get; set; }

        public TimeInForceType TimeInForce { get; set; }

        public Side Side { get; set; }

        public PositionSide PositionSide { get; set; }

        public OrderStatus Status { get; set; }

        public TradingPair Symbol { get; set; }

        public OrderType Type { get; set; }

        public OrderType OrigType { get; set; }

        public WorkingType WorkingType { get; set; }
    }
}
