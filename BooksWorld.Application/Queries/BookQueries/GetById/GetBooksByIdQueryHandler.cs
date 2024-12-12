using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.BookQueries.GetById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBooksByIdQuery, Book>
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book> Handle(GetBooksByIdQuery query, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(query.Id);

        return book;
    }
}
