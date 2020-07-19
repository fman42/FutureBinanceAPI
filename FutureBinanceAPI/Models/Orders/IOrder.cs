using FutureBinanceAPI.Models.Enums;
using System.Collections.Generic;

namespace FutureBinanceAPI.Models.Orders
{
    public interface IOrder
    {
        public Symbols Symbol { get; set; }

        public SideTypes Side { get; set; }

        public Types Type { get; }

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePair();
    }
}
