namespace FutureBinanceAPI.API
{
    public class DefaultClient : Client, IClient
    {
        public DefaultClient(bool debug = false) : base(debug) { }
    }
}
