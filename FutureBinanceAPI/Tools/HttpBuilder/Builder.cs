using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;

namespace FutureBinanceAPI.Tools.HttpBuilder
{
    internal class Builder
    {
        #region Var
        protected const string API_BASE = "https://fapi.binance.com";

        protected const string API_BASE_TEST = "https://testnet.binancefuture.com";
    
        private bool DebugMode { get; }
        #endregion

        #region Init
        public Builder(bool debug = false) => DebugMode = debug;
        #endregion

        #region Methods
        protected string GetRequestUrl(string url) => DebugMode ? $"{API_BASE_TEST}{url}"
            : $"{API_BASE}{url}";

        protected string CreateQueryString(IEnumerable<KeyValuePair<string, string>> args)
        {
            string joinedQueryPiceses = string.Join('&', args
                .Select(x => $"{HttpUtility.UrlEncode(x.Key)}={HttpUtility.UrlEncode(x.Value)}"));

            return $"?{joinedQueryPiceses}";
        }

        protected static long GetTimeStamp() => (long) DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalMilliseconds;
        #endregion
    }
}
