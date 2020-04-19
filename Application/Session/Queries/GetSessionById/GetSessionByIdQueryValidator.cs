using FluentValidation;

namespace ConferencePlanner.Application.Session.Queries.GetSessionById
{
    public class GetSessionByIdQueryValidator : AbstractValidator<GetSessionByIdQuery>
    {
        public GetSessionByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Session Id cannot be less than and equal to 0");
        }
    }
}
