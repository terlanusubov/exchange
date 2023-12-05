using Exchange.Application.Core;
using Exchange.Application.Models.Requests;
using Exchange.Application.Models.Responses;
using Refit;

namespace Exchange.TestProject
{
    internal interface IExchangeClient
    {
        [Post("/api/exchanges")]
        Task<ServiceResult<PerformCurrencyConversionResponse>> ConvertCurrency(PerformCurrencyConversionRequest request);
    }
}
