using HandmadeServer.Server.Http.Contracts;

namespace HandmadeServer.GameStoreApplication.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHttpRequest request)
            : base(request)
        {
        }

        public IHttpResponse Index()
        {
            return this.FileViewResponse(@"home\index");
        }
    }
}
