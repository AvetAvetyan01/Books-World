using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.EBookQueries.GetAll;

public sealed record GetAllEBooksQuery() : IRequest<IEnumerable<EBook>>;
