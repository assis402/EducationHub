namespace Presentation.Utils
{
    public class ApiException : Exception
    {
        private List<string> _errors;
        
        public IReadOnlyList<string> Errors => _errors;

        public ApiException() {}

        public ApiException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }

        public ApiException(string message) : base(message)
        { }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}