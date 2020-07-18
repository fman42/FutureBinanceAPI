using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Events
{
    interface IStreamEvent
    {
        public EventTypes EventType { get; }
        public long Time { get; set; }
    }
}
