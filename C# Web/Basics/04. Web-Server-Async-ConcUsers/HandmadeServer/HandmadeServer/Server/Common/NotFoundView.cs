using HandmadeServer.Server.Contracts;

namespace HandmadeServer.Server.Common
{
    public class NotFoundView : IView
    {
        public string View()
        {
            return "<h1>404 This page does not exist :/</h1>";
        }
    }
}
