using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.BookQueries.GetById;

public sealed record GetBooksByIdQuery(int Id) : IRequest<Book>;