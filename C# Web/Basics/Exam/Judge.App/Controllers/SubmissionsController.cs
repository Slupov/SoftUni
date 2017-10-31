using System;
using System.Linq;
using System.Text;
using Judge.App.Models.Submissions;
using Judge.Data.Models;
using Judge.Services;
using Judge.Services.Contracts;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Contracts;

namespace Judge.App.Controllers
{
    public class SubmissionsController : BaseController
    {
        private const string SubmissionError = "Submission is not valid";

        /// <summary>
        /// {0} active or string.Empty
        /// </summary>
        private readonly string ContestLink =
            $@"<a class=""list-group-item list-group-item-action list-group-item-dark {
                    0
                }"" data-toggle=""list"" href=""#contest-submissions"" role=""tab"">First Contest</a>";

        /// <summary>
        /// {0} success or danger
        /// </summary>
        private readonly string ContestSubmission =
            $@"<li class=""list-group-item list-group-item-{0}"">Build Success</li>";

        private readonly ISubmissionService submissions;

        public SubmissionsController(ISubmissionService submissions)
        {
            this.submissions = submissions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">contest id</param>
        /// <returns></returns>
        public IActionResult List(int id)
        {
            var submissionsToSee =
                this.submissions.All<ListSubmissionModel>().Where(s => s.UserEmail == this.User.Name);

            IContestService contests = new ContestService();
            var allContests = contests
                .All<Contest>()
                .Select(c => new {Name = c.Name, Id = c.Id})
                .Where(c => c.Id == id); //could use automapper here too

            StringBuilder contestsHtml = new StringBuilder();

            //draw contest html
            foreach (var cont in allContests)
            {
                var state = string.Empty;

                if (id == cont.Id)
                {
                    state = "active";
                }
                contestsHtml.Append(string.Format(this.ContestLink, state));
            }
            this.ViewModel["contests"] = contestsHtml.ToString();


            var currentUserEmail = this.User.Name;

            IUserService users = new UserService();
            var userSubmissions = this.submissions
                .All<Submission>()
                .Count(s => s.ContestId == id
                            && s.UserId == users.GetId(currentUserEmail));

            StringBuilder submissionsHtml = new StringBuilder();

            //draw contest submissions html
            for (int i = 0; i < userSubmissions; i++)
            {
                Random r = new Random();
                var color = r.Next(0, 100) < 70 ? "danger" : "success";
                submissionsHtml.Append(string.Format(this.ContestSubmission, color));
            }

            this.ViewModel["submissions"] = submissionsHtml.ToString();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Submission model) //there's no "validate submission" assignment in the .doc
        {
            if (!IsValidModel(model))
            {
                ShowError(SubmissionError);
                return View();
            }

            var result = this.submissions.Create(
                model.Code,
                model.ContestId,
                model.UserId);

            if (result)
            {
                return Redirect("/submissions/Index.html");
            }
            else
            {
                ShowError(SubmissionError);
                return View();
            }
        }
    }
}