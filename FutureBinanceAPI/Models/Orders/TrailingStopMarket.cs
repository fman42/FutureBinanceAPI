using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public class TrailingStopMarket : Order, IOrder
    {
        public SymbolsEnum.Symbols Symbol { get; set; }
        public SideEnum.SideTypes Side { get; set; }
        public TypesOrderEnum.Types Type { get; } = TypesOrderEnum.Types.TRAILING_STOP_MARKET;
        public WorkingTypeEnum.WorkingType WorkingType { get; set; }
        public decimal Quantity { get; set; }
        public decimal CallbackRate { get; set; }
        public bool ReduceOnly { get; set; }
        public TrailingStopMarket(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal quantity, decimal callbackRate)
        {
            Symbol = symbol;
            Side = side;
            CallbackRate = callbackRate;
            Quantity = quantity;
        }
    }
}
