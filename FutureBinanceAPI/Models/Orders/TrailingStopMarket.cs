using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class TrailingStopMarket : IOrder
    {
        public TradingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; } = OrderType.TRAILING_STOP_MARKET;

        public WorkingType WorkingType { get; set; }

        public decimal Quantity { get; set; }

        public decimal CallbackRate { get; set; }

        public bool ReduceOnly { get; set; }

        public TrailingStopMarket(TradingPair TradingPair, Side side, decimal quantity, decimal callbackRate)
        {
            Symbol = TradingPair;
            Side = side;
            CallbackRate = callbackRate;
            Quantity = quantity;
        }
    }
}
