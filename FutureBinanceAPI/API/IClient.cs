using System.Threading.Tasks;
using System.Net.Http;

namespace FutureBinanceAPI.API
{
    interface IClient
    {
        Task<T> SendRequestAsync<T>(HttpRequestMessage message) where T : class;
    }
}
