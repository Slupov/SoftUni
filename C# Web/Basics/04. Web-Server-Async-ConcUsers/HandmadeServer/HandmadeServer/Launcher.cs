using HandmadeServer.ByTheCakeApplication;
using HandmadeServer.Server;
using HandmadeServer.Server.Contracts;
using HandmadeServer.Server.Routing;

namespace HandmadeServer
{
    public class Launcher : IRunnable
    {
        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            var mainApplication = new ByTheCakeApp();
            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}
