﻿using System.Collections.Generic;

namespace FutureBinanceAPI.Models
{
    public class Account
    {
        public List<Accounts.Asset> Assets { get; set; }

        public List<Accounts.Position> Positions { get; set; }
    }
}
