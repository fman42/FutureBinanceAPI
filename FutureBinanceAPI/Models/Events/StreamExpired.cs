using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models.Events
{
    public class StreamExpired : IEventModel
    {
        [JsonProperty("e")]
        public EventType EventType { get; } = EventType.listenKeyExpired;

        [JsonProperty("T")]
        public long Time { get; set; }
    }
}
