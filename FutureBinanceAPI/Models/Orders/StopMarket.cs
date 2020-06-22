using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class StopMarket : Order, IOrder
    {
        public Symbols Symbol { get; set; }
        public SideTypes Side { get; set; }
        public Types Type { get; } = Types.STOP_MARKET;
        public WorkingType WorkingType { get; set; }
        public ClosePosition ClosePosition { get; set; }
        public decimal Quantity { get; set; }
        public decimal StopPrice { get; set; }
        public bool ReduceOnly { get; set; }
        public StopMarket(Symbols symbol, SideTypes side, decimal quantity, decimal stopPrice)
        {
            Symbol = symbol;
            Side = side;
            StopPrice = stopPrice;
            Quantity = quantity;
        }
    }
}
