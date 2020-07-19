using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events
{
    public class AccountUpdateCall : IEventModel
    {
        [JsonProperty("e")]
        public EventTypes EventType { get; } = EventTypes.ACCOUNT_UPDATE;

        [JsonProperty("E")]
        public long Time { get; set; }

        [JsonProperty("T")]
        public long TransactionTime { get; set; }

        [JsonProperty("a")]
        public General.UpdatedAccountData UpdatedData { get; set; }
    }
}
