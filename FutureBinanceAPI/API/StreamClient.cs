namespace FutureBinanceAPI.API
{
    public class StreamClient
    {
        #region Var
        private const string DebugWSBasePoint = "wss://stream.binancefuture.com";

        private const string MainWSBasePoint = "wss://fstream.binance.com";

        public readonly string WSUrl;

        public readonly string UserListenKey;
        #endregion

        #region Init
        /// <summary>
        /// <para>Create the client for streams of binance</para>
        /// <para>If you want use testnet exchange then set <paramref name="useTestnet"/> in "true"</para>
        /// <para>Else if you use main excange set <paramref name="useTestnet"/> in "false" or ignore it</para>
        /// </summary>
        public StreamClient(string userListenKey, bool useTestnet = false)
        {
            UserListenKey = userListenKey;
            WSUrl = useTestnet ? DebugWSBasePoint : MainWSBasePoint;
        }

        /// <summary>
        /// Create the client for streams of binance with custom web socket url
        /// </summary>
        /// <param name="userListenKey"></param>
        /// <param name="webSocketUrl"></param>
        public StreamClient(string userListenKey, string webSocketUrl) => (UserListenKey, WSUrl) = (userListenKey, webSocketUrl);
        #endregion
    }
}
