using FutureBinanceAPI.Models.Enums;
using System.Collections.Generic;

namespace FutureBinanceAPI.Models.Events
{
    public class StreamMarginCall : IStreamEvent
    {
        public EventTypes EventType { get; } = EventTypes.listenKeyExpired;
        public long Time { get; set; }
        public decimal? CrossWalletBalance { get; set; }
        public List<Position> Positions { get; set; }
    }
}
