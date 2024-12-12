using MediatR;

namespace BooksWorld.Application.Commands.OrderCommands.Delete;

public sealed record DeleteOrderCommand(int Id) : IRequest;
