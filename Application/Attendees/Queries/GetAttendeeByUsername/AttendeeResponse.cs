using AutoMapper;
using ConferencePlanner.Application.Common.Mappings;
using ConferencePlanner.Application.Session.Queries.GetAllSessions;
using System.Collections.Generic;
using System.Linq;

namespace ConferencePlanner.Application.Attendees.Queries.GetAttendeeByUsername
{
    public class AttendeeResponse : IMapFrom<Domain.Entities.Attendee>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<SessionResultResponse> SessionsAttendees { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Attendee, AttendeeResponse>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.FirstName, y => y.MapFrom(x => x.FirstName))
                    .ForMember(x => x.LastName, y => y.MapFrom(x => x.LastName))
                    .ForMember(x => x.UserName, y => y.MapFrom(x => x.UserName))
                    .ForMember(x => x.EmailAddress, y => y.MapFrom(x => x.EmailAddress))
                    .ForMember(x => x.SessionsAttendees, y => y.MapFrom(x => x.SessionsAttendees.Select(ss => new SessionResultResponse 
                    {
                       Id = ss.SessionId,
                       Title = ss.Session.Title,
                       StartTime = ss.Session.StartTime,
                       EndTime = ss.Session.EndTime
                    }).ToList()));
        }
    }
}