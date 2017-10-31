using System;
using HandmadeServer.Server.Contracts;

namespace HandmadeServer.Application.Views.Home
{
    public class SessionTestView : IView
    {
        private readonly DateTime dateTime;

        public SessionTestView(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public string View()
        {
            return $"<h1>Saved date: {this.dateTime}</h1>";
        }
    }
}
