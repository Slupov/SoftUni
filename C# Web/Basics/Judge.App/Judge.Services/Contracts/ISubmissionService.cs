using System;
using System.Collections.Generic;
using System.Text;

namespace Judge.Services.Contracts
{
    public interface ISubmissionService
    {
        bool Create(string code, int contestId, int userId);

        IEnumerable<TModel> All<TModel>();

        /// <summary>
        /// Gets all submissions by user id
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<TModel> All<TModel>(int userId);
    }
}
