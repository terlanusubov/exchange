using Exchange.Application.Interfaces;
using Exchange.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Exchange.API.Controllers
{
    [ApiController]
    [Route("api/exchanges")]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService) => _exchangeService = exchangeService;


        [HttpPost]
        public async Task<IActionResult> ChangeCurrency([FromBody] PerformCurrencyConversionRequest request)
        {
            var serviceResult = await _exchangeService.PerformCurrencyConversionAsync(request);

            if (serviceResult.StatusCode != (int)HttpStatusCode.OK)
                return BadRequest(serviceResult);

            return Ok(serviceResult);
        }
    }
}
