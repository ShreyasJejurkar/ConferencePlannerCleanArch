using AutoMapper;
using ConferencePlanner.Application.Speaker.Queries.GetSpeakerDetailById;
using ConferencePlanner.Domain.Entities;
using ConferencePlanner.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Search
{
    public class SearchTermQueryHandler : IRequestHandler<SearchTermQuery, List<SearchResult>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SearchTermQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SearchResult>> Handle(SearchTermQuery request, CancellationToken cancellationToken)
        {
            var query = request.Query;

            var sessionResults = await _context.Sessions.Include(s => s.Track)
                                        .Include(s => s.SessionSpeakers)
                                            .ThenInclude(ss => ss.Speaker)
                                            .Where(s => s.Title.Contains(query) || s.Track.Name.Contains(query))
                                            .ToListAsync();

            var speakerResults = await _context.Speakers.Include(s => s.SessionSpeakers)
                                                                 .ThenInclude(ss => ss.Session)
                                                               .Where(s =>
                                                                   s.Name.Contains(query) ||
                                                                   s.Bio.Contains(query) ||
                                                                   s.WebSite.Contains(query)
                                                               )
                                                               .ToListAsync();

            var results = sessionResults.Select(session => new SearchResult
            {
                Type = SearchResultType.Session,
                Session = _mapper.Map<Domain.Entities.Session, SessionResponse>(session)
            })
                       .Concat(speakerResults.Select(speaker => new SearchResult
                       {
                           Type = SearchResultType.Speaker,
                           Speaker = _mapper.Map<Domain.Entities.Speaker, SpeakerResponse>(speaker)
                       }));

            return results.ToList();
        }


    }
}
