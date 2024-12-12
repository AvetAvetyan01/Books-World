using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Commands.GenreCommands.Update;

public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand>
{
    private readonly IMapper _mapper;
    private readonly IGenreRepository _genreRepository;
    public UpdateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateGenreCommand command, CancellationToken cancellationToken)
    {
        var genre = _mapper.Map<Genre>(command);
        await _genreRepository.UpdateAsync(genre);
    }
}
