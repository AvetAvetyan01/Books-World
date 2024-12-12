using FluentValidation;

namespace BooksWorld.Application.Commands.OrderCommands.Update;

public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderRequestValidator()
    {
        RuleFor(r => r.Id)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

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
