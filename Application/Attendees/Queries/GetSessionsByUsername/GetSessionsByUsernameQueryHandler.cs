using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferencePlanner.Application.Session.Queries.GetAllSessions;
using ConferencePlanner.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Attendees.Queries.GetSessionsByUsername
{
    public class GetSessionsByUsernameQueryHandler : IRequestHandler<GetSessionsByUsernameQuery, List<SessionResultResponse>>
    {
        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        public GetSessionsByUsernameQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<List<SessionResultResponse>> Handle(GetSessionsByUsernameQuery request, CancellationToken cancellationToken)
        {
            var sessions = await Context.Sessions.AsNoTracking()
                                                 .Include(s => s.Track)
                                                 .Include(s => s.SessionSpeakers)
                                                 .ThenInclude(ss => ss.Speaker)
                                                 .Where(s => s.SessionAttendees.Any(sa => sa.Attendee.UserName == request.Username))
                                                 .ProjectTo<SessionResultResponse>(Mapper.ConfigurationProvider)
                                                 .ToListAsync();
            return sessions;
        }
    }
}
