using AutoMapper;
using Judge.App.Infrastructure.Mapping;
using Judge.Data.Models;

namespace Judge.App.Models.Submissions
{
    public class ListSubmissionModel : IMapFrom<Submission>, IHaveCustomMapping
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string UserEmail { get; set; }

        public void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<Submission, ListSubmissionModel>()
                .ForMember(lsm => lsm.UserEmail, cfg => cfg.MapFrom(s => s.User.Email));
        }
    }
}