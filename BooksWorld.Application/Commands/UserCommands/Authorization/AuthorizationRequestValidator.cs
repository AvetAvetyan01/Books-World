using FluentValidation;

namespace BooksWorld.Application.Commands.UserCommands.Authorization;

public class AuthorizationRequestValidator : AbstractValidator<AuthorizationRequest>
{
    public AuthorizationRequestValidator()
    {
        
    }
}
