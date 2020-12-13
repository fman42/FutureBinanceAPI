using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Market
{
    public class SymbolExchangeInfo
    {
        public TradingPair Symbol { get; set; }

        public TradingPair Pair { get; set; }

        public string ContractType { get; set; }

        public ulong DeliveryDate { get; set; }

        public ulong OnboardDate { get; set; }

        public string Status { get; set; }

        public decimal MaintMarginPercent { get; set; }

        public decimal RequiredMarginPercent { get; set; }

        public string BaseAsset { get; set; }

        public string QuoteAsset { get; set; }

        public string MarginAsset { get; set; }

        public short PricePrecision { get; set; }

        public short QuantityPrecision { get; set; }

        public short QuotePrecision { get; set; }

        public string UnderlyingType { get; set; }

        public string[] UnderlyingSubType { get; set; }

        public int SettlePlan { get; set; }

        public decimal TriggerProtect { get; set; }

        public JArray Filters { get; set; }

        public TimeInForceType[] TimeInForce { get; set; }
    }
}
