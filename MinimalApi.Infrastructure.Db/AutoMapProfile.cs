using AutoMapper;
using MinimalApi.Core.DomainEntities;
using MinimalApi.Infrastructure.Db.DatabaseObjects;

namespace MinimalApi.Infrastructure.Db
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<Event, EventDo>()
                .ReverseMap();
        }
    }
}
