using MediatR;
using System;
using System.Linq;

namespace ConferencePlanner.Application.Attendees.Queries.GetAttendeeByUsername
{
    public class GetAttendeeByUsernameQuery : IRequest<AttendeeResponse>
    {
        public string Username { get; set; }
    }
}
