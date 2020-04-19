using ConferencePlanner.Application.Session.Queries.GetAllSessions;
using MediatR;
using System.Collections.Generic;

namespace ConferencePlanner.Application.Attendees.Queries.GetSessionsByUsername
{
    public class GetSessionsByUsernameQuery : IRequest<List<SessionResultResponse>>
    {
        public string Username { get; set; }
    }
}
