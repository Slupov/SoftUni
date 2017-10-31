using Judge.Services.Contracts;
using SimpleMvc.Framework.Contracts;

namespace Judge.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService users;

        public HomeController(IUserService users)
        {
            this.users = users;
        }

        //rerouting
        public IActionResult Index()
        {
            if (!this.User.IsAuthenticated)
                return this.IndexGuest();

            this.ViewModel["username"] = this.users.GetUser(this.User.Name).FullName;
            this.ViewModel["anonymousDisplay"] = "none";
            this.ViewModel["userDisplay"] = "flex";
            return this.IndexUser();
        }

        public IActionResult IndexUser()
        {
            if (!this.User.IsAuthenticated)
                return RedirectToHome();

            this.ViewModel["username"] = this.users.GetUser(this.User.Name).FullName;
            this.ViewModel["anonymousDisplay"] = "none";
            this.ViewModel["userDisplay"] = "flex";
            return View();
        }

        public IActionResult IndexGuest()
        {
            this.ViewModel["anonymousDisplay"] = "flex";
            this.ViewModel["userDisplay"] = "none";
            return View();
        }
    }
}