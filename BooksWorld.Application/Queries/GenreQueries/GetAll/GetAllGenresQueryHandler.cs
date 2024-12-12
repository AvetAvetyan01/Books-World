using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.GenreQueries.GetAll;

public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<Genre>>
{
    private readonly IGenreRepository _genreRepository;

    public GetAllGenresQueryHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<Genre>> Handle(GetAllGenresQuery query, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetAllAsync();

        return genre;
    }
}
