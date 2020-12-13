using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class MarketOrder : IOrder
    {
        public TradingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; } = OrderType.MARKET;

        public WorkingType WorkingType { get; set; } = WorkingType.CONTRACT_PRICE;

        public decimal Quantity { get; set; }

        public bool ReduceOnly { get; set; } = false;

        public MarketOrder(TradingPair TradingPair, Side side, decimal quantity)
        {
            Symbol = TradingPair;
            Side = side;
            Quantity = quantity;
        }
    }
}
