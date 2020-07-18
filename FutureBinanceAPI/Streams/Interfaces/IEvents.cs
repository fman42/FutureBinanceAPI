namespace FutureBinanceAPI.Streams.Interfaces
{
    public interface IEvents
    {
        void AddListener(IListener listener);
        bool RemoveListener(IListener listener);
        void Alert(string message);
    }
}