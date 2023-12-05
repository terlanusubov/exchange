using Exchange.Application.Core;
using Exchange.Application.Interfaces;
using Exchange.Application.Models.Requests;
using Exchange.Application.Models.Responses;
using Exchange.Domain.Aggregates.OperationAggregate;
using Exchange.Domain.Repositories;
using Exchange.Infrastructure.Externals.Currency;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Exchange.Infrastructure.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public ExchangeService(IOperationRepository operationRepository,
                                IUnitOfWork unitOfWork,
                                IConfiguration configuration)
        {
            _operationRepository = operationRepository;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }


        public async Task<ServiceResult<PerformCurrencyConversionResponse>> PerformCurrencyConversionAsync(PerformCurrencyConversionRequest request)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration["Currency:BaseUrl"]);

                    var response = await client.GetAsync(_configuration["Currency:Convert"]);
                    if (!response.IsSuccessStatusCode)
                        return ServiceResult<PerformCurrencyConversionResponse>.Error(Domain.Enums.ErrorCodes.BAD_REQUEST);

                    var result = await response.Content.ReadFromJsonAsync<Root>();


                    var operation = new Operation(request.Amount, request.From, request.To, (decimal)result.response);

                    await _operationRepository.AddAsync(operation);

                    await _unitOfWork.SaveChangesAsync();

                    await _unitOfWork.CommitAsync();

                    return ServiceResult<PerformCurrencyConversionResponse>.OK(new PerformCurrencyConversionResponse
                    {
                        ConvertedAmount = (decimal)result.response,
                        From = request.From,
                        To = request.To
                    });
                }

            }
            catch (Exception ex)
            {
                //TODO: we can notify exception to SENTRY, SLACK or DB etc.
                await _unitOfWork.RollbackAsync();
                return ServiceResult<PerformCurrencyConversionResponse>.Error(Domain.Enums.ErrorCodes.UNHANDLED_EXCEPTION);
            }
        }


    }

}
