using FluentValidation;

namespace BooksWorld.Application.Commands.AuthorCommands.Create;

public class CreateAuthorRequestValidator : AbstractValidator<CreateAuthorRequest>
{
    public CreateAuthorRequestValidator()
    {
        RuleFor(r => r.FullName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(r => r.ImageUrl)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.Autobiographical)
            .NotNull()
            .NotEmpty()
            .MaximumLength(1500);
    }
}
