namespace FutureBinanceAPI.API
{
    public class DefaultClient : Client, IClient
    {
        #region Init
        public DefaultClient(bool debug = false) : base(debug) { }
        #endregion
    }
}
