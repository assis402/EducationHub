using Newtonsoft.Json;

namespace Presentation.Utils
{
    public class ApiResult
    {
        public ApiResult(bool success, string message = null, dynamic data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public ApiResult(bool success, Enum message = null, dynamic data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Data { get; set; }
    }
}