using FluentValidation;

namespace BooksWorld.Application.Commands.AuthorCommands.Update;

public class UpdateAuthorRequestValidator : AbstractValidator<UpdateAuthorRequest>
{
    public UpdateAuthorRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.FullName)
            .NotNull()
            .NotNull()
            .MinimumLength(150);

        RuleFor(r => r.ImageUrl)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.Autobiographical)
            .NotNull()
            .NotEmpty()
            .MaximumLength(1500);
    }
}
