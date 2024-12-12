using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.OrderQueries.GetAll;

public sealed record GetAllOrdersQuery : IRequest<IEnumerable<Order>>;
