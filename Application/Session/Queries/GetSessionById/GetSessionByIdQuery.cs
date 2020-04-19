using MediatR;
using System.Data;

namespace ConferencePlanner.Application.Session.Queries.GetSessionById
{
    public class GetSessionByIdQuery : IRequest<SessionResultResponse>
    {
        public int Id { get; set; }
    }
}
