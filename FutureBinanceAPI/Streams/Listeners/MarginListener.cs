using System;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models.Events;
using FutureBinanceAPI.Streams.Interfaces;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Streams.Listeners
{
    public class MarginListener : IListener
    {
        #region Var
        public EventTypes Type { get; } = EventTypes.MARGIN_CALL;
        public Action<StreamMarginCall> UserCallback { get; }
        #endregion

        #region Init
        public MarginListener(Action<StreamMarginCall> callback)
        {
            UserCallback = callback;
        }
        #endregion

        #region Methods
        public void Update(string message)
        {
            StreamMarginCall marginObject = JsonConvert.DeserializeObject<StreamMarginCall>(message);
            UserCallback(marginObject);
        }
        #endregion
    }
}
