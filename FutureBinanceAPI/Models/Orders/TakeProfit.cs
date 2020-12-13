using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class TakeProfit : IOrder
    {
        public TradingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; } = OrderType.TAKE_PROFIT;

        public WorkingType WorkingType { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal StopPrice { get; set; }

        public bool ReduceOnly { get; set; }

        public TakeProfit(TradingPair TradingPair, Side side, decimal quantity, decimal price, decimal stopPrice)
        {
            Symbol = TradingPair;
            Side = side;
            Quantity = quantity;
            Price = price;
            StopPrice = stopPrice;
        }
    }
}
