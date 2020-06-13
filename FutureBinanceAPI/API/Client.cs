using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using FutureBinanceAPI.Exceptions;

namespace FutureBinanceAPI.API
{
    public class Client
    {
        public bool DebugMode { get; private set; }
        private HttpClient WebClient { get; set; } = new HttpClient();
        public Client(bool debug)
        {
            DebugMode = debug;
        }

        public async Task<T> SendRequest<T>(HttpRequestMessage message)
        {
            HttpResponseMessage response = await WebClient.SendAsync(message);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            else throw new APIException(await response.Content.ReadAsStringAsync());
        }
    }
}
