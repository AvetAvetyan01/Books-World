using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.OrderQueries.GetById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(query.OrderId);

        return order;
    }
}
