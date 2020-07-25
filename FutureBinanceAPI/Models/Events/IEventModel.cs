using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Events
{
    public interface IEventModel
    {
        EventType EventType { get; }

        long Time { get; set; }
    }
}
