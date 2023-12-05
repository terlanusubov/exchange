using Exchange.Application.Core;
using Exchange.Application.Models.Requests;
using Exchange.Application.Models.Responses;

namespace Exchange.Application.Interfaces
{
    public interface IExchangeService
    {
        public Task<ServiceResult<PerformCurrencyConversionResponse>> PerformCurrencyConversionAsync(PerformCurrencyConversionRequest request);
    }
}
