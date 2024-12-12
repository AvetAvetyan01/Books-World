using FluentValidation;

namespace BooksWorld.Application.Common.Requests.Page;

public class PaginationRequestValidator : AbstractValidator<PaginationRequest>
{
    public PaginationRequestValidator()
    {
        RuleFor(r => r.PageNumber)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(r => r.PageSize)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
    }
}
