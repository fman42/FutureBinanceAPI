using NUnit.Framework;
using FutureBinanceAPI.API;
using FutureBinanceAPI.Endpoints;
using System.Threading.Tasks;

namespace FutureBinanceAPITest
{
    public class MarketMethodsTest
    {
        private MarketEndPoint Endpoint { get; set; }

        [SetUp]
        public void Setup()
        {
            Endpoint = new MarketEndPoint(new DefaultClient(false));
        }

        [Test]
        public async Task GetMarkPrices()
        {
            var markPrices = await Endpoint.GetMarkPriceAsync();
            if (markPrices.Length == 0 || markPrices.Length < 30)
                Assert.Fail("Failed parsing of mark prices");

            Assert.Pass();
        }
    }
}