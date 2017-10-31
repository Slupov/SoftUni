using AutoMapper;
using Judge.App.Infrastructure.Mapping;
using Judge.Data.Models;

namespace Judge.App.Models.Contests
{
    public class ListContestModel : IMapFrom<Contest>, IHaveCustomMapping
    {
        public string Name { get; set; }
        public int Submissions { get; set; }
        public string UserEmail { get; set; }

        public void Configure(IMapperConfigurationExpression config)
        {
            config
                .CreateMap<Contest, ListContestModel>()
                .ForMember(lcm => lcm.Submissions, cfg => cfg.MapFrom(c => c.Submissions.Count))
                .ForMember(lcm => lcm.UserEmail, cfg => cfg.MapFrom(c => c.User.Email));
        }
    }
}