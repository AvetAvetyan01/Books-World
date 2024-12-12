using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.PaperbookQueries.GetById;

public sealed record GetPaperbookByIdQuery(int Id) : IRequest<Paperbook>;

