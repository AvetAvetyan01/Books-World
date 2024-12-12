namespace BooksWorld.Application.Commands.OrderCommands.Create;

public sealed record CreateOrderRequest
(
    Guid UserId,
    int Sum,
    string Address,
    string Description,
    DateTime Date
);
