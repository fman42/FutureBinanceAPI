using FutureBinanceAPI.Tools.HttpBuilder;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models;
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
        public async Task<Leverage> SetLeverageAsync(TraidingPair traidingPair, int value)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, $"{APIEndPoint}/leverage", new[] {
                new KeyValuePair<string,string>("symbol", traidingPair.ToString()),
                new KeyValuePair<string,string>("leverage", value.ToString()),
            });
            return await Client.SendRequestAsync<Leverage>(message);
        }

        public async Task<bool> SetMarginTypeAsync(TraidingPair traidingPair, MarginType marginType)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, $"{APIEndPoint}/marginType", new[] {
                new KeyValuePair<string,string>("symbol", traidingPair.ToString()),
                new KeyValuePair<string,string>("marginType", marginType.ToString()),
            });

            ResponseStatus response = await Client.SendRequestAsync<ResponseStatus>(message);
            return response is { } && response.Code == 200 && response.Msg == "success";
        }

        public async Task<bool> ModifiyIsolatedPositionMarge(TraidingPair traidingPair, decimal amount, int type, PositionSide positionSide = PositionSide.BOTH)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, $"{APIEndPoint}/positionMargin", new[] {
                new KeyValuePair<string,string>("symbol", traidingPair.ToString()),
                new KeyValuePair<string,string>("amount", amount.ToString(new CultureInfo("en-US"))),
                new KeyValuePair<string,string>("type", type.ToString()),
                new KeyValuePair<string,string>("positionSide", positionSide.ToString()),
            });

            return JObject.Parse(await Client.SendRequestAsync<string>(message)).Value<int>("code") == 200;
        }

        public async Task<IEnumerable<MarginChange>> GetMarginChangesAsync(TraidingPair traidingPair, int limit = 100)
            => await SendRequestForMarginChanges(MakeGeneralParameters(traidingPair, limit));

        public async Task<IEnumerable<MarginChange>> GetMarginChangesAsync(TraidingPair traidingPair, int type, int limit = 100)
        {
            Dictionary<string, string> httpParams = MakeGeneralParameters(traidingPair, limit);
            httpParams.Add("type", type.ToString());

            return await SendRequestForMarginChanges(httpParams);
        }

        public async Task<IEnumerable<MarginChange>> GetMarginChangesAsync(TraidingPair traidingPair, int type, long startTime, long endTime, int limit = 100)
        {
            Dictionary<string, string> httpParams = MakeGeneralParameters(traidingPair, limit);
            httpParams.Add("type", type.ToString());
            httpParams.Add("startTime", startTime.ToString());
            httpParams.Add("endTime", endTime.ToString());

            return await SendRequestForMarginChanges(httpParams);
        }

        private async Task<IEnumerable<MarginChange>> SendRequestForMarginChanges(Dictionary<string, string> httpParams)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Get, $"{APIEndPoint}/positionMargin/history", httpParams);
            return await Client.SendRequestAsync<IEnumerable<MarginChange>>(message);
        }

        private Dictionary<string, string> MakeGeneralParameters(TraidingPair traidingPair, int limit)
        {
            return new Dictionary<string, string>()
            {
                { "symbol", traidingPair.ToString() },
                { "limit", limit.ToString() }
            };
        }
        #endregion
    }
}
