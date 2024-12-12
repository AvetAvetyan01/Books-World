using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.GenreQueries.GetById;

public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery,Genre>
{
    private readonly IGenreRepository _genreRepository;
    
    public GetGenreByIdQueryHandler(IGenreRepository repository)
    {
        _genreRepository = repository;
    }

    public async Task<Genre> Handle(GetGenreByIdQuery query, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetByIdAsync(query.Id);

        return genre;
    }
}
