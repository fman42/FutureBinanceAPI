using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    class TrailingStopMarket
    {
        public SymbolsEnum.Symbols Symbol { get; set; }
        public SideEnum.SideTypes Side { get; set; }
        public TypesOrderEnum.Types Type { get; } = TypesOrderEnum.Types.TAKE_PROFIT_MARKET;
        public WorkingTypeEnum.WorkingType WorkingType { get; set; }
        public decimal Quantity { get; set; }
        public decimal CallbackRate { get; set; }
        public bool ReduceOnly { get; set; }
        public TrailingStopMarket(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal callbackRate)
        {
            Symbol = symbol;
            Side = side;
            CallbackRate = callbackRate;
        }
    }
}
