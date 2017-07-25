
namespace _05.Border_Control
{
    public interface IId
    {
        string Id { get; }

        bool CheckId(string id, string fakeDetector);
    }
}
