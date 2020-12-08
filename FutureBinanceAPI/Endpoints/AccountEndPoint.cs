using FutureBinanceAPI.Tools.HttpBuilder;
using FutureBinanceAPI.Models;
using FutureBinanceAPI.API;
using System.Threading.Tasks;
using System.Net.Http;

namespace FutureBinanceAPI.Endpoints
{
    public class AccountEndPoint
    {
        #region Var
        public const string APIEndPoint = "/fapi/v1/account";

        private AuthClient Client { get; set; }

        private IHttpBuilder HttpBuilder { get; set; }
        #endregion

        #region Init
        public AccountEndPoint(AuthClient client)
        {
            Client = client;
            HttpBuilder = new AuthBuilder(Client);
        }
        #endregion

        #region Methods
        public async Task<Account> GetAsync()
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Get, APIEndPoint);
            return await Client.SendRequestAsync<Account>(message);
        }
        #endregion
    }
}
