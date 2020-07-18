using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Events
{
    public class StreamExpired : IStreamEvent
    {
        public EventTypes EventType { get; } = EventTypes.listenKeyExpired;
        public long Time { get; set; }
    }
}
