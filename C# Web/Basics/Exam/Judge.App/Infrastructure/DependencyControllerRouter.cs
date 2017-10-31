using System;
using System.Net.Mime;
using Judge.Data;
using Judge.Services;
using Judge.Services.Contracts;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Routers;

namespace Judge.App.Infrastructure
{
    public class DependencyControllerRouter : ControllerRouter
    {
        private readonly Container container;

        public DependencyControllerRouter()
        {
            this.container = new Container();
            this.container.Options.DefaultScopedLifestyle
                = new AsyncScopedLifestyle();
        }

        public Container Container => this.container;

        public static DependencyControllerRouter Get()
        {
            var router = new DependencyControllerRouter();

            var container = router.Container;

            container.Register<IUserService, UserService>();
            container.Register<IContestService, ContestService>();
            container.Register<ISubmissionService, SubmissionService>();
            container.Register<JudgeDbContext>(Lifestyle.Scoped);

            container.Verify();

            return router;
        }

        protected override Controller CreateController(Type controllerType)
        {
            AsyncScopedLifestyle.BeginScope(this.Container);
            return (Controller) this.Container.GetInstance(controllerType);
        }
    }
}