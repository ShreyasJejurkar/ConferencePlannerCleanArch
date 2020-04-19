using ConferencePlanner.Application.Attendees.Queries.GetAttendeeByUsername;
using MediatR;

namespace ConferencePlanner.Application.Attendees.Commands.CreateAttendee
{
    public class CreateAttendeeCommand : IRequest<AttendeeResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
    }
}
