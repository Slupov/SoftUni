using HandmadeServer.Server.Routing.Contracts;

namespace HandmadeServer.Server.Contracts
{
    public interface IApplication
    {
        void Configure(IAppRouteConfig appRouteConfig);
    }
}
