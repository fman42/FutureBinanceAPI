namespace FutureBinanceAPI.Models.Market
{
    public class RateLimit
    {
        public string Interval { get; set; }

        public int IntervalNum { get; set; }

        public int Limit { get; set; }

        public Enums.RateLimit RateLimitType { get; set; }
    }
}
