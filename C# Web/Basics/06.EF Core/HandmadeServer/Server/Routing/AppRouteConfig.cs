using System;
using System.Collections.Generic;
using System.Linq;
using HandmadeServer.Server.Enums;
using HandmadeServer.Server.Handlers;
using HandmadeServer.Server.Http.Contracts;
using HandmadeServer.Server.Routing.Contracts;

namespace HandmadeServer.Server.Routing
{
    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> routes;
       
        public AppRouteConfig()
        {
            this.AnonymousPaths = new List<string>();

            this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>>();
            
            var availableMethods = Enum
                .GetValues(typeof(HttpRequestMethod))
                .Cast<HttpRequestMethod>();

            foreach (var method in availableMethods)
            {
                this.routes[method] = new Dictionary<string, RequestHandler>();
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes => this.routes;

        public ICollection<string> AnonymousPaths { get; private set; }

        public void Get(string route, Func<IHttpRequest, IHttpResponse> handler)
        {
            this.AddRoute(route, HttpRequestMethod.Get, new RequestHandler(handler));
        }

        public void Post(string route, Func<IHttpRequest, IHttpResponse> handler)
        {
            this.AddRoute(route, HttpRequestMethod.Post, new RequestHandler(handler));
        }

        public void AddRoute(string route, HttpRequestMethod method, RequestHandler handler)
        {
            this.routes[method].Add(route, handler);
        }
    }
}
