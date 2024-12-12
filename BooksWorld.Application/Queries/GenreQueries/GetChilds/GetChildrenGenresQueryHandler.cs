using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.GenreQueries.GetChilds;

public class GetChildrenGenresQueryHandler : IRequestHandler<GetChildrenGenresQuery, IEnumerable<Genre>>
{
    private readonly IGenreRepository _genreRepository;

    public GetChildrenGenresQueryHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<Genre>> Handle(GetChildrenGenresQuery query, CancellationToken cancellationToken)
    {
        var children = await _genreRepository.GetChildsAsync(query.BaseId);

        return children;
    }
}
