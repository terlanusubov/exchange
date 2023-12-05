using Exchange.Application.Interfaces;

namespace Exchange.MS.Helper
{
    public class BaseTest
    {
        protected readonly IExchangeService _exchangeService;
        public BaseTest()
        {


            _exchangeService = ServiceHelper.GetRequiredService<IExchangeService>() ?? throw new ArgumentNullException(nameof(IExchangeService));

        }


    }

}
