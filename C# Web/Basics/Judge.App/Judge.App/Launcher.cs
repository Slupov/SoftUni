using Judge.App.Infrastructure;
using Judge.App.Infrastructure.Mapping;
using Judge.Data;
using Microsoft.EntityFrameworkCore;
using SimpleMvc.Framework;
using SimpleMvc.Framework.Routers;

namespace Judge.App
{
    internal class Launcher
    {
        private static void Main()
        {
            using (var db = new JudgeDbContext())
            {
                db.Database.Migrate();
            }

            AutoMapperConfiguration.Initialize();

            MvcEngine.Run(
                new WebServer.WebServer(1337,
                    DependencyControllerRouter.Get(),
                    new ResourceRouter()));
        }
    }
}