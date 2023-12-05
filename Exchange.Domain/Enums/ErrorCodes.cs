using System.ComponentModel;

namespace Exchange.Domain.Enums
{
    public enum ErrorCodes
    {
        [Description("Provided API_ID is invalid")]
        API_ID_INVALID = 1_0_0,
        [Description("Bad Request")]
        BAD_REQUEST = 4_0_0,

        [Description("Unhandled exception")]
        UNHANDLED_EXCEPTION = 5_0_0
    }
}
