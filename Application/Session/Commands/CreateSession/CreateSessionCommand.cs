using ConferencePlanner.Application.Session.Queries.GetSessionById;
using MediatR;
using System;

namespace ConferencePlanner.Application.Session.Commands.CreateSession
{
    public class CreateSessionCommand : IRequest<SessionResultResponse>
    {
        public string Title { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string Abstract { get; set; }
        public int TrackId { get; set; }
    }
}
