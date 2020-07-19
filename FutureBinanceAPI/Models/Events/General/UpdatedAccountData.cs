using FutureBinanceAPI.Models.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events.General
{
    public class UpdatedAccountData
    {
        [JsonProperty("m")]
        public EventReasonTypes EventReason { get; set; }

        [JsonProperty("B")]
        public List<AccountBalance> Balances { get; set; }

        [JsonProperty("P")]
        public List<Position> Positions { get; set; }
    }
}
