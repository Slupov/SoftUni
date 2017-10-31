using System.Linq;
using Judge.Data;
using Judge.Data.Models;
using Judge.Services.Contracts;

namespace Judge.Services
{
    public class UserService : IUserService
    {
        private readonly JudgeDbContext db;

        public UserService()
        {
            this.db = new JudgeDbContext();
        }

        public bool Create(string email, string password, string name)
        {
            if (this.db.Users.Any(u => u.Email == email))
            {
                return false;
            }

            var isAdmin = !this.db.Users.Any();

            var user = new User
            {
                Email = email,
                FullName = name,
                Password = password,
                IsAdmin = isAdmin
            };

            this.db.Add(user);
            this.db.SaveChanges();

            return true;
        }

        public bool UserExists(string email, string password)
            => this.db
                .Users
                .Any(u => u.Email == email && u.Password == password);

        public int GetId(string email)
        {
            return this.db.Users
                .FirstOrDefault(u => u.Email == email).Id;
        }

        public User GetUser(string email)
        {
            return this.db.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}