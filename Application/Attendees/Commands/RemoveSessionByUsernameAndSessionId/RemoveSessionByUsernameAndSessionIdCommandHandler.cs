using ConferencePlanner.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Attendees.Commands.RemoveSessionByUsernameAndSessionId
{
    public class RemoveSessionByUsernameAndSessionIdCommandHandler : IRequestHandler<RemoveSessionByUsernameAndSessionIdCommand, Unit>
    {
        public ApplicationDbContext Context { get; }

        public RemoveSessionByUsernameAndSessionIdCommandHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<Unit> Handle(RemoveSessionByUsernameAndSessionIdCommand request, CancellationToken cancellationToken)
        {
            var attendee = await Context.Attendees.Include(a => a.SessionsAttendees)
                .SingleOrDefaultAsync(a => a.UserName == request.Username);
            var session = await Context.Sessions.FindAsync(request.SessionId);
            var sessionAttendee = attendee.SessionsAttendees.FirstOrDefault(sa => sa.SessionId == request.SessionId);
            attendee.SessionsAttendees.Remove(sessionAttendee);
            await Context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
