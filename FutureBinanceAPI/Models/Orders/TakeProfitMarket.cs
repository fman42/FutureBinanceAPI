using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class TakeProfitMarket : IOrder
    {
        public TradingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; } = OrderType.TAKE_PROFIT_MARKET;

        public WorkingType WorkingType { get; set; }

        public ClosePositionType ClosePosition { get; set; }

        public decimal Quantity { get; set; }

        public decimal StopPrice { get; set; }

        public bool ReduceOnly { get; set; }

        public TakeProfitMarket(TradingPair TradingPair, Side side, decimal quantity, decimal stopPrice)
        {
            Symbol = TradingPair;
            Side = side;
            StopPrice = stopPrice;
            Quantity = quantity;
        }
    }
}
