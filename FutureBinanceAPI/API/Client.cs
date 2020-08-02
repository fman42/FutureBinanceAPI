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
        #endregion
    }
}
