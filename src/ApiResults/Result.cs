using ApiResults.Helpers;
using FluentValidation.Results;
using System.Net;

namespace ApiResults
{
    public static class Result
    {
        public static ApiResult Success(string responseMessage, dynamic responseData = null, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new(success: true, message: responseMessage, data: responseData, statusCode);
        
        public static ApiResult Success(Enum enumMessage, dynamic responseData = null)
            => new(success: true, message: enumMessage.Description(), data: responseData, enumMessage.StatusCode());

        public static ApiResult Success(dynamic responseData, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new(success: true, data: responseData, statusCode: statusCode);

        public static ApiResult Error(string responseMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(success: true, message: responseMessage, statusCode: statusCode);

        public static ApiResult Error(string responseMessage, IEnumerable<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(success: true, message: responseMessage, data: errors, statusCode: statusCode);

        public static ApiResult Error(string responseMessage, IEnumerable<ValidationFailure> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(success: true, message: responseMessage, data: errors.CastToString(), statusCode: statusCode);

        public static ApiResult Error(Enum enumMessage, IEnumerable<ValidationFailure> errors)
            => new(success: true, message: enumMessage.Description(), data: errors.CastToString(), statusCode: enumMessage.StatusCode());

        public static ApiResult Error(Enum enumMessage)
            => new(success: true, message: enumMessage.Description(), statusCode: enumMessage.StatusCode());
    }
}