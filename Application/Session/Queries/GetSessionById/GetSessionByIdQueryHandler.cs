using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferencePlanner.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Session.Queries.GetSessionById
{
    public class GetSessionByIdQueryHandler : IRequestHandler<GetSessionByIdQuery, SessionResultResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSessionByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SessionResultResponse> Handle(GetSessionByIdQuery request, CancellationToken cancellationToken)
        {
            var session = await _context.Sessions.AsNoTracking()
                                           .Include(s => s.Track)
                                           .Include(s => s.SessionSpeakers)
                                               .ThenInclude(ss => ss.Speaker)
                                               .ProjectTo<SessionResultResponse>(_mapper.ConfigurationProvider)
                                           .SingleOrDefaultAsync(s => s.Id == request.Id);

            return session;
        }
    }
}
