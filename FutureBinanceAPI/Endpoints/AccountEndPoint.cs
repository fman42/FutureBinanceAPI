using FutureBinanceAPI.Tools.HttpBuilder;
using FutureBinanceAPI.Models;
using FutureBinanceAPI.API;
using System.Threading.Tasks;
using System.Net.Http;

namespace FutureBinanceAPI.Endpoints
{
    public class AccountEndPoint : IEndpoint
    {
        public string APIEndPoint { get; } = "/fapi/v1/account";
        private AuthClient Client { get; set; }
        private IHttpBuilder HttpBuilder { get; set; }
        public AccountEndPoint(AuthClient client)
        {
            Client = client;
            HttpBuilder = new AuthBuilder(Client, Client.DebugMode);
        }

        public async Task<Account> Get()
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Get, APIEndPoint);
            return await Client.SendRequest<Account>(message);
        }
    }
}
