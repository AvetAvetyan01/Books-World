using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Commands.OrderCommands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(command);

        await _orderRepository.CreateAsync(order);
    }
}
