using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.PaperbookQueries.GetAll;

public sealed record GetAllPaperbooksQuery() : IRequest<IEnumerable<Paperbook>>;