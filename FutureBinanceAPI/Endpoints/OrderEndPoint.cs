using FutureBinanceAPI.API;
using FutureBinanceAPI.Models;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Tools.HttpBuilder;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Orders = FutureBinanceAPI.Models.Orders;

namespace FutureBinanceAPI.Endpoints
{
    public class OrderEndPoint : IEndpoint
    {
        public string APIEndPoint { get; } = "/fapi/v1";
        private AuthClient Client { get; set; }
        private IHttpBuilder HttpBuilder { get; set; }
        public OrderEndPoint(AuthClient client)
        {
            Client = client;
            HttpBuilder = new AuthBuilder(Client);
        }

        public async Task<Order> SetAsync(Orders.IOrder order)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Post, $"{APIEndPoint}/order",
                order.ToKeyValuePair());
            return await Client.SendRequestAsync<Order>(message);
        }

        public async Task<Order> GetAsync(Symbols symbol, long orderId)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Get, $"{APIEndPoint}/order", new[] {
                new KeyValuePair<string,string>("symbol", symbol.ToString()),
                new KeyValuePair<string,string>("orderId", orderId.ToString()),
            });

            return await Client.SendRequestAsync<Order>(message);
        }

        public async Task<Order> CancelAsync(Symbols symbol, long orderId)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Delete, $"{APIEndPoint}/order", new[] {
                new KeyValuePair<string,string>("symbol", symbol.ToString()),
                new KeyValuePair<string,string>("orderId", orderId.ToString()),
            });

            return await Client.SendRequestAsync<Order>(message);
        }

        public async Task<bool> CancelAsync(Symbols symbol)
        {
            HttpRequestMessage message = HttpBuilder.MakeRequest(HttpMethod.Delete, $"{APIEndPoint}/allOpenOrders", new[] {
                new KeyValuePair<string,string>("symbol", symbol.ToString())
            });

            ResponseStatus response = await Client.SendRequestAsync<ResponseStatus>(message);
            return response.Code == 200;
        }
    }
}
