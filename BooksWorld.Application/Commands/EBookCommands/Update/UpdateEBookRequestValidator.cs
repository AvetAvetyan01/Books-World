using FluentValidation;

namespace BooksWorld.Application.Commands.EBookCommands.Update;

public class UpdateEBookRequestValidator : AbstractValidator<UpdateEBookRequest>
{
    public UpdateEBookRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotNull()
            .NotNull()
            .GreaterThan(0);

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

        RuleFor(r => r.Url)
            .NotNull()
            .NotEmpty();

        //RuleFor(r => r.Publisher);
        //RuleFor(r => r.IntroductionUrl);
        //RuleFor(r => r.Language);
        //RuleFor(r => r.Price);
    }
}
