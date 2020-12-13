using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FutureBinanceAPI.API;
using FutureBinanceAPI.Models;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Tools.Extensions;
using FutureBinanceAPI.Tools.HttpBuilder;
using Newtonsoft.Json.Linq;
using Orders = FutureBinanceAPI.Models.Orders;

namespace FutureBinanceAPI.Endpoints
{
    public class OrderEndPoint
    {
        #region Var
        public const string APIEndPoint = "/fapi/v1";

        private AuthClient Client { get; set; }

        private IHttpBuilder HttpBuilder { get; set; }
        #endregion

        #region Init
        public OrderEndPoint(AuthClient client)
        {
            Client = client;
            HttpBuilder = new AuthBuilder(Client);
        }
        #endregion

        #region Methods
        public async Task<Order> SetAsync(Orders.IOrder order)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, $"{APIEndPoint}/order",
                order.ToKeyValuePair());
            return await Client.SendRequestAsync<Order>(message);
        }

        public async Task<Order> GetAsync(TradingPair tradingPair, long orderId)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Get, $"{APIEndPoint}/order", new[] {
                new KeyValuePair<string,string>("symbol", $"{tradingPair}"),
                new KeyValuePair<string,string>("orderId", $"{orderId}")
            });

            return await Client.SendRequestAsync<Order>(message);
        }

        public async Task<Order> CancelAsync(TradingPair tradingPair, long orderId)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Delete, $"{APIEndPoint}/order", new[] {
                new KeyValuePair<string,string>("symbol", $"{tradingPair}"),
                new KeyValuePair<string,string>("orderId", $"{orderId}")
            });

            return await Client.SendRequestAsync<Order>(message);
        }

        public async Task<bool> CancelAsync(TradingPair tradingPair)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Delete, $"{APIEndPoint}/allOpenOrders", new[] {
                new KeyValuePair<string,string>("symbol", $"{tradingPair}")
            });

            return JObject.Parse(await Client.SendRequestAsync<string>(message)).Value<int>("Code") == 200;
        }
        #endregion
    }
}
