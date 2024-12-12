using BooksWorld.Domain.Interfaces;
using MediatR;
using BooksWorld.Domain.Models.User;

namespace BooksWorld.Application.Commands.UserCommands.Authentication;

public class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand>
{
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //_userRepository.Login(new User());

        //return Task.CompletedTask;
    }
}
