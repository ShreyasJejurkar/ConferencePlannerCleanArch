using FluentValidation;

namespace ConferencePlanner.Application.Speaker.Queries.GetSpeakerDetailById
{
    public class GetSpeakerDetailByIdQueryValidator : AbstractValidator<GetSpeakerDetailByIdQuery>
    {
        public GetSpeakerDetailByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Speaker Id cannot be less than and equal to 0");
        }
    }
}
