using System.Net.Http;
using System.Threading.Tasks;
using FutureBinanceAPI.Exceptions;
using Newtonsoft.Json;

namespace FutureBinanceAPI.API
{
    public class Client
    {
        #region Var
        public bool DebugMode { get; private set; }

        private static readonly HttpClient HttpClient = new HttpClient(new HttpClientHandler() {
            UseProxy = false
        });
        #endregion

        #region Init
        public Client(bool debug) => DebugMode = debug;
        #endregion

        #region Methods
        public async Task<T> SendRequestAsync<T>(HttpRequestMessage message) where T : class
        {
            HttpResponseMessage response = await HttpClient.SendAsync(message);
            string receivedString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return typeof(T) == typeof(string) ? (T)(object)receivedString : JsonConvert.DeserializeObject<T>(receivedString);
            else throw new APIException(receivedString);
        }

        public async Task SendRequestAsync(HttpRequestMessage message) => await HttpClient.SendAsync(message);
        #endregion
    }
}
