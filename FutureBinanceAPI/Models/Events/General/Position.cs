using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Events.General
{
    public class Position
    {
        public TradingPair Symbol { get; set; }

        public Side Side { get; set; }

        public decimal Ammount { get; set; }

        public MarginType MarginType { get; set; }

        public decimal IsolatedWallet { get; set; }

        public decimal MarkPrice { get; set; }

        public decimal UnrealPNL { get; set; }

        public decimal MaintenanceMargin { get; set; }
    }
}
