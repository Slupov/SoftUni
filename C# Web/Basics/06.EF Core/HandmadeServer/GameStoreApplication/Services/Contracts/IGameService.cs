using System;
using System.Collections.Generic;
using HandmadeServer.GameStoreApplication.ViewModels.Admin;

namespace HandmadeServer.GameStoreApplication.Services.Contracts
{
    public interface IGameService
    {
        void Create(
            string title,
            string description,
            string image,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate);

        IEnumerable<AdminListGameViewModel> All();
    }
}
