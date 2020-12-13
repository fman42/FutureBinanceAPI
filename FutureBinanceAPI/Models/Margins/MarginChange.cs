using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Margins
{
    public class MarginChange
    {
        public decimal Amount { get; set; }

        public Asset Asset { get; set; }

        public TradingPair Symbol { get; set; }

        public long Time { get; set; }

        public int Type { get; set; }

        public PositionSide PositionSide { get; set; }
    }
}