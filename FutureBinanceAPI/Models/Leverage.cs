using FutureBinanceAPI.Models.Enums;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Models
{
    public class Leverage
    {
        public decimal MaxNotionalValue { get; set; }
        [JsonProperty("leverage")]
        public decimal LeverageValue { get; set; }
        public Symbols Symbol { get; set; }
    }
}
