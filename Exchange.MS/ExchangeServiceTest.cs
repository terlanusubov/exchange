using Exchange.MS.Helper;
using System.Net;

namespace Exchange.MS
{
    [TestClass]
    public class ExchangeServiceTest : BaseTest
    {
        [TestMethod]
        public async Task PerformCurrencyConversionAsync_ShouldReturnValidResult()
        {
            var request = new Application.Models.Requests.PerformCurrencyConversionRequest()
            {
                Amount = 100,
                From = "USD",
                To = "GBP"
            };



            var response = await _exchangeService.PerformCurrencyConversionAsync(request);

            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
        }
    }
}