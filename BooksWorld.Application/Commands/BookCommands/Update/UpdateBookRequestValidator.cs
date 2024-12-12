using FluentValidation;

namespace BooksWorld.Application.Commands.BookCommands.Update;

public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
{
    public UpdateBookRequestValidator()
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
