using BooksWorld.Application.Common.Requests.BookBase;
using FluentValidation;

namespace BooksWorld.Application.Commands.AudiobookCommands.Create;

public class CreateAudiobookRequestValidator : BookBaseRequestValidator<CreateAudiobookRequest>
{
    public CreateAudiobookRequestValidator()
    {
        RuleFor(r => r.Duration)
            .NotNull()
            .NotEmpty();
     
        RuleFor(r => r.Url)
            .NotNull()
            .NotEmpty();

        //RuleFor(r => r.IntroductionUrl);
    }
}