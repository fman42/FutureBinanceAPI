using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FutureBinanceAPI.API;
using FutureBinanceAPI.Tools.HttpBuilder;

namespace FutureBinanceAPI.CustomRequest
{
    public class Request
    {
        #region Var
        private Client Client { get; }

        private IHttpBuilder Builder { get; }
        #endregion

        #region Init
        public Request(Client client)
        {
            Client = client;
            Builder = client is AuthClient ? (IHttpBuilder)new AuthBuilder((AuthClient)Client)
                : (IHttpBuilder)new DefaultBuilder(Client);
        }
        #endregion

        #region Methods
        public Task<string> SendAsync(IEnumerable<KeyValuePair<string, string>> args, HttpMethod method, string endpoint)
        {
            HttpRequestMessage message = Builder.MakeRequest(method, endpoint, args);
            return Client.SendRequestAsync<string>(message);
        }
        #endregion
    }
}
