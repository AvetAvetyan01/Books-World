using FluentValidation;

namespace BooksWorld.Application.Commands.OrderCommands.Create;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>    
{
    public CreateOrderRequestValidator()
    {
        RuleFor(r => r.UserId)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.Sum)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.Address)
            .NotNull()
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(r => r.Description)
            .MaximumLength(500);

        RuleFor(r => r.Date);
    }
}
