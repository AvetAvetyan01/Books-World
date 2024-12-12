using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.PaperbookQueries.GetById;

public class GetPaperbookByIdQueryHandle : IRequestHandler<GetPaperbookByIdQuery, Paperbook>
{
    private readonly IPaperbookRepository _paperbookRepository;
    public GetPaperbookByIdQueryHandle(IPaperbookRepository paperbookRepository)
    {
        _paperbookRepository = paperbookRepository;
    }

    public async Task<Paperbook> Handle(GetPaperbookByIdQuery query, CancellationToken cancellationToken)
    {
        var paperbook = await _paperbookRepository.GetByIdAsync(query.Id);

        return paperbook;
    }
}
