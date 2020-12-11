using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class TakeProfitMarket : IOrder
    {
        public TraidingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; } = OrderType.TAKE_PROFIT_MARKET;

        public WorkingType WorkingType { get; set; }

        public ClosePositionType ClosePosition { get; set; }

        public decimal Quantity { get; set; }

        public decimal StopPrice { get; set; }

        public bool ReduceOnly { get; set; }

        public TakeProfitMarket(TraidingPair traidingPair, Side side, decimal quantity, decimal stopPrice)
        {
            Symbol = traidingPair;
            Side = side;
            StopPrice = stopPrice;
            Quantity = quantity;
        }
    }
}
