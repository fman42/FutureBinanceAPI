using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class TrailingStopMarket : Order, IOrder
    {
        public Symbols Symbol { get; set; }
        public SideTypes Side { get; set; }
        public Types Type { get; } = Types.TRAILING_STOP_MARKET;
        public WorkingType WorkingType { get; set; }
        public decimal Quantity { get; set; }
        public decimal CallbackRate { get; set; }
        public bool ReduceOnly { get; set; }
        public TrailingStopMarket(Symbols symbol, SideTypes side, decimal quantity, decimal callbackRate)
        {
            Symbol = symbol;
            Side = side;
            CallbackRate = callbackRate;
            Quantity = quantity;
        }
    }
}
