using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Streams.Interfaces
{
    public interface IListener
    {
        EventTypes Type { get; }

        void Update(string message);
    }
}