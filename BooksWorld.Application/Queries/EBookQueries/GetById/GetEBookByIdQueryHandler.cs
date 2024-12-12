using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.EBookQueries.GetById;

public sealed record GetEBookByIdQueryHandler : IRequestHandler<GetEBookByIdQuery, EBook>
{
    private readonly IEBookRepository _eBookRepository;
    public GetEBookByIdQueryHandler(IEBookRepository eBookRepository)
    {
        _eBookRepository = eBookRepository; 
    }

    public async Task<EBook> Handle(GetEBookByIdQuery query, CancellationToken cancellationToken)
    {
        var ebook = await _eBookRepository.GetByIdAsync(query.Id);

        return ebook;
    }
}

