using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Accounts
{
    public class Asset
    {
        [JsonProperty("asset")]
        public Enums.Asset AssetName { get; set; }

        [JsonProperty("asset")]
        public string AssetNameToString { get; set; }

        public decimal WalletBalance { get; set; }

        public decimal UnrealizedProfit { get; set; }

        public decimal MarginBalance { get; set; }

        public decimal MintMargin { get; set; }

        public decimal InitialMargin { get; set; }

        public decimal PositionInitialMargin { get; set; }

        public decimal OpenOrderInitialMargin { get; set; }

        public decimal CrossWalletBalance { get; set; }

        public decimal CrossUnPnl { get; set; }

        public decimal AvailableBalance { get; set; }

        public decimal MaxWithdrawAmount { get; set; }
    }
}
