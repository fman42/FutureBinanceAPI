namespace FutureBinanceAPI.Models
{
    public class Account
    {
        public Accounts.Asset[] Assets { get; set; }

        public Accounts.Position[] Positions { get; set; }
    }
}
