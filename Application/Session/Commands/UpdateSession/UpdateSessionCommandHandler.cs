using ConferencePlanner.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Session.Commands.UpdateSession
{
    public class UpdateSessionCommandHandler : IRequestHandler<UpdateSessionCommand, Unit>
    {
        public ApplicationDbContext _context { get; }

        public UpdateSessionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
        {
            var session = new Domain.Entities.Session
            {
                Id = request.Id,
                Title = request.Title,
                Abstract = request.Abstract,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                TrackId = request.TrackId
            };

            _context.Entry(session).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
