using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Judge.Data;
using Judge.Data.Models;
using Judge.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Judge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private JudgeDbContext db;

        public SubmissionService()
        {
            this.db = new JudgeDbContext();
        }

        public bool Create(string code, int contestId, int userId)
        {
            try
            {
                var submission = new Submission()
                {
                    Code = code,
                    ContestId = contestId,
                    UserId = userId
                };

                this.db.Submissions.Add(submission);
                this.db.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                return false;
            }
        }

        public IEnumerable<TModel> All<TModel>()
        {
            var query = this.db.Submissions.AsQueryable();

            return query
                .ProjectTo<TModel>()
                .ToList();
        }

        public IEnumerable<TModel> All<TModel>(int userId)
        {
            var query = this.db.Submissions.AsQueryable();

            return query
                .Where(s => s.UserId == userId)
                .ProjectTo<TModel>()
                .ToList();
        }
    }
}