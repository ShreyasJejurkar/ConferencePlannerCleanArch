using ConferencePlanner.Application.Session.Queries.GetAllSessions;
using MediatR;

namespace ConferencePlanner.Application.Session.Commands.DeleteSession
{
    public class DeleteSessionCommand : IRequest<SessionResultResponse>
    {
        public int Id { get; set; }
    }
}
