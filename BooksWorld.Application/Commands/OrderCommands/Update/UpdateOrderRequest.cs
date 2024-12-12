using MediatR;

namespace BooksWorld.Application.Commands.OrderCommands.Update;

public sealed record UpdateOrderRequest
(
    int Id,
    Guid UserId,
    int Sum,
    string Address,
    string Description,
    DateTime Date
) : IRequest;
