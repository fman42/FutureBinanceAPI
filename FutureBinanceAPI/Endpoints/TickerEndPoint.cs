using FutureBinanceAPI.Tools.HttpBuilder;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models;
using FutureBinanceAPI.API;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace FutureBinanceAPI.Endpoints
{
    public class TickerEndPoint : IEndpoint
    {
        public string APIEndPoint { get; } = "/fapi/v1/ticker";
        private Client Client { get; set; }
        private IHttpBuilder HttpBuilder { get; set; }
        public TickerEndPoint(Client client)
        {
            Client = client;
            HttpBuilder = new DefaultBuilder(Client.DebugMode);
        }

        public async Task<IEnumerable<PriceTicker>> GetPriceTicker() =>
            await Client.SendRequest<IEnumerable<PriceTicker>>(HttpBuilder.MakeRequest(APIEndPoint + "/price"));

        public async Task<PriceTicker> GetPriceTicker(SymbolsEnum.Symbols symbol)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(APIEndPoint + "/price", new[] {
                new KeyValuePair<string,string>("symbol", symbol.ToString()) });

            return await Client.SendRequest<PriceTicker>(message);
        }

        public async Task<IEnumerable<BookTicker>> GetBookTicker() =>
            await Client.SendRequest<IEnumerable<BookTicker>>(HttpBuilder.MakeRequest(APIEndPoint + "/bookTicker"));

        public async Task<BookTicker> GetBookTicker(SymbolsEnum.Symbols symbol)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(APIEndPoint + "/bookTicker", new[] {
                new KeyValuePair<string,string>("symbol", symbol.ToString()) });

            return await Client.SendRequest<BookTicker>(message);
        }
    }
}
