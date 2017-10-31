using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Judge.Data;
using Judge.Services.Contracts;

namespace Judge.Services
{
    public class ContestService : IContestService
    {
        private JudgeDbContext db;

        public ContestService()
        {
            this.db = new JudgeDbContext();
        }

        public bool Create(string name, int userId)
        {
            return true;
        }

        public IEnumerable<TModel> All<TModel>()
        {
            var query = this.db.Contests.AsQueryable();

            return query
                .ProjectTo<TModel>()
                .ToList();
        }
    }
}