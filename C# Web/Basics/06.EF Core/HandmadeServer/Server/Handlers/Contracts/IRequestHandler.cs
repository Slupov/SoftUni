using HandmadeServer.Server.Http.Contracts;

namespace HandmadeServer.Server.Handlers.Contracts
{
    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext context);
    }
}
