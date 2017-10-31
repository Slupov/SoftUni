using HandmadeServer.ByTheCakeApplication.Infrastructure;
using HandmadeServer.Server.Http.Contracts;

namespace HandmadeServer.ByTheCakeApplication.Controllers
{
    public class HomeController : Controller
    {
        public IHttpResponse Index() => this.FileViewResponse(@"home\index");

        public IHttpResponse About() => this.FileViewResponse(@"home\about");
    }
}
