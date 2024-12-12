using BooksWorld.Domain.Common.Collections;
using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.BookQueries.GetPaged;

public class GetPagedBooksQueryHandler : IRequestHandler<GetPagedBooksQuery, PagedCollection<Book>>
{
    private readonly IBookRepository _bookRepository;
    public GetPagedBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<PagedCollection<Book>> Handle(GetPagedBooksQuery query, CancellationToken cancellationToken)
    {
        // temporary size
        var pageSize = 30;
        var books = await _bookRepository.GetFilteredBooks(query.Filter);
        var orderedBooks = await _bookRepository.GetOrderBy(books, query.SortingType, query.ByDescending);
        var pagedBooks = PagedCollection<Book>.ToPagedCollection(orderedBooks, query.Page, pageSize);

        return pagedBooks;
    }
}
