using BooksWorld.Application.Commands.AudiobookCommands.Create;
using BooksWorld.Application.Commands.AudiobookCommands.Delete;
using BooksWorld.Application.Commands.AudiobookCommands.Update;
using BooksWorld.Application.Queries.AudiobookQueries.GetAll;
using BooksWorld.Application.Queries.AudiobookQueries.GetById;
using BooksWorld.Domain.Models.Book;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Services;

public class AudiobookService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public AudiobookService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    //public async Task CreateAsync(CreateAudiobookRequest request)
    //{
    //    var command = _mapper.Map<CreateAudiobookCommand>(request);
    //    await _mediator.Send(command);
    //}

    public async Task<Audiobook> CreateAsync(CreateAudiobookRequest request)
    {
        var command = _mapper.Map<CreateAudiobookCommand>(request);
        var result = await _mediator.Send(command);

        return result;
    }

#pragma warning disable CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    public async Task<Audiobook?> GetByIdAsync(int id)
#pragma warning restore CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    {
        var query = new GetAudiobookByIdQuery(id);
        var audiobook = await _mediator.Send(query);

        return audiobook;
    }

    public async Task UpdateAsync(UpdateAudiobookRequest request)
    {
        var command = _mapper.Map<UpdateAudiobookCommand>(request);
        await _mediator.Send(command);
    }

    public async Task DeleteAsync(int id)
    {
        var command = new DeleteAudiobookCommand(id);
        await _mediator.Send(command);
    }

    public async Task<IEnumerable<Audiobook>> GetAllAsync()
    {
        var audiobooks = await _mediator.Send(new GetAllAudiobooksQuery());

        return audiobooks;
    }
}
