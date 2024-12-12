using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.EBookQueries.GetAll;

public class GetAllEBooksQueryHandler : IRequestHandler<GetAllEBooksQuery, IEnumerable<EBook>>
{
    private readonly IEBookRepository _eBookRepository;
    public GetAllEBooksQueryHandler(IEBookRepository eBookRepository)
    {
        _eBookRepository = eBookRepository;
    }

    public async Task<IEnumerable<EBook>> Handle(GetAllEBooksQuery query, CancellationToken cancellationToken)
    {
        var ebooks = await _eBookRepository.GetAllAsync();

        return ebooks;
    }
}
