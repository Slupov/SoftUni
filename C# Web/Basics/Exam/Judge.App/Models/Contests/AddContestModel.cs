using Judge.App.Infrastructure.Mapping;
using Judge.Data.Models;

namespace Judge.App.Models.Contests
{
    public class AddContestModel : IMapFrom<Contest>
    {
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
