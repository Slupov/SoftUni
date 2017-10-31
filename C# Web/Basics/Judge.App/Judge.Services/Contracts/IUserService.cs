using Judge.Data.Models;

namespace Judge.Services.Contracts
{
    public interface IUserService
    {
        bool Create(string email, string password, string name);

        bool UserExists(string email, string password);

        int GetId(string email);

        User GetUser(string email);
    }
}
