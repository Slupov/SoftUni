using System.Dynamic;
using WebApiBooks.Data.Models;

namespace WebApiBooks.Services
{
    public interface ICategoriesService
    {
        Author Get(int id, string firstName, string lastName);
        void Create(string firstName, string lastName);

    }
}
