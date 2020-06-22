using System.Threading.Tasks;
using System.Net.Http;

namespace FutureBinanceAPI.API
{
    interface IClient
    {
        public Task<T> SendRequestAsync<T>(HttpRequestMessage message);
        public Task<string> SendRequestAsync(HttpRequestMessage message);
    }
}
