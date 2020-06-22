using FutureBinanceAPI.Models.Enums;
using System.Collections.Generic;

namespace FutureBinanceAPI.Models.Orders
{
    public class MarketOrder : Order, IOrder
    {
        public Symbols Symbol { get; set; }
        public SideTypes Side { get; set; }
        public Types Type { get; } = Types.MARKET;
        public WorkingType WorkingType { get; set; } = WorkingType.CONTRACT_PRICE;
        public decimal Quantity { get; set; }
        public bool ReduceOnly { get; set; } = false;
        public MarketOrder(Symbols symbol, SideTypes side, decimal quantity)
        {
            Symbol = symbol;
            Side = side;
            Quantity = quantity;
        }
    }
}
