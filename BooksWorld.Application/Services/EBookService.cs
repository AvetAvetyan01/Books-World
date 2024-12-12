using BooksWorld.Application.Commands.EBookCommands.Create;
using BooksWorld.Application.Commands.EBookCommands.Delete;
using BooksWorld.Application.Commands.EBookCommands.Update;
using BooksWorld.Application.Queries.EBookQueries.GetAll;
using BooksWorld.Application.Queries.EBookQueries.GetById;
using BooksWorld.Domain.Models.Book;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Services;

public class EBookService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public EBookService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateEBookRequest request)
    {
        var command = _mapper.Map<CreateEBookCommand>(request);
        await _mediator.Send(command);
    }

#pragma warning disable CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    public async Task<EBook?> GetByIdAsync(int id)
#pragma warning restore CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    {
        var query = new GetEBookByIdQuery(id);
        var ebook = await _mediator.Send(query);

        return ebook;
    }

    public async Task UpdateAsync(UpdateEBookRequest request)
    {
        var command = _mapper.Map<UpdateEBookCommand>(request);
        await _mediator.Send(command);
    }

    public async Task DeleteAsync(int id)
    {
        var command = new DeleteEBookCommand(id);
        await _mediator.Send(command);
    }

    public async Task<IEnumerable<EBook>> GetAllAsync()
    {
        var ebook = await _mediator.Send(new GetAllEBooksQuery());

        return ebook;
    }
}
