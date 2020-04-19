using AutoMapper;
using ConferencePlanner.Application.Common.Mappings;

namespace ConferencePlanner.Application.Session.Queries.GetSessionById
{
    public class TrackResponse : IMapFrom<Domain.Entities.Track>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Track, TrackResponse>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name));
        }
    }
}