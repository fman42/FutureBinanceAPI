using NUnit.Framework;
using FutureBinanceAPI.API;
using FutureBinanceAPI.Endpoints;
using System.Threading.Tasks;
using FutureBinanceAPI.Models.Enums;

namespace FutureBinanceAPITest
{
    public class AccountMethodsTestlf
    {
        private AccountEndPoint Endpoint { get; set; }

        [SetUp]
        public void Setup()
        {
            AuthClient client = new AuthClient("", "", true)
            {
                RecvWindow = 60000
            };
            Endpoint = new AccountEndPoint(client);
        }

        [Test]
        public async Task GetPositionRiskAsync()
        {
            var positions = await Endpoint.GetPositionRiskAsync();
            if (positions.Length == 0)
                Assert.Fail("Positions doesn't have elements");

            Assert.Pass();
        }

        [Test]
        public async Task GetAccountAsync()
        {
            var account = await Endpoint.GetAsync();
            if (account.Assets.Length == 0 || account.Positions.Length == 0)
                Assert.Fail("Assets or positions doesn't have elements");

            Assert.Pass();
        }

        [Test]
        public async Task GetSpecificPositionRiskAsync()
        {
            await Endpoint.GetPositionRiskAsync(TradingPair.BTCUSDT);
            Assert.Pass();   
        }
    }
}
