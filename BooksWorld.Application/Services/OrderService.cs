using BooksWorld.Application.Commands.OrderCommands.Create;
using BooksWorld.Application.Commands.OrderCommands.Delete;
using BooksWorld.Application.Commands.OrderCommands.Update;
using BooksWorld.Application.Queries.OrderQueries.GetAll;
using BooksWorld.Application.Queries.OrderQueries.GetById;
using BooksWorld.Domain.Models;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Services;

public class OrderService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public OrderService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateOrderRequest request)
    {
        var command = _mapper.Map<CreateOrderCommand>(request);
        await _mediator.Send(command);
    }

#pragma warning disable CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    public async Task<Order?> GetByIdAsync(int id)
#pragma warning restore CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    {
        var query = new GetOrderByIdQuery(id);
        var order = await _mediator.Send(query);

        return order;
    }

    public async Task UpdateAsync(UpdateOrderRequest request)
    {
        var command = _mapper.Map<UpdateOrderCommand>(request);
        await _mediator.Send(command);
    }

    public async Task DeleteAsync(int id)
    {
        var command = new DeleteOrderCommand(id);
        await _mediator.Send(command);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        var orders = await _mediator.Send(new GetAllOrdersQuery());

        return orders;
    }
}