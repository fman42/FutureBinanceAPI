using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models
{
    public class Position
    {
        public bool Isolated { get; set; }

        public decimal ExecutedQty { get; set; }

        public decimal OrigQty { get; set; }

        public decimal Leverage { get; set; }

        public TraidingPair Symbol { get; set; }

        public decimal EntryPrice { get; set; }
    }
}
