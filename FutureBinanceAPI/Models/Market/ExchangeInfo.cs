namespace FutureBinanceAPI.Models.Market
{
    public class ExchangeInfo
    {
        public RateLimit[] RateLimits { get; set; }

        public ulong ServerTime { get; set; }

        public SymbolExchangeInfo[] Symbols { get; set; }

        public string Timezone { get; set; }
    }
}
