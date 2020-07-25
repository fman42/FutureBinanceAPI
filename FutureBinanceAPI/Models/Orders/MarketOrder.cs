using FutureBinanceAPI.Models.Enums;
using System.Collections.Generic;

namespace FutureBinanceAPI.Models.Orders
{
    public class MarketOrder : Order, IOrder
    {
        public TraidingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; } = OrderType.MARKET;

        public WorkingType WorkingType { get; set; } = WorkingType.CONTRACT_PRICE;

        public decimal Quantity { get; set; }

        public bool ReduceOnly { get; set; } = false;

        public MarketOrder(TraidingPair traidingPair, Side side, decimal quantity)
        {
            Symbol = traidingPair;
            Side = side;
            Quantity = quantity;
        }
    }
}
