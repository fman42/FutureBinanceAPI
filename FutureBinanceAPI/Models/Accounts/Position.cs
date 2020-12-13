using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Accounts
{
    public class Position
    {
        public bool Isolated { get; set; }

        public decimal ExecutedQty { get; set; }

        public decimal InitialMargin { get; set; }

        public decimal MaintMargin { get; set; }

        public decimal UnrealizedProfit { get; set; }

        public decimal PositionInitialMargin { get; set; }

        public decimal OpenOrderInitialMargin { get; set; }

        public decimal MaxNotional { get; set; }

        public decimal OrigQty { get; set; }

        public decimal Leverage { get; set; }

        public decimal EntryPrice { get; set; }

        public decimal PositionAmt { get; set; }

        public TradingPair Symbol { get; set; }

        public PositionSide PositionSide { get; set; }
    }
}
