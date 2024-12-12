using FluentValidation;
using FluentValidation.Results;

namespace BooksWorld.Application.Commands.ReviewCommands.Create;

public class CreateReviewRequestValidator : AbstractValidator<CreateReviewRequest>
{
    public CreateReviewRequestValidator()
    {
        
    }
}
