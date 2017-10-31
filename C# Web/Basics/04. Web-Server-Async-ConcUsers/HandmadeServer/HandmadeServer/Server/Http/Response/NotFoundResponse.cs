using HandmadeServer.Server.Common;
using HandmadeServer.Server.Enums;

namespace HandmadeServer.Server.Http.Response
{
    public class NotFoundResponse : ViewResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound, new NotFoundView())
        {
        }
    }
}
