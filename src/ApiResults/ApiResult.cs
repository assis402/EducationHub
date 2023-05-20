using ApiResults.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ApiResults
{
    public class ApiResult
    {
        public ApiResult(bool success, string message = null, dynamic data = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = (int)statusCode;
        }

        public ApiResult(bool success, Enum message = null, dynamic data = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = success;
            Message = message.Description();
            Data = data;
            StatusCode = (int)statusCode;
        }

        public ApiResult(bool success, List<Enum> data, Enum message, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = success;
            Message = message.Description();
            Data = data.Select(e => e.Description());
            StatusCode = (int)statusCode;
        }

        public bool Success { get; set; }

        public int StatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Data { get; set; }

        public ObjectResult Convert()
            => new(this) { StatusCode = StatusCode };
    }
}