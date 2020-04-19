using ConferencePlanner.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ConferencePlanner.Application.Session.Commands.CreateSession
{
    public class CreateSessionCommandValidator : AbstractValidator<CreateSessionCommand>
    {
        public ApplicationDbContext _context { get; }

        public CreateSessionCommandValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.TrackId).GreaterThan(0).WithMessage("Track id cannot be 0 or equal to 0")
                                   .Must(IsTrackExists).WithMessage("Track id does not exist");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty or null")
                                 .MaximumLength(200).WithMessage("Title cannot be more than 200 characters");

            RuleFor(x => x.Abstract).NotEmpty().WithMessage("Abstract cannot be empty or null")
                                 .MaximumLength(4000).WithMessage("Abstract cannot be more than 4000 characters");
        }

        private bool IsTrackExists(int id)
        {
            var track = _context.Tracks.FirstOrDefault(x => x.Id == id);
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
