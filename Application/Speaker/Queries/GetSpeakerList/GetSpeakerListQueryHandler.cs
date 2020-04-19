using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferencePlanner.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Speaker.Queries.GetSpeakerList
{
    public class GetSpeakerListQueryHandler : IRequestHandler<GetSpeakerListQuery, List<SpeakerListResponse>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSpeakerListQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SpeakerListResponse>> Handle(GetSpeakerListQuery request, CancellationToken cancellationToken)
        {
            var speakers = await _context.Speakers.AsNoTracking()
                                                  .Include(s => s.SessionSpeakers)
                                                  .ThenInclude(ss => ss.Session)
                                                  .ProjectTo<SpeakerListResponse>(_mapper.ConfigurationProvider)
                                                  .ToListAsync();

            return speakers;
        }
    }
}
