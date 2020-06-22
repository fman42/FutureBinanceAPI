using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class TakeProfit : Order, IOrder
    {
        public Symbols Symbol { get; set; }
        public SideTypes Side { get; set; }
        public Types Type { get; } = Types.TAKE_PROFIT;
        public WorkingType WorkingType { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal StopPrice { get; set; }
        public bool ReduceOnly { get; set; }
        public TakeProfit(Symbols symbol, SideTypes side, decimal quantity, decimal price, decimal stopPrice)
        {
            Symbol = symbol;
            Side = side;
            Quantity = quantity;
            Price = price;
            StopPrice = stopPrice;
        }
    }
}
