using FutureBinanceAPI.Tools.HttpBuilder;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models;
using FutureBinanceAPI.API;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace FutureBinanceAPI.Endpoints
{
    public class TradeEndPoint : IEndpoint
    {
        public string APIEndPoint { get; } = "/fapi/v1";
        private AuthClient Client { get; set; }
        private IHttpBuilder HttpBuilder { get; set; }
        public TradeEndPoint(AuthClient client)
        {
            Client = client;
            HttpBuilder = new AuthBuilder(Client, Client.DebugMode);
        }

        public async Task<Leverage> SetLeverage(SymbolsEnum.Symbols symbol, int value)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, $"{APIEndPoint}/leverage", new[] {
                new KeyValuePair<string,string>("symbol", symbol.ToString()),
                new KeyValuePair<string,string>("leverage", value.ToString()),
            });
            return await Client.SendRequest<Leverage>(message);
        }

        public async Task<bool> SetMarginType(SymbolsEnum.Symbols symbol, MarginEnum.MarginTypes marginType)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, $"{APIEndPoint}/marginType", new[] {
                new KeyValuePair<string,string>("symbol", symbol.ToString()),
                new KeyValuePair<string,string>("marginType", marginType.ToString()),
            });

            ResponseStatus response = await Client.SendRequest<ResponseStatus>(message);
            return response != null ? response.Code == 200 && response.Msg == "success" : false;
        }
    }
}
