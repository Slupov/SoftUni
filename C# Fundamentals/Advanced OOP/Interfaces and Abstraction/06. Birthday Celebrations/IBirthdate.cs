
namespace _05.Border_Control
{
    public interface IBirthdate
    {
        string Birthdate { get; }

        bool CheckBirthdate(string birthday, string birthYear);
    }
}
