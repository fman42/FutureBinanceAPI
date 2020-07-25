using FutureBinanceAPI.Models.Enums;
using System.Collections.Generic;

namespace FutureBinanceAPI.Models.Orders
{
    public interface IOrder
    {
        public TraidingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; }

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePair();
    }
}
