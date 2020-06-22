using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using FutureBinanceAPI.Exceptions;

namespace FutureBinanceAPI.API
{
    public class Client
    {
        public bool DebugMode { get; private set; }
        private static readonly HttpClient HttpClient = new HttpClient(new HttpClientHandler() { UseProxy = false });
        public Client(bool debug)
        {
            DebugMode = debug;
        }

        public async Task<T> SendRequestAsync<T>(HttpRequestMessage message)
        {
            HttpResponseMessage response = await HttpClient.SendAsync(message);
            string receivedString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(receivedString);
            else throw new APIException(receivedString);
        }

        public async Task<string> SendRequestAsync(HttpRequestMessage message)
        {
            HttpResponseMessage response = await HttpClient.SendAsync(message);
            string receivedString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return receivedString;
            else throw new APIException(receivedString);
        }
    }
}
