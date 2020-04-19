using FluentValidation;

namespace ConferencePlanner.Application.Search
{
    public class SearchTermQueryValidator : AbstractValidator<SearchTermQuery>
    {
        public SearchTermQueryValidator()
        {
            RuleFor(x => x.Query).NotEmpty().WithMessage("Query should not be empty")
                                 .NotNull().WithMessage("Query cannot be null");
        }
    }
}
