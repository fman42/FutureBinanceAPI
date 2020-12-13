using FutureBinanceAPI.Tools.HttpBuilder;
using FutureBinanceAPI.Models;
using FutureBinanceAPI.API;
using System.Threading.Tasks;
using System.Net.Http;
using FutureBinanceAPI.Models.Accounts;
using FutureBinanceAPI.Models.Enums;
using System.Collections.Generic;

namespace FutureBinanceAPI.Endpoints
{
    public class AccountEndPoint
    {
        #region Var
        public const string APIEndPoint = "/fapi/v2";

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
            HttpRequestMessage message = HttpBuilder.MakeRequest($"{APIEndPoint}/account");
            return await Client.SendRequestAsync<Account>(message);
        }

        public async Task<PositionRisk[]> GetPositionRiskAsync()
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest($"{APIEndPoint}/positionRisk");
            return await Client.SendRequestAsync<PositionRisk[]>(message);
        }

        public async Task<PositionRisk[]> GetPositionRiskAsync(TradingPair tradingPair)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest($"{APIEndPoint}/positionRisk", new[] {
                new KeyValuePair<string,string>("symbol", $"{tradingPair}"),
            });
            return await Client.SendRequestAsync<PositionRisk[]>(message);
        }
        #endregion
    }
}
