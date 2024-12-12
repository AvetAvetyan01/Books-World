using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.User;
using MediatR;

namespace BooksWorld.Application.Commands.UserCommands.Authorization;

public class AuthorizationCommandHandler : IRequestHandler<AuthorizationCommand>
{
    private readonly IUserRepository _userRepository;

    public AuthorizationCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task Handle(AuthorizationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //_userRepository.Registration(new User());

        //return Task.CompletedTask;
    }
}
