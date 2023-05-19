using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiResults
{
    public static class Result
    {
        public static ApiResult Success(string responseMessage, dynamic responseData = null, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new (success: true, message: responseMessage, data: responseData);

        public static ApiResult Success(Enum responseMessage, dynamic responseData = null, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new (success: true, message: responseMessage, data: responseData);

        public static ApiResult Success(dynamic responseData, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new (success: true, data: responseData, statusCode: statusCode);

        public static ApiResult Error(string responseMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new (success: true, message: responseMessage, statusCode: statusCode);

        public static ApiResult Error(string responseMessage, IEnumerable<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new (success: true, message: responseMessage, data: errors, statusCode: statusCode);

        public static ApiResult Error(string responseMessage, IEnumerable<ValidationFailure> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(success: true, message: responseMessage, data: errors.CastToString(), statusCode: statusCode);

        public static ApiResult Error(Enum responseMessage, IEnumerable<ValidationFailure> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(success: true, message: responseMessage, data: errors.CastToString(), statusCode: statusCode);

        public static ApiResult Error(Enum responseMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(success: true, message: responseMessage, statusCode: statusCode);
    }
}