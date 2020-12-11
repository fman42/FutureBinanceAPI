using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class StopOrder : IOrder
    {
        public TraidingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; } = OrderType.STOP;

        public WorkingType WorkingType { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal StopPrice { get; set; }

        public bool ReduceOnly { get; set; }

        public StopOrder(TraidingPair traidingPair, Side side, decimal quantity, decimal price, decimal stopPrice)
        {
            Symbol = traidingPair;
            Side = side;
            Quantity = quantity;
            Price = price;
            StopPrice = stopPrice;
        }
    }
}
