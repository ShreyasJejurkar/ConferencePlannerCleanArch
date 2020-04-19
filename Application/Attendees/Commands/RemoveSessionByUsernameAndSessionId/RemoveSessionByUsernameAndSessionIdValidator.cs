using ConferencePlanner.Infrastructure;
using FluentValidation;
using System.Linq;

namespace ConferencePlanner.Application.Attendees.Commands.RemoveSessionByUsernameAndSessionId
{
    public class RemoveSessionByUsernameAndSessionIdValidator : AbstractValidator<RemoveSessionByUsernameAndSessionIdCommand>
    {
        public ApplicationDbContext Context { get; }

        public RemoveSessionByUsernameAndSessionIdValidator(ApplicationDbContext context)
        {
            Context = context;

            RuleFor(x => x.Username).NotEmpty().NotNull().Must(CheckUsernameExists).WithMessage("Username does not exits");
            RuleFor(x => x.SessionId).NotEmpty().NotNull().Must(CheckSessionExists).WithMessage("Session does not exits");

        }

        public bool CheckUsernameExists(string username)
        {
            var user = Context.Attendees.Where(x => x.UserName == username).FirstOrDefault();
            if (user == null)
            {
                Context.Dispose();
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckSessionExists(int sessionId)
        {
            var user = Context.Sessions.FirstOrDefault(x => x.Id == sessionId);
            if (user == null)
            {
                Context.Dispose();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
