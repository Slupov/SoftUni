using HandmadeServer.Server.Http.Contracts;

namespace HandmadeServer.ByTheCakeApplication.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index() => this.FileViewResponse(@"home\index");

        public IHttpResponse About() => this.FileViewResponse(@"home\about");
    }
}
