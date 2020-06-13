using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;

namespace FutureBinanceAPI.Tools.HttpBuilder
{
    public class Builder
    {
        protected readonly string API_BASE = "https://fapi.binance.com";
        protected readonly string API_BASE_TEST = "https://testnet.binancefuture.com";
    
        private bool DebugMode { get; set; }

        public Builder(bool debug = false)
        {
            DebugMode = debug;
        }

        protected string GetRequestUrl(string url) => DebugMode ? $"{API_BASE_TEST}{url}"
            : $"{API_BASE}{url}";
        protected string CreateQueryString(IEnumerable<KeyValuePair<string, string>> args)
        {
            string[] queryStrings = new string[args.Count()];
            for (int i = 0; i < args.Count(); i++)
                queryStrings[i] = string.Format("{0}={1}",
                    HttpUtility.UrlEncode(args.ElementAt(i).Key),
                    HttpUtility.UrlEncode(args.ElementAt(i).Value));

            return "?" + string.Join("&", queryStrings);
        }

        protected long GetTimeStamp() => (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
    }
}
