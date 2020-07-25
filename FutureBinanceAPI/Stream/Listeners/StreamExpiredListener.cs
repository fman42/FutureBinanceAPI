using System;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Stream.Interfaces;
using EventModel = FutureBinanceAPI.Models.Events;

namespace FutureBinanceAPI.Stream.Listeners
{
    public class StreamExpiredListener : BaseListener<EventModel.StreamExpired>, IListener
    {
        #region Var
        public EventType Type => EventType.listenKeyExpired;
        #endregion

        #region Init
        public StreamExpiredListener(Action<EventModel.StreamExpired> callback) : base(callback) { }
        #endregion
    }
}
