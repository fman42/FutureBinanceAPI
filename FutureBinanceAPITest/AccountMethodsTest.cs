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
            AuthClient client = new AuthClient("2d5c604081109f4351da2500ec9cce0981664084a07e3e61bc7b5138b9a9086a", "a6e00519557fa36a0e14f90913286f925f12165a7a607eb757f446889d2e0adc", true)
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