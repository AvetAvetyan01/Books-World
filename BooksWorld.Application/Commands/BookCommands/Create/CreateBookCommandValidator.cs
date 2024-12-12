using FluentValidation;

namespace BooksWorld.Application.Commands.BookCommands.Create;

public class UpdateBookCommandRequestValidator : AbstractValidator<CreateBookRequest>
{
    public UpdateBookCommandRequestValidator()
    {
        RuleFor(r => r.Title)
            .NotNull()
            .NotEmpty()
            .Length(70);

        RuleFor(r => r.AuthorId)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.GenreId)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.ImageUrl)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.Description)
            .NotNull()
            .NotEmpty()
            .Length(1000);
    }
}
