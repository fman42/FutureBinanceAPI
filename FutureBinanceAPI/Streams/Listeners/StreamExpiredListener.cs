using System;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Streams.Interfaces;
using EventModel = FutureBinanceAPI.Models.Events;

namespace FutureBinanceAPI.Streams.Listeners
{
    public class StreamExpired : BaseListener<EventModel.StreamExpired>, IListener
    {
        #region Var
        public EventTypes Type => EventTypes.listenKeyExpired;
        #endregion

        #region Init
        public StreamExpired(Action<EventModel.StreamExpired> callback) : base(callback) { }
        #endregion
    }
}
