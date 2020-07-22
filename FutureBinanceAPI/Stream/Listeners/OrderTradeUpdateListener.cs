﻿using System;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models.Events;
using FutureBinanceAPI.Stream.Interfaces;

namespace FutureBinanceAPI.Stream.Listeners
{
    public class OrderTradeUpdateListener : BaseListener<OrderTradeUpdateCall>, IListener
    {
        #region Var
        public EventTypes Type => EventTypes.ORDER_TRADE_UPDATE;
        #endregion

        #region Init
        public OrderTradeUpdateListener(Action<OrderTradeUpdateCall> callback) : base(callback) { }
        #endregion
    }
}