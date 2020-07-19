using System;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Stream.Interfaces;
using EventModel = FutureBinanceAPI.Models.Events;

namespace FutureBinanceAPI.Stream.Listeners
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
