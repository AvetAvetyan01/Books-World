using BooksWorld.Application.Commands.PaperbookCommands.Create;
using BooksWorld.Application.Commands.PaperbookCommands.Delete;
using BooksWorld.Application.Commands.PaperbookCommands.Update;
using BooksWorld.Application.Queries.PaperbookQueries.GetAll;
using BooksWorld.Application.Queries.PaperbookQueries.GetById;
using BooksWorld.Domain.Models.Book;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Services;

public class PaperbookService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PaperbookService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreatePaperbookRequest request)
    {
        var command = _mapper.Map<CreatePaperbookCommand>(request);
        await _mediator.Send(command);
    }

#pragma warning disable CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    public async Task<Paperbook?> GetByIdAsync(int id)
#pragma warning restore CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    {
        var query = new GetPaperbookByIdQuery(id);
        var paperbook = await _mediator.Send(query);

        return paperbook;
    }

    public async Task UpdateAsync(UpdatePaperbookRequest request)
    {
        var command = _mapper.Map<UpdatePaperbookCommand>(request);
        await _mediator.Send(command);
    }

    public async Task DeleteAsync(int id)
    {
        var command = new DeletePaperbookCommand(id);
        await _mediator.Send(command);
    }

    public async Task<IEnumerable<Paperbook>> GetAllAsync()
    {
        var paperbooks = await _mediator.Send(new GetAllPaperbooksQuery());

        return paperbooks;
    }
}