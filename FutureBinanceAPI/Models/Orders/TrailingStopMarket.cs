using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class TrailingStopMarket : IOrder
    {
        public TraidingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; } = OrderType.TRAILING_STOP_MARKET;

        public WorkingType WorkingType { get; set; }

        public decimal Quantity { get; set; }

        public decimal CallbackRate { get; set; }

        public bool ReduceOnly { get; set; }

        public TrailingStopMarket(TraidingPair traidingPair, Side side, decimal quantity, decimal callbackRate)
        {
            Symbol = traidingPair;
            Side = side;
            CallbackRate = callbackRate;
            Quantity = quantity;
        }
    }
}
