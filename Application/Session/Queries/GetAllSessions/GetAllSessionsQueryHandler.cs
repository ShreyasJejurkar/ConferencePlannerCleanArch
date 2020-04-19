using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferencePlanner.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Session.Queries.GetAllSessions
{
    public class GetAllSessionsQueryHandler : IRequestHandler<GetAllSessionsQuery, List<SessionResultResponse>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllSessionsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SessionResultResponse>> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _context.Sessions.AsNoTracking()
                                                        .Include(s => s.Track)
                                                        .Include(s => s.SessionSpeakers)
                                                           .ThenInclude(ss => ss.Speaker)
                                                        .ProjectTo<SessionResultResponse>(_mapper.ConfigurationProvider)
                                                        .ToListAsync();

            return sessions;
        }
    }
}
