namespace FutureBinanceAPI.Stream.Interfaces
{
    public interface IEvent
    {
        void Add(IListener listener);

        bool Remove(IListener listener);

        void Alert(string message);
    }
}