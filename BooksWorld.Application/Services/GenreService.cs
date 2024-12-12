using BooksWorld.Application.Commands.GenreCommands.Create;
using BooksWorld.Application.Commands.GenreCommands.Delete;
using BooksWorld.Application.Commands.GenreCommands.Update;
using BooksWorld.Application.Queries.GenreQueries.GetAll;
using BooksWorld.Application.Queries.GenreQueries.GetById;
using BooksWorld.Application.Queries.GenreQueries.GetChilds;
using BooksWorld.Domain.Models;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Services;

public class GenreService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public GenreService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Genre>> GetChildrenGenresAsync(int? baseId)
    {
        var query = new GetChildrenGenresQuery(baseId);
        var children = await _mediator.Send(query);

        return children;
    }

    public async Task<Genre> GetGenreByIdAsync(int id)
    {
        var query = new GetGenreByIdQuery(id);
        var response = await _mediator.Send(query);

        return response;
    }

    public async Task CreateAsync(CreateGenreRequest request)
    {
        var command = _mapper.Map<CreateGenreRequest>(request);
        await _mediator.Send(command);
    }

#pragma warning disable CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    public async Task<Genre?> GetByIdAsync(int id)
#pragma warning restore CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    {
        var command = new GetGenreByIdQuery(id);
        var genre = await _mediator.Send(command);

        return genre;
    }

    public async Task UpdateAsync(UpdateGenreRequest request)
    {
        var command = _mapper.Map<UpdateGenreCommand>(request);
        await _mediator.Send(command);
    }

    public async Task DeleteAsync(int id)
    {
        var command = new DeleteGenreCommand(id);
        await _mediator.Send(command);
    }

    public async Task<IEnumerable<Genre>> GetAllAsync()
    {
        var genres = await _mediator.Send(new GetAllGenresQuery());

        return genres;
    }
}