using FluentValidation;
using FluentValidation.Results;

namespace BooksWorld.Application.Commands.UserCommands.Authentication;

public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
{
    public AuthenticationRequestValidator()
    {
        
    }
}
