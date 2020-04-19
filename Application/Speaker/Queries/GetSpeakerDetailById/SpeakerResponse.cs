using AutoMapper;
using ConferencePlanner.Application.Common.Mappings;
using System.Collections.Generic;
using System.Linq;

namespace ConferencePlanner.Application.Speaker.Queries.GetSpeakerDetailById
{
    public class SpeakerResponse : IMapFrom<Domain.Entities.Speaker>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public virtual string WebSite { get; set; }

        public ICollection<SessionResponse> Sessions { get; set; } = new List<SessionResponse>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Speaker, SpeakerResponse>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Bio, y => y.MapFrom(z => z.Bio))
                .ForMember(x => x.WebSite, y => y.MapFrom(z => z.WebSite))
                .ForMember(x => x.Sessions, y => y.MapFrom(z => z.SessionSpeakers.Select(ss => new SessionResponse 
                {
                    Id = ss.SessionId,
                    Title = ss.Session.Title
                }).ToList()));
        }
    }

}
