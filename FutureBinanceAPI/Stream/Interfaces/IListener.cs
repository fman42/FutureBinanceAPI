using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Stream.Interfaces
{
    public interface IListener
    {
        EventTypes Type { get; }

        void Update(string message);
    }
}