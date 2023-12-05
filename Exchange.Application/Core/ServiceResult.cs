using Exchange.Domain.Enums;
using Exchange.Domain.Extensions;
using System.Net;

namespace Exchange.Application.Core
{

    public class ServiceResult<TOutput>
    {
        public TOutput Response { get; set; }
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }
        public string Description { get; set; }




        public static ServiceResult<TOutput> OK(TOutput response)
        {
            return new ServiceResult<TOutput>()
            {
                Response = response,
                StatusCode = (int)HttpStatusCode.OK,
                Description = "The operation has finished successfully.",
            };
        }



        public static ServiceResult<TOutput> Error(ErrorCodes errorCode, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new ServiceResult<TOutput>()
            {
                Response = default,
                StatusCode = statusCode,
                ErrorCode = (int)errorCode,
                Description = errorCode.GetEnumDescription()
            };
        }
    }
}
