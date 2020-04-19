using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferencePlanner.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Speaker.Queries.GetSpeakerDetailById
{
    public class GetSpeakerDetailByIdQueryHandler : IRequestHandler<GetSpeakerDetailByIdQuery, SpeakerResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSpeakerDetailByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SpeakerResponse> Handle(GetSpeakerDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var speaker = await _context.Speakers.AsNoTracking()
                                                             .Include(s => s.SessionSpeakers)
                                                  .ThenInclude(ss => ss.Session)
                                                  .ProjectTo<SpeakerResponse>(_mapper.ConfigurationProvider)
                                                  .SingleOrDefaultAsync();
            return speaker;
        }
    }
}
