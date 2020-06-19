﻿using System.Collections.Generic;
using System.Net.Http;

namespace FutureBinanceAPI.Tools.HttpBuilder
{
    class DefaultBuilder : Builder, IHttpBuilder
    {
        public DefaultBuilder(bool debug) : base(debug) { }

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
    }
}