using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class StopOrder : Order, IOrder
    {
        public SymbolsEnum.Symbols Symbol { get; set; }
        public SideEnum.SideTypes Side { get; set; }
        public TypesOrderEnum.Types Type { get; } = TypesOrderEnum.Types.STOP;
        public WorkingTypeEnum.WorkingType WorkingType { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal StopPrice { get; set; }
        public bool ReduceOnly { get; set; }
        public StopOrder(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity, decimal price, decimal stopPrice)
        {
            Symbol = symbol;
            Side = side;
            Quantity = quantity;
            Price = price;
            StopPrice = stopPrice;
        }
    }
}
