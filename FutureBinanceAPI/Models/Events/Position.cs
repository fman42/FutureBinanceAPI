using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Events
{
    public class Position
    {
        public Symbols Symbol { get; set; }
        public SideTypes Side { get; set; }
        public decimal Ammount { get; set; }
        public MarginTypes MarginType { get; set; }
        public decimal IsolatedWallet { get; set; }
        public decimal MarkPrice { get; set; }
        public decimal UnrealPNL { get; set; }
        public decimal MaintenanceMargin { get; set; }
    }
}
