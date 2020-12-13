using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FutureBinanceAPI.API;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models.Market;
using FutureBinanceAPI.Tools.HttpBuilder;
using Newtonsoft.Json.Linq;

namespace FutureBinanceAPI.Endpoints
{
    public class MarketEndPoint
    {
        #region Var
        public const string APIEndPoint = "/fapi/v1";

        private Client Client { get; }

        private IHttpBuilder HttpBuilder { get; }
        #endregion

        #region Init
        public MarketEndPoint(Client client)
        {
            Client = client;
            HttpBuilder = new DefaultBuilder(Client);
        }
        #endregion

        #region Methods
        public async Task<ulong> CheckServerTimeAsync()
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest($"{APIEndPoint}/time", null);
            return JObject.Parse(await Client.SendRequestAsync<string>(message))["serverTime"].ToObject<ulong>();
        }

        public async Task<ExchangeInfo> GetExchangeInfoAsync()
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest($"{APIEndPoint}/exchangeInfo", null);
            return await Client.SendRequestAsync<ExchangeInfo>(message);
        }

        public async Task<MarkPrice> GetMarkPriceAsync(TradingPair tradingPair)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest($"{APIEndPoint}/premiumIndex", new[] {
                new KeyValuePair<string,string>("symbol", $"{tradingPair}"),
            });
            return await Client.SendRequestAsync<MarkPrice>(message);
        }

        public async Task<MarkPrice[]> GetMarkPriceAsync()
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest($"{APIEndPoint}/premiumIndex", null);
            return await Client.SendRequestAsync<MarkPrice[]>(message);
        }
        #endregion
    }
}
