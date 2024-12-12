using MediatR;

namespace BooksWorld.Application.Commands.OrderCommands.Create;

public sealed record CreateOrderCommand
(
    Guid UserId,
    int Sum,
    string Address,
    string Description,
    DateTime Date
) : IRequest;
