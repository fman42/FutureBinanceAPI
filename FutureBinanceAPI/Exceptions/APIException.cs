using System;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Exceptions
{
    public class APIException : Exception
    {
        public DetailException Details { get; }

        public APIException(string message) : base(message)
        {
            Details = JsonConvert.DeserializeObject<DetailException>(message);
        }
    }
}
