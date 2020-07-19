using FutureBinanceAPI.Tools.HttpBuilder;
using FutureBinanceAPI.Models;
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

        private AuthClient Client { get; set; }

        private IHttpBuilder HttpBuilder { get; set; }
        #endregion

        #region Init
        public StreamEndPoint(AuthClient client)
        {
            Client = client;
            HttpBuilder = new AuthBuilder(Client);
        }
        #endregion

        #region Methods
        public async Task<string> Start()
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, APIEndPoint, null);
            string response = await Client.SendRequestAsync(message);

            return JObject.Parse(response)["listenKey"].ToString();
        }

        public async void Delete() => await Client.SendRequestAsync(HttpBuilder.MakeRequest(HttpMethod.Delete, APIEndPoint, null));

        public async void KeepAlive() => await Client.SendRequestAsync(HttpBuilder.MakeRequest(HttpMethod.Put, APIEndPoint, null));
        #endregion
    }
}
