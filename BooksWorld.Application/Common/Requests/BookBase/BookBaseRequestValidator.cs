using FluentValidation;

namespace BooksWorld.Application.Common.Requests.BookBase;

public class BookBaseRequestValidator<T> : AbstractValidator<T> where T : BookBaseRequest
{
    public BookBaseRequestValidator()
    {
        //RuleFor(p => p.Price)
        //    .NotNull()
        //    .NotEmpty()
        //    .GreaterThan(0);

        //RuleFor(p => p.Publisher)
        //    .NotEmpty()
        //    .NotEmpty()
        //    .MaximumLength(50);

        //RuleFor(p => p.Year)
        //    .NotEmpty()
        //    .NotEmpty()
        //    .GreaterThan(1900);

        //RuleFor(p => p.BookId)
        //    .NotEmpty()
        //    .NotNull()
        //    .GreaterThan(0);

        //RuleFor(p => p.Language)
        //    .NotEmpty()
        //    .NotNull()
        //    .IsInEnum(); // ???
    }
}
