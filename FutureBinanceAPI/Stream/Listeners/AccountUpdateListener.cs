using System;
using FutureBinanceAPI.Models.Enums;
using FutureBinanceAPI.Models.Events;
using FutureBinanceAPI.Stream.Interfaces;

namespace FutureBinanceAPI.Stream.Listeners
{
    public class AccountUpdateListener : BaseListener<AccountUpdateCall>, IListener
    {
        #region Var
        public EventTypes Type => EventTypes.ACCOUNT_UPDATE;
        #endregion

        #region Init
        public AccountUpdateListener(Action<AccountUpdateCall> callback) : base(callback) { }
        #endregion
    }
}
