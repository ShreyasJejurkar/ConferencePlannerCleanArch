using ConferencePlanner.Infrastructure;
using FluentValidation;
using System.Linq;

namespace ConferencePlanner.Application.Attendees.Commands.CreateAttendee
{
    public class CreateAttendeeCommandValidator : AbstractValidator<CreateAttendeeCommand>
    {
        public ApplicationDbContext Context { get; }

        public CreateAttendeeCommandValidator(ApplicationDbContext context)
        {
            Context = context;

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be empty")
                                     .NotNull().WithMessage("First name cannot be null");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name cannot be empty")
                                     .NotNull().WithMessage("Last name cannot be null");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be null")
                                     .NotNull().WithMessage("Username cannot be null")
                                     .Must(IsUnique).WithMessage("Username already exists");

            RuleFor(x => x.EmailAddress).EmailAddress();
        }

        private bool IsUnique(string username)
        {
            var user = Context.Attendees.Where(x => x.UserName == username).FirstOrDefault();
            if (user == null)
            {
                return true;
            }
            else
            {
                Context.Dispose();
                return false;
            }
        }
    }
}
