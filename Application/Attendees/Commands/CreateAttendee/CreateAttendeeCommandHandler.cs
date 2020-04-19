using AutoMapper;
using ConferencePlanner.Application.Attendees.Queries.GetAttendeeByUsername;
using ConferencePlanner.Domain.Entities;
using ConferencePlanner.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Application.Attendees.Commands.CreateAttendee
{
    public class CreateAttendeeCommandHandler : IRequestHandler<CreateAttendeeCommand, AttendeeResponse>
    {
        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        public CreateAttendeeCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<AttendeeResponse> Handle(CreateAttendeeCommand request, CancellationToken cancellationToken)
        {
            var attendee = new Attendee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                UserName = request.Username
            };

            await Context.Attendees.AddAsync(attendee);
            await Context.SaveChangesAsync();

            return Mapper.Map<Attendee, AttendeeResponse>(attendee);
        }
    }
}
