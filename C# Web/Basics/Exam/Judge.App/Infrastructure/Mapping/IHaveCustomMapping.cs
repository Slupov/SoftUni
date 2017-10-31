using AutoMapper;

namespace Judge.App.Infrastructure.Mapping
{
    public interface IHaveCustomMapping
    {
        void Configure(IMapperConfigurationExpression config);
    }
}
