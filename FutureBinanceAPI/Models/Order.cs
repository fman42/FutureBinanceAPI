using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models
{
    public class Order
    {
        public string ClientOrderId { get; set; }

        public long OrderId { get; set; }

        public decimal OrigQty { get; set; }

        public decimal Price { get; set; }

        public decimal StopPrice { get; set; }

        public Side Side { get; set; }

        public TraidingPair Symbol { get; set; }

        public OrderType Type { get; set; }
    }
}
