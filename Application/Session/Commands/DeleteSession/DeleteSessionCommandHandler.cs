using AutoMapper;
using ConferencePlanner.Application.Session.Queries.GetAllSessions;
using ConferencePlanner.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Session.Commands.DeleteSession
{
    public class DeleteSessionCommandHandler : IRequestHandler<DeleteSessionCommand, SessionResultResponse>
    {
        private ApplicationDbContext _context;
        public IMapper _mapper { get; }

        public DeleteSessionCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SessionResultResponse> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(x => x.Id == request.Id);

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();

            return _mapper.Map<Domain.Entities.Session, SessionResultResponse>(session);
        }
    }
}
