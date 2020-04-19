using AutoMapper;
using ConferencePlanner.Application.Common.Mappings;

namespace ConferencePlanner.Application.Speaker.Queries.GetSpeakerDetailById
{
    public class SessionResponse : IMapFrom<Domain.Entities.Session>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Session, SessionResponse>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.Title, y => y.MapFrom(x => x.Title));
        }
    }
}
