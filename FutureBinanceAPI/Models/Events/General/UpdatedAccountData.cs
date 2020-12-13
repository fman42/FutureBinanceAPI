using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events.General
{
    public class UpdatedAccountData
    {
        [JsonProperty("m")]
        public EventReasonType EventReason { get; set; }

        [JsonProperty("B")]
        public AccountBalance[] Balances { get; set; }

        [JsonProperty("P")]
        public Position[] Positions { get; set; }
    }
}
