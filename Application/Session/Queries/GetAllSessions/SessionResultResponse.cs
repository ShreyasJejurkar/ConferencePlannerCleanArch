using AutoMapper;
using ConferencePlanner.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferencePlanner.Application.Session.Queries.GetAllSessions
{
    public class SessionResultResponse : IMapFrom<Domain.Entities.Session>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual string Abstract { get; set; }
        public virtual DateTimeOffset? StartTime { get; set; }
        public virtual DateTimeOffset? EndTime { get; set; }

        public List<SpeakerDto> Speakers { get; set; } = new List<SpeakerDto>();

        public TrackResponse Track { get; set; }
        public int? TrackId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Session, SessionResultResponse>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.StartTime, y => y.MapFrom(z => z.StartTime))
                .ForMember(x => x.EndTime, y => y.MapFrom(z => z.EndTime))
                .ForMember(x => x.Speakers, y => y.MapFrom(z => z.SessionSpeakers
                                                  .Select(ss => new SpeakerDto { Id = ss.SpeakerId, Name = ss.Speaker.Name }).ToList()))
                .ForMember(x => x.TrackId, y => y.MapFrom(x => x.TrackId))
                .ForMember(x => x.Track, y => y.MapFrom(x => x.Track))
                .ForMember(x => x.Abstract, y => y.MapFrom(x => x.Abstract));
        }
    }
}