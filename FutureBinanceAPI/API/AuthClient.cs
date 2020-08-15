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
        /// <summary>
        /// <para>Create the client for default request</para>
        /// <para>If you want use testnet exchange then set <paramref name="useTestnet"/> in "true"</para>
        /// <para>Else if you use main excange set <paramref name="useTestnet"/> in "false" or ignore it</para>
        /// </summary>
        public AuthClient(string _APIKey, string _SecretKey, bool useTestnet = false) : base(useTestnet)
        {
            APIKey = _APIKey;
            SecretKey = _SecretKey;
        }
        #endregion
    }
}
