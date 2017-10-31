using System.Collections.Generic;

namespace Judge.Services.Contracts
{
    public interface IContestService
    {
        bool Create(string name, int userId);

        IEnumerable<TModel> All<TModel>();
    }
}
