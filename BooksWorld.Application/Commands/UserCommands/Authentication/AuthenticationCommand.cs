using MediatR;

namespace BooksWorld.Application.Commands.UserCommands.Authentication;

public sealed record AuthenticationCommand : IRequest;
