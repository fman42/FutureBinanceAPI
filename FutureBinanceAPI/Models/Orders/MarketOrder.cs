using FutureBinanceAPI.Models.Enums;
using System.Collections.Generic;

namespace FutureBinanceAPI.Models.Orders
{
    public class MarketOrder : Order, IOrder
    {
        public SymbolsEnum.Symbols Symbol { get; set; }
        public SideEnum.SideTypes Side { get; set; }
        public TypesOrderEnum.Types Type { get; } = TypesOrderEnum.Types.MARKET;
        public WorkingTypeEnum.WorkingType WorkingType { get; set; } = WorkingTypeEnum.WorkingType.CONTRACT_PRICE;
        public decimal Quantity { get; set; }
        public bool ReduceOnly { get; set; } = false;
        public MarketOrder(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity)
        {
            Symbol = symbol;
            Side = side;
            Quantity = quantity;
        }
    }
}
