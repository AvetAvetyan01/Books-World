using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.BookQueries.GetAll;

public sealed record GetAllBooksQuery : IRequest<IEnumerable<Book>>;
