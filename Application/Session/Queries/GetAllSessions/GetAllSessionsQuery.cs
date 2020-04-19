using MediatR;
using System.Collections.Generic;

namespace ConferencePlanner.Application.Session.Queries.GetAllSessions
{
    public class GetAllSessionsQuery : IRequest<List<SessionResultResponse>>
    {
    }
}
