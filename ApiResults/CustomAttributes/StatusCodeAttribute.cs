using System.Net;

namespace ApiResults.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class StatusCodeAttribute : Attribute
    {
        public HttpStatusCode Code { get; private set; }

        public StatusCodeAttribute(HttpStatusCode code) => Code = code;
    }
}