using System.Collections.Generic;
using HandmadeServer.Server.Handlers;

namespace HandmadeServer.Server.Routing.Contracts
{
    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler Handler { get; }
    }
}
