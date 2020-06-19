using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    class StopMarket
    {
        public SymbolsEnum.Symbols Symbol { get; set; }
        public SideEnum.SideTypes Side { get; set; }
        public TypesOrderEnum.Types Type { get; } = TypesOrderEnum.Types.STOP_MARKET;
        public WorkingTypeEnum.WorkingType WorkingType { get; set; }
        public ClosePositionEnum.ClosePosition ClosePosition { get; set; }
        public decimal Quantity { get; set; }
        public decimal StopPrice { get; set; }
        public bool ReduceOnly { get; set; }
        public StopMarket(SymbolsEnum.Symbols symbol, SideEnum.SideTypes side, decimal stopPrice)
        {
            Symbol = symbol;
            Side = side;
            StopPrice = stopPrice;
        }
    }
}
