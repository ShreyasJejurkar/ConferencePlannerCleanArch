using AutoMapper;
using ConferencePlanner.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Attendees.Queries.GetAttendeeByUsername
{
    public class GetAttendeeByUsernameQueryHandler : IRequestHandler<GetAttendeeByUsernameQuery, AttendeeResponse>
    {
        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        public GetAttendeeByUsernameQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<AttendeeResponse> Handle(GetAttendeeByUsernameQuery request, CancellationToken cancellationToken)
        {
            var attendee = await Context.Attendees.FirstOrDefaultAsync(x => x.UserName == request.Username);
            return Mapper.Map<Domain.Entities.Attendee, AttendeeResponse>(attendee);
        }
    }
}
