using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Events
{
    public interface IEventModel
    {
        EventTypes EventType { get; }

        long Time { get; set; }
    }
}
