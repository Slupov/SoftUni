using HandmadeServer.Server.Enums;

namespace HandmadeServer.Server.Http.Contracts
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }
    }
}
