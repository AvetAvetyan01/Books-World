using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.BookQueries.GetCollection;

public class GetBooksCollectionQueryHandler : IRequestHandler<GetBooksCollectionQuery, IEnumerable<Book>>
{
    private readonly IBookRepository _bookRepository;
    public GetBooksCollectionQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> Handle(GetBooksCollectionQuery query, CancellationToken cancellationToken)
    {
        var books = (await _bookRepository.GetFilteredBooks(query.Filter))
                                          .Take(query.Size);
        return books;
    }
}
