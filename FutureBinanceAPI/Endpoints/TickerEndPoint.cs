using FutureBinanceAPI.Tools.HttpBuilder;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models;
using FutureBinanceAPI.API;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace FutureBinanceAPI.Endpoints
{
    public class TickerEndPoint
    {
        #region Var
        public string APIEndPoint { get; } = "/fapi/v1/ticker";

        private Client Client { get; set; }

        private IHttpBuilder HttpBuilder { get; set; }
        #endregion

        #region Init
        public TickerEndPoint(Client client)
        {
            Client = client;
            HttpBuilder = new DefaultBuilder(Client);
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<PriceTicker>> GetPriceTickerAsync() =>
            await Client.SendRequestAsync<IEnumerable<PriceTicker>>(HttpBuilder.MakeRequest(APIEndPoint + "/price"));

        public async Task<PriceTicker> GetPriceTickerAsync(TradingPair TradingPair)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(APIEndPoint + "/price", new[] {
                new KeyValuePair<string,string>("symbol", TradingPair.ToString()) });

            return await Client.SendRequestAsync<PriceTicker>(message);
        }

        public async Task<IEnumerable<BookTicker>> GetBookTickerAsync() =>
            await Client.SendRequestAsync<IEnumerable<BookTicker>>(HttpBuilder.MakeRequest(APIEndPoint + "/bookTicker"));

        public async Task<BookTicker> GetBookTickerAsync(TradingPair TradingPair)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(APIEndPoint + "/bookTicker", new[] {
                new KeyValuePair<string,string>("symbol", TradingPair.ToString()) });

            return await Client.SendRequestAsync<BookTicker>(message);
        }
        #endregion
    }
}
