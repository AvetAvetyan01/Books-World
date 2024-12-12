using BooksWorld.Domain.Interfaces;
using MediatR;

namespace BooksWorld.Application.Commands.OrderCommands.Delete;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public DeleteOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(command.Id);

        await _orderRepository.DeleteAsync(order);
    }
}
