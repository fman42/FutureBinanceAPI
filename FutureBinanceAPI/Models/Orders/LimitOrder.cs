using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class LimitOrder : IOrder
    {
        public TraidingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; } = OrderType.LIMIT;

        public WorkingType WorkingType { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public bool ReduceOnly { get; set; }

        public TimeInForceType TimeInForce { get; set; }

        public LimitOrder(TraidingPair traidingPair, Side side, decimal quantity, decimal price, TimeInForceType timeInForce)
        {
            Symbol = traidingPair;
            Side = side;
            Quantity = quantity;
            Price = price;
            TimeInForce = timeInForce;
        }
    }
}
