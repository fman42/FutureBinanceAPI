using FutureBinanceAPI.Tools.HttpBuilder;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models.Margins;
using FutureBinanceAPI.API;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace FutureBinanceAPI.Endpoints
{
    public class TradeEndPoint
    {
        #region Var
        public const string APIEndPoint = "/fapi/v1";

        private AuthClient Client { get; set; }

        private IHttpBuilder HttpBuilder { get; set; }
        #endregion

        #region Init
        public TradeEndPoint(AuthClient client)
        {
            Client = client;
            HttpBuilder = new AuthBuilder(Client);
        }
        #endregion

        #region Methods
        public async Task<bool> SetLeverageAsync(TradingPair tradingPair, int value)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, $"{APIEndPoint}/leverage", new[] {
                new KeyValuePair<string,string>("symbol", $"{tradingPair}"),
                new KeyValuePair<string,string>("leverage", $"{value}"),
            });

            return !string.IsNullOrEmpty(await Client.SendRequestAsync<string>(message));
        }

        public async Task<bool> SetMarginTypeAsync(TradingPair tradingPair, MarginType marginType)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, $"{APIEndPoint}/marginType", new[] {
                new KeyValuePair<string,string>("symbol", $"{tradingPair}"),
                new KeyValuePair<string,string>("marginType", $"{marginType}"),
            });

            JObject responseToJson = JObject.Parse(await Client.SendRequestAsync<string>(message));
            return responseToJson is { } && responseToJson.Value<string>("Msg") == "success";
        }

        public async Task<bool> ModifiyIsolatedPositionMarge(TradingPair TradingPair, decimal amount, int type, PositionSide positionSide = PositionSide.BOTH)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, $"{APIEndPoint}/positionMargin", new[] {
                new KeyValuePair<string,string>("symbol", $"{TradingPair}"),
                new KeyValuePair<string,string>("amount", amount.ToString(new CultureInfo("en-US"))),
                new KeyValuePair<string,string>("type", $"{type}"),
                new KeyValuePair<string,string>("positionSide", $"{positionSide}"),
            });

            return JObject.Parse(await Client.SendRequestAsync<string>(message)).Value<int>("code") == 200;
        }

        public async Task<IEnumerable<MarginChange>> GetMarginChangesAsync(TradingPair TradingPair, int limit = 100)
            => await SendRequestForMarginChanges(MakeGeneralParameters(TradingPair, limit));

        public async Task<IEnumerable<MarginChange>> GetMarginChangesAsync(TradingPair TradingPair, int type, int limit = 100)
        {
            Dictionary<string, string> httpParams = MakeGeneralParameters(TradingPair, limit);
            httpParams.Add("type", $"{type}");

            return await SendRequestForMarginChanges(httpParams);
        }

        public async Task<IEnumerable<MarginChange>> GetMarginChangesAsync(TradingPair TradingPair, int type, long startTime, long endTime, int limit = 100)
        {
            Dictionary<string, string> httpParams = MakeGeneralParameters(TradingPair, limit);
            httpParams.Add("type", $"{type}");
            httpParams.Add("startTime", $"{startTime}");
            httpParams.Add("endTime", $"{endTime}");

            return await SendRequestForMarginChanges(httpParams);
        }

        private async Task<IEnumerable<MarginChange>> SendRequestForMarginChanges(Dictionary<string, string> httpParams)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Get, $"{APIEndPoint}/positionMargin/history", httpParams);
            return await Client.SendRequestAsync<IEnumerable<MarginChange>>(message);
        }

        private Dictionary<string, string> MakeGeneralParameters(TradingPair TradingPair, int limit)
        {
            return new Dictionary<string, string>()
            {
                { "symbol", $"{TradingPair}" },
                { "limit", $"{limit}" }
            };
        }
        #endregion
    }
}
