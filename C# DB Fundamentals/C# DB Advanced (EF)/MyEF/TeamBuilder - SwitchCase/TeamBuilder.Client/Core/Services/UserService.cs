using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.Client.Core.Services
{
    public class UserService
    {
        public static void Register(string username, string password, string firstName, string lastName, int age,
            Gender gender)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                db.Users.Add(new User()
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender
                });

                db.SaveChanges();
            }
        }

        public static User GetUserByCredentilas(string username, string password)
        {
            using (TeamBuilderContext db = new TeamBuilderContext())
            {
                return db.Users.FirstOrDefault(u => !u.IsDeleted && (u.Username == username && u.Password == password));
            }
        }
    }
}