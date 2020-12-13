using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Stream.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FutureBinanceAPI.Stream
{
    public class ExchangeEvent : IEvent
    {
        #region  Var
        private List<IListener> Listeners { get; }
        #endregion

        #region Init
        public ExchangeEvent() => Listeners = new List<IListener>();
        #endregion

        #region Methods
        public void Add(IListener listener) => Listeners.Add(listener);

        public bool Remove(IListener listener)
        {
            if (Listeners.Contains(listener))
            {
                Listeners.Remove(listener);
                return true;
            }

            return false;
        }

        public void Alert(string message)
        {
            if (Enum.TryParse(JObject.Parse(message)["e"].ToObject<string>(), true, out EventType type))
            {
                foreach(IListener listener in Listeners.Where(x => x.Type == type))
                    listener.Update(message);
            }

        }
        #endregion
    }
}