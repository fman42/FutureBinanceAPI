using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Accounts
{
    public class PositionRisk
    {
        public decimal EntryPrice { get; set; }

        public MarginType MarginType { get; set; }

        public bool IsAutoAddMargin { get; set; }

        public decimal IsolatedMargin { get; set; }

        public int Leverage { get; set; }

        public decimal LiquidationPrice { get; set; }

        public decimal MarkPrice { get; set; }

        public int MaxNotionalValue { get; set; }

        public decimal PositionAmt { get; set; }

        public TradingPair Symbol { get; set; }

        public decimal UnRealizedProfit { get; set; }

        public PositionSide PositionSide { get; set; }
    }
}
