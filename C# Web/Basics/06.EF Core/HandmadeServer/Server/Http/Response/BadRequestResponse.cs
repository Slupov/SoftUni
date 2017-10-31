using HandmadeServer.Server.Enums;

namespace HandmadeServer.Server.Http.Response
{
    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse()
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
