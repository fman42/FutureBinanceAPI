using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models
{
    public class PriceTicker
    {
        public SymbolsEnum.Symbols Symbol { get; set; }
        public decimal Price { get; set; }
        public ulong Time { get; set; }
    }
}
