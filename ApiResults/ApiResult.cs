using Microsoft.AspNetCore.Http;
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
            Message = message.GetEnumDescription();
            Data = data;
            StatusCode = (int)statusCode;
        }

        public ApiResult(bool success, List<Enum> data, Enum message, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = success;
            Message = message.GetEnumDescription();
            Data = data.Select(e => e.GetEnumDescription());
            StatusCode = (int)statusCode;
        }

        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Data { get; set; }

        public int StatusCode { get; set; }
    }
}