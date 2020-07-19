using System.Collections.Generic;
using System.Net.Http;

namespace FutureBinanceAPI.Tools.HttpBuilder
{
    interface IHttpBuilder
    {
        HttpRequestMessage MakeRequest(string url, IEnumerable<KeyValuePair<string, string>> args = null);

        HttpRequestMessage MakeRequest(HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> args = null);
    }
}
