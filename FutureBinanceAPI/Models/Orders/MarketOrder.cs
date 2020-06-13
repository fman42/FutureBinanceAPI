using FutureBinanceAPI.Models.Enums;
using System.Collections.Generic;

namespace FutureBinanceAPI.Models.Orders
{
    public class MarketOrder : Order, IOrder
    {
        public SymbolsEnum.Symbols Symbol { get; set; }
        public SideEnum.SideTypes Side { get; set; }
        public TypesOrderEnum.Types Type { get; } = TypesOrderEnum.Types.MARKET;
        public decimal Quantity { get; set; }
        public MarketOrder(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity)
        {
            Symbol = symbol;
            Side = side;
            Quantity = quantity;
        }
    }
}
