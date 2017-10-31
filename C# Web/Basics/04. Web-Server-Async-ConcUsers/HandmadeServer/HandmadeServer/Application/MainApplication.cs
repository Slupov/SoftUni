using HandmadeServer.Application.Controllers;
using HandmadeServer.Server.Contracts;
using HandmadeServer.Server.Routing.Contracts;

namespace HandmadeServer.Application
{
    public class MainApplication : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get(
                "/", 
                req => new HomeController().Index());

            appRouteConfig.Get(
                "/testsession",
                req => new HomeController().SessionTest(req));
            
            appRouteConfig.Get(
                "/users/{(?<name>[a-z]+)}",
                req => new HomeController().Index());
        }
    }
}
