using System;
using HandmadeServer.Application.Views.Home;
using HandmadeServer.Server.Enums;
using HandmadeServer.Server.Http;
using HandmadeServer.Server.Http.Contracts;
using HandmadeServer.Server.Http.Response;

namespace HandmadeServer.Application.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.Ok, new IndexView());

            response.Cookies.Add(new HttpCookie("lang", "en"));

            return response;
        }
        
        public IHttpResponse SessionTest(IHttpRequest req)
        {
            var session = req.Session;

            const string sessionDateKey = "saved_date";

            if (session.Get(sessionDateKey) == null)
            {
                session.Add(sessionDateKey, DateTime.UtcNow);
            }

            return new ViewResponse(
                HttpStatusCode.Ok, 
                new SessionTestView(session.Get<DateTime>(sessionDateKey)));
        }
    }
}
