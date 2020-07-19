﻿using System;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models.Events;
using FutureBinanceAPI.Streams.Interfaces;

namespace FutureBinanceAPI.Streams.Listeners
{
    public class MarginListener : BaseListener<StreamMarginCall>, IListener
    {
        #region Var
        public EventTypes Type => EventTypes.MARGIN_CALL;
        #endregion

        #region Init
        public MarginListener(Action<StreamMarginCall> callback) : base(callback) { }
        #endregion
    }
}
