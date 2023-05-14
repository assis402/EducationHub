namespace Presentation.Utils
{
    public static class Result
    {
        public static ApiResult Success(string responseMessage)
            => new (success: true, message: responseMessage);
            
        public static ApiResult Success(dynamic responseData)
            => new (success: true, data: responseData);

        public static ApiResult Success(string responseMessage, dynamic responseData)
            => new (success: true, responseMessage, responseData);

        public static ApiResult ErrorMessage(string responseMessage)
            => new(success: true, message: responseMessage);

        public static ApiResult ErrorMessage(string responseMessage, IReadOnlyCollection<string> errors)
            => new(success: true, message: responseMessage, data: errors);
    }
}