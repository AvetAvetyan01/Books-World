using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Commands.GenreCommands.Create;

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand>
{
    private readonly IMapper _mapper;
    private readonly IGenreRepository _genreRepository;

    public CreateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateGenreCommand command, CancellationToken token)
    {
        var genre = _mapper.Map<Genre>(command);

        await _genreRepository.CreateAsync(genre);
    }
}
