using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiResults
{
    public static class Result
    {
        public static ApiResult Success(string responseMessage, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new (success: true, message: responseMessage);

        public static ApiResult Success(Enum responseMessage)
            => new (success: true, message: responseMessage);

        public static ApiResult Success(dynamic responseData)
            => new (success: true, data: responseData);

        public static ApiResult Success(string responseMessage, dynamic responseData)
            => new (success: true, responseMessage, responseData);

        public static ApiResult Error(string responseMessage)
            => new (success: true, message: responseMessage);

        public static ApiResult Error(string responseMessage, IReadOnlyCollection<string> errors)
            => new (success: true, message: responseMessage, data: errors);

        public static ApiResult Error(Enum responseMessage)
            => new(success: true, message: responseMessage);

        public static ApiResult Error(Enum responseMessage, List<Enum> errors)
            => new (success: true, message: responseMessage, data: errors);

        public static ObjectResult Convert(this ApiResult result)
            => new (result) { StatusCode = result.StatusCode };
    }
}