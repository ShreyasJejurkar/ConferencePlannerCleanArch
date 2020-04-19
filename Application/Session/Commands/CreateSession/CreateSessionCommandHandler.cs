using AutoMapper;
using ConferencePlanner.Application.Session.Queries.GetSessionById;
using ConferencePlanner.Domain.Entities;
using ConferencePlanner.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Session.Commands.CreateSession
{
    public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, SessionResultResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateSessionCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SessionResultResponse> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            var session = new Domain.Entities.Session
            {
                Title = request.Title, 
                Abstract = request.Abstract,
                StartTime = request.StartTime,
                EndTime = request.EndTime, 
                TrackId = request.TrackId 
            };

            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Domain.Entities.Session, SessionResultResponse>(session);
            return result;
        }
    }
}
