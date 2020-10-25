using System.Runtime.Serialization;

namespace Etechnosoft.Common.Data
{
    [DataContract]
    public enum ServiceResponseCode
    {
        [Message("Successful")] Ok = 0,
        [Message("Something went wrong, Please try again.")] BadRequest = 1,
        [Message("Validation Error")] ValidationError,
        [Message("Internal server error. Contact us for assistance.")] InternalServerError = 9999,

    }
}