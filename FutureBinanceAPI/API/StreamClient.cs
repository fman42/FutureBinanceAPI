namespace FutureBinanceAPI.API
{
    public class StreamClient
    {
        #region Var
        private const string DefaultWSBasePoint = "wss://stream.binancefuture.com/ws";

        public readonly string WSUrl;

        public readonly string UserListenKey;
        #endregion

        #region Init
        public StreamClient(string userListenKey) : this(userListenKey, DefaultWSBasePoint) { }

        public StreamClient(string userListenKey, string webSocketUrl) => (UserListenKey, WSUrl) = (userListenKey, webSocketUrl);
        #endregion
    }
}
