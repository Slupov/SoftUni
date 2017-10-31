using HandmadeServer.Server.Common;
using HandmadeServer.Server.Enums;

namespace HandmadeServer.Server.Http.Response
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;

            this.Headers.Add(HttpHeader.Location, redirectUrl);
        }
    }
}
