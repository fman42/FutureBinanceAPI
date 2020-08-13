namespace FutureBinanceAPI.API
{
    public class DefaultClient : Client, IClient
    {
        #region Init
        /// <summary>
        /// Create the client for default request
        /// <para>If you want use testnet exchange then set <paramref name="useTestnet"/> in "true"</para>
        /// <para>Else if you use main excange set <paramref name="useTestnet"/> in "false" or ignore it</para>
        /// </summary>
        public DefaultClient(bool useTestnet = false) : base(useTestnet) { }
        #endregion
    }
}
