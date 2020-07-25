using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models
{
    public class Position
    {
        public bool Isolated { get; set; }

        public float Leverage { get; set; }

        public TraidingPair Symbol { get; set; }

        public decimal EntryPrice { get; set; }
    }
}
