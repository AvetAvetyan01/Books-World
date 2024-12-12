using BooksWorld.Domain.FiltrationModels;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.BookQueries.GetCollection;

public sealed record GetBooksCollectionQuery : IRequest<IEnumerable<Book>>
{
    public int         Size     { get; set; }   
    public BooksFilter Filter   { get; set; }
}
