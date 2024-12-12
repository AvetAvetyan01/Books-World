using FluentValidation;

namespace BooksWorld.Application.Commands.AudiobookCommands.Update;

public class UpdateAudiobookRequestValidator : AbstractValidator<UpdateAudiobookRequest>
{
    public UpdateAudiobookRequestValidator()
    {
        RuleFor(r => r.BookId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(r => r.Duration)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.Url)
            .NotNull()
            .NotEmpty();

        //RuleFor(r => r.IntroductionUrl);
    }
}
