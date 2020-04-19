using ConferencePlanner.Infrastructure;
using FluentValidation;
using System.Linq;

namespace ConferencePlanner.Application.Session.Commands.DeleteSession
{
    public class DeleteSessionCommandValidator : AbstractValidator<DeleteSessionCommand>
    {
        private ApplicationDbContext _context;

        public DeleteSessionCommandValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage("Session Id cannot be 0 or less than that")
                                              .Must(IsSessionExists).WithMessage("Session id does not exist");
        }

        public bool IsSessionExists(int id)
        {
             var track = _context.Sessions.FirstOrDefault(x => x.Id == id);
            if (track == null)
            {
                _context.Dispose();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
