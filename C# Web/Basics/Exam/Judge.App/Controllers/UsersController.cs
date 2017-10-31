namespace Judge.App.Controllers
{
    using Judge.App.Models.Users;
    using Judge.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class UsersController : BaseController
    {
        private const string RegisterError =
                "<p>Check your form for errors.</p><p> E-mails must have at least one '@' and one '.' symbols.</p><p>Passwords must be at least 6 symbols and must contain at least 1 uppercase, 1 lowercase letter and 1 digit.</p><p>Confirm password must match the provided password.</p>"
            ;

        private const string EmailExistsError = "E-mail is already taken.";
        private const string LoginError = "<p>Invalid credentials.</p>";
        private const string PasswordsDontMatch = "<p>Passwords dont match.</p>";

        private readonly IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ShowError(PasswordsDontMatch);
                return View();
            }
            if (!IsValidModel(model))
            {
                ShowError(RegisterError);
                return View();
            }

            var result = this.users.Create(
                model.Email,
                model.Password,
                model.Name);

            if (result)
            {
                return RedirectToLogin();
            }
            else
            {
                ShowError(EmailExistsError);
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!IsValidModel(model))
            {
                ShowError(LoginError);
                return View();
            }

            if (this.users.UserExists(model.Email, model.Password))
            {
                SignIn(model.Email);
                return RedirectToHome();
            }
            else
            {
                ShowError(LoginError);
                return View();
            }
        }

        public IActionResult Logout()
        {
            SignOut();
            return RedirectToHome();
        }
    }
}