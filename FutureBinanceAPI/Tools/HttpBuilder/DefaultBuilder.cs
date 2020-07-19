using FutureBinanceAPI.API;
using System.Collections.Generic;
using System.Net.Http;

namespace FutureBinanceAPI.Tools.HttpBuilder
{
    class DefaultBuilder : Builder, IHttpBuilder
    {
        #region Var
        public DefaultBuilder(Client client) : base(client.DebugMode) { }
        #endregion

        #region Methods
        public HttpRequestMessage MakeRequest(string url, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            string requestUrl = GetRequestUrl(url);
            if (args != null) requestUrl += CreateQueryString(args);

            return new HttpRequestMessage(HttpMethod.Get, requestUrl);
        }

        public HttpRequestMessage MakeRequest(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
