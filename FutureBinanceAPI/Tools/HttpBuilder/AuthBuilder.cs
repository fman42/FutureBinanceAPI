using FutureBinanceAPI.API;
using System.Collections.Generic;
using System.Net.Http;
using FutureBinanceAPI.Tools.Cipher;
using System.Linq;
using System;

namespace FutureBinanceAPI.Tools.HttpBuilder
{
    class AuthBuilder : Builder, IHttpBuilder
    {
        private AuthClient Client { get; }
        public AuthBuilder(AuthClient client, bool debug) : base(debug)
        {
            Client = client;
        }

        public HttpRequestMessage MakeRequest(string url, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            return MakeRequest(HttpMethod.Get, url, args);
        }

        public HttpRequestMessage MakeRequest(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> args = null)
        {
            HttpRequestMessage content = new HttpRequestMessage(method, GetRequestUrl(url));
            if (args == null) args = Enumerable.Empty<KeyValuePair<string, string>>();

            content.Headers.Add("X-MBX-APIKEY", Client.APIKey);
            if (method == HttpMethod.Get)
            {
                content.RequestUri = new Uri(content.RequestUri.OriginalString +
                    CreateQueryString(BuildRequest(args)));
            } else content.Content = new FormUrlEncodedContent(BuildRequest(args));

            return content;
        }

        private IEnumerable<KeyValuePair<string, string>> BuildRequest(IEnumerable<KeyValuePair<string, string>> args)
        {
            Dictionary<string, string> requestCollection = args.ToDictionary(x => x.Key, x => x.Value);
            requestCollection = SetPrimaryFields(requestCollection);
            requestCollection.Add("signature", RequestCrypter.CreateHMAC(Client.SecretKey,
                new FormUrlEncodedContent(requestCollection)));

            return requestCollection;
        }

        private Dictionary<string, string> SetPrimaryFields(Dictionary<string, string> args)
        {
            args.Add("recvWindow", Client.RecvWindow.ToString());
            args.Add("timestamp", GetTimeStamp().ToString());
            return args;
        }
    }
}
