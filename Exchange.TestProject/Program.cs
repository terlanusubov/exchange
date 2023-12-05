using Exchange.TestProject;
using Refit;
using System.Net;


var api = RestService.For<IExchangeClient>("https://localhost:4455");
var result = await api.ConvertCurrency(new Exchange.Application.Models.Requests.PerformCurrencyConversionRequest
{
    Amount = 100,
    From = "USD",
    To = "GBP"
});

if (result.StatusCode != (int)HttpStatusCode.OK)
    Console.WriteLine(result.Description);
else
    Console.WriteLine(result.Response);