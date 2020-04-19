using MediatR;
using System;

namespace ConferencePlanner.Application.Session.Commands.UpdateSession
{
    public class UpdateSessionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string Abstract { get; set; }
        public int TrackId { get; set; }
    }
}
