using System;
using FutureBinanceAPI.Models.Events;
using Newtonsoft.Json;

namespace FutureBinanceAPI.Streams.Listeners
{
    public class BaseListener<T> where T: IEventModel
    {
        #region Var
        private Action<T> UserCallback { get; }
        #endregion

        #region Init
        public BaseListener(Action<T> callback)
        {
            UserCallback = callback;
        }
        #endregion

        #region General methods
        public void Update(string message) =>
            UserCallback(JsonConvert.DeserializeObject<T>(message));

        #endregion
    }
}
