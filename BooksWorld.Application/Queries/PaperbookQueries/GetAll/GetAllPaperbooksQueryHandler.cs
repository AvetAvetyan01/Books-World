using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.PaperbookQueries.GetAll;

public class GetAllPaperbooksQueryHandler : IRequestHandler<GetAllPaperbooksQuery, IEnumerable<Paperbook>>
{
    private readonly IPaperbookRepository _paperbookRepository;
    public GetAllPaperbooksQueryHandler(IPaperbookRepository paperbookRepository)
    {
        _paperbookRepository = paperbookRepository;
    }

    public async Task<IEnumerable<Paperbook>> Handle(GetAllPaperbooksQuery query, CancellationToken cancellationToken)
    {
        var paperbooks = await _paperbookRepository.GetAllAsync();

        return paperbooks;
    }
}
