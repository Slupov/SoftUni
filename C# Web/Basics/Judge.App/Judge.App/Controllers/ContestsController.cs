using System.Text;
using Judge.App.Models.Contests;
using Judge.Services.Contracts;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Contracts;

namespace Judge.App.Controllers
{
    public class ContestsController : BaseController
    {
        private const string ModelInvalidError = @"Cannot add contest {0}";
        private const string ContestExistsErorr = @"Cannot add contest {0} because it already exists";

        private string TableRow =
            $@"<tr>
                <td scope=""row"">{0}</td>
                <td>{1}</td>
                <td>
                <a display=""{2}"" href = ""#"" class=""btn btn-sm btn-warning"">Edit</a>
                <a display=""{2}"" href = ""#"" class=""btn btn-sm btn-danger"">Delete</a>
                </td>
               </tr>";

        private readonly IContestService contests;

        public ContestsController(IContestService contests)
        {
            this.contests = contests;
        }

        public IActionResult List()
        {
            var allContests = this.contests.All<ListContestModel>();

            StringBuilder rows = new StringBuilder();

            foreach (var cont in allContests)
            {
                bool viewButtons = this.IsAdmin || cont.UserEmail == this.User.Name;
                string buttonsDisplay = "none";

                if (viewButtons)
                {
                    buttonsDisplay = "flex";
                }
                rows.Append(string.Format(this.TableRow, cont.Name, cont.Submissions, buttonsDisplay));
            }

            this.ViewModel["rows"] = rows.ToString();
            this.ViewModel["userDisplay"] = "flex";
            return this.View();
        }

        public IActionResult Add()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHome();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddContestModel model)
        {
            if (!IsValidModel(model))
            {
                ShowError(string.Format(ModelInvalidError, model.Name));
                return View();
            }

            var result = this.contests.Create(
                model.Name,
                model.UserId);

            if (result)
            {
                return RedirectToHome();
            }
            else
            {
                ShowError(string.Format(ContestExistsErorr, model.Name));
                return View();
            }
        }
    }
}