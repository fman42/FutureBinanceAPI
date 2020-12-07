using FutureBinanceAPI.Tools.HttpBuilder;
using FutureBinanceAPI.API;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace FutureBinanceAPI.Endpoints
{
    public class StreamEndPoint : IEndpoint
    {
        #region Var
        public string APIEndPoint { get; } = "/fapi/v1/listenKey";

        private AuthClient Client { get; }

        private IHttpBuilder HttpBuilder { get; }
        #endregion

        #region Init
        public StreamEndPoint(AuthClient client)
        {
            Client = client;
            HttpBuilder = new AuthBuilder(Client);
        }
        #endregion

        #region Methods
        public async Task<string> StartAsync()
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, APIEndPoint, null);
            string response = await Client.SendRequestAsync<string>(message);

            return JObject.Parse(response).Value<string>("listenKey");
        }

        public async void DeleteAsync() => await Client.SendRequestAsync(HttpBuilder.MakeRequest(HttpMethod.Delete, APIEndPoint, null));

        public async void KeepAliveAsync() => await Client.SendRequestAsync(HttpBuilder.MakeRequest(HttpMethod.Put, APIEndPoint, null));
        #endregion
    }
}
