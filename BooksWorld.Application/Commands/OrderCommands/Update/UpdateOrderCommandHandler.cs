using BooksWorld.Domain.Interfaces;
using MediatR;

namespace BooksWorld.Application.Commands.OrderCommands.Update;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public UpdateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
