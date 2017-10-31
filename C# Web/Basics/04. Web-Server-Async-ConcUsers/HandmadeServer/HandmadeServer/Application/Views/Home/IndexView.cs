using HandmadeServer.Server.Contracts;

namespace HandmadeServer.Application.Views.Home
{
    public class IndexView : IView
    {
        public string View() => "<h1>Welcome!</h1>";
    } 
}
