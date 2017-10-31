﻿using HandmadeServer.Server.Contracts;

namespace HandmadeServer.ByTheCakeApplication.Views
{
    public class FileView : IView
    {
        private readonly string htmlFile;

        public FileView(string htmlFile)
        {
            this.htmlFile = htmlFile;
        }

        public string View() => this.htmlFile;
    }
}