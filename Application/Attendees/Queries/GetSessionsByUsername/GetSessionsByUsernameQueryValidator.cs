using ConferencePlanner.Infrastructure;
using FluentValidation;
using System.Linq;

namespace ConferencePlanner.Application.Attendees.Queries.GetSessionsByUsername
{
    public class GetSessionsByUsernameQueryValidator : AbstractValidator<GetSessionsByUsernameQuery>
    {
        public ApplicationDbContext Context { get; }

        public GetSessionsByUsernameQueryValidator(ApplicationDbContext context)
        {
            Context = context;
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Username cannot be empty or null")
                                    .Must(CheckUsernameExists).WithMessage("Username does not exists");
        }

        public bool CheckUsernameExists(string username)
        {
            var user = Context.Attendees.FirstOrDefault(x => x.UserName == username);
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
