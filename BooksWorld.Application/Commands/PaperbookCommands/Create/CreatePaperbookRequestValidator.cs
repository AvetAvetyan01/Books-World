using FluentValidation;

namespace BooksWorld.Application.Commands.PaperbookCommands.Create;

public class CreatePaperbookRequestValidator : AbstractValidator<CreatePaperbookRequest>
{
    public CreatePaperbookRequestValidator()
    {
        RuleFor(r => r.BookId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(r => r.PagesCount)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(r => r.Year)
            .NotNull()
            .NotEmpty()
            .GreaterThan(1800);

        //RuleFor(r => r.Publisher);
        //RuleFor(r => r.Language);
        //RuleFor(r => r.Price);
        //RuleFor(r => r.Quantity);
        //RuleFor(r => r.CountOfSales);
    }
}
