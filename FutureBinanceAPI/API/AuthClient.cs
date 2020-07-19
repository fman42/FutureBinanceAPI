namespace FutureBinanceAPI.API
{
    public class AuthClient : Client, IClient
    {
        #region Var
        public string APIKey { get; private set; }

        public string SecretKey { get; private set; }

        public int RecvWindow { get; set; } = 1000;
        #endregion

        #region Init
        public AuthClient(string _APIKey, string _SecretKey, bool debug = false) : base(debug)
        {
            APIKey = _APIKey;
            SecretKey = _SecretKey;
        }
        #endregion
    }
}
