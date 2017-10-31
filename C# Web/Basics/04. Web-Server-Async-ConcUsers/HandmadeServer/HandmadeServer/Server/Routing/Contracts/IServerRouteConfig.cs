using System.Collections.Generic;
using HandmadeServer.Server.Enums;

namespace HandmadeServer.Server.Routing.Contracts
{
    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes { get; }
    }
}
