using HandmadeServer.Server.Common;
using HandmadeServer.Server.Http.Contracts;

namespace HandmadeServer.Server.Http
{
    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(IHttpRequest request)
        {
            CoreValidator.ThrowIfNull(request, nameof(request));

            this.request = request;
        }

        public IHttpRequest Request => this.request;
    }
}
