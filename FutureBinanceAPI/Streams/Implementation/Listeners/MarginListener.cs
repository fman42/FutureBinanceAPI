using System;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models.Events;
using FutureBinanceAPI.Streams.Interfaces;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Streams.Implementation.Listeners
{
    public class MarginListener : IListener
    {
        public EventTypes Type { get; } = EventTypes.MARGIN_CALL;
        public Action<StreamMarginCall> UserCallback { get; }
        public MarginListener(Action<StreamMarginCall> callback)
        {
            UserCallback = callback;
        }

        public void Update(string message)
        {
            StreamMarginCall marginObject = JsonConvert.DeserializeObject<StreamMarginCall>(message);
            UserCallback(marginObject);
        }
    }
}
