using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Stream.Interfaces
{
    public interface IListener
    {
        EventType Type { get; }

        void Update(string message);
    }
}