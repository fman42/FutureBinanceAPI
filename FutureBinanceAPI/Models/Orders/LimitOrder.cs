using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class LimitOrder : Order, IOrder
    {
        public SymbolsEnum.Symbols Symbol { get; set; }
        public SideEnum.SideTypes Side { get; set; }
        public TypesOrderEnum.Types Type { get; } = TypesOrderEnum.Types.LIMIT;
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public TimeInForceEnum.TineInForceTypes TimeInForce { get; set; }
        public LimitOrder(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity, decimal price, TimeInForceEnum.TineInForceTypes timeInForce)
        {
            Symbol = symbol;
            Side = side;
            Quantity = quantity;
            Price = price;
            TimeInForce = timeInForce;
        }
    }
}
