using HandmadeServer.Infrastructure;

namespace HandmadeServer.ByTheCakeApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override string ApplicationDirectory => "ByTheCakeApplication";
    }
}
