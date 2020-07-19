namespace FutureBinanceAPI.Streams.Interfaces
{
    public interface IEvent
    {
        void AddListener(IListener listener);

        bool RemoveListener(IListener listener);

        void Alert(string message);
    }
}