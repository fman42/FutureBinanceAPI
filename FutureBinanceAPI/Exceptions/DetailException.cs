using Newtonsoft.Json;

namespace FutureBinanceAPI.Exceptions
{
    public class DetailException
    {
        public int Code { get; set; }

        [JsonProperty("Msg")]
        public string Message { get; set; }
    }
}
