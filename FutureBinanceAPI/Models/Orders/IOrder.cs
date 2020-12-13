using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models.Orders
{
    public interface IOrder
    {
        public TradingPair Symbol { get; set; }

        public Side Side { get; set; }

        public OrderType Type { get; }
    }
}
