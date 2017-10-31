using System;
using HandmadeServer.Server.Common;
using HandmadeServer.Server.Enums;

namespace HandmadeServer.Server.Http.Response
{
    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex))
        {
        }
    }
}
