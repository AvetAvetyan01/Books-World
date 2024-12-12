using BooksWorld.Domain.Interfaces;
using MediatR;

namespace BooksWorld.Application.Commands.GenreCommands.Delete;

public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
{
    private readonly IGenreRepository _genreRepository;
    public DeleteGenreCommandHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task Handle(DeleteGenreCommand query, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetByIdAsync(query.Id);
        await _genreRepository.DeleteAsync(genre);
    }
}
