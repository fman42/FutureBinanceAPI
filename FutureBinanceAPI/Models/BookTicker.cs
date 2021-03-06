﻿using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPI.Models
{
    public class BookTicker
    {
        public TradingPair Symbol { get; set; }

        public decimal BidPrice { get; set; }

        public decimal AskPrice { get; set; }
    }
}
