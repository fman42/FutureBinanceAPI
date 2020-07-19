using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class LimitOrder : Order, IOrder
    {
        public Symbols Symbol { get; set; }
        public SideTypes Side { get; set; }
        public Types Type { get; } = Types.LIMIT;
        public WorkingType WorkingType { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public bool ReduceOnly { get; set; }
        public TimeInForceTypes TimeInForce { get; set; }
        public LimitOrder(Symbols symbol, SideTypes side, decimal quantity, decimal price, TimeInForceTypes timeInForce)
        {
            Symbol = symbol;
            Side = side;
            Quantity = quantity;
            Price = price;
            TimeInForce = timeInForce;
        }
    }
}
