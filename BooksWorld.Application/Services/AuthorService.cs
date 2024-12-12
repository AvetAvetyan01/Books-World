using BooksWorld.Application.Commands.AuthorCommands.Create;
using BooksWorld.Application.Commands.AuthorCommands.Delete;
using BooksWorld.Application.Commands.AuthorCommands.Update;
using BooksWorld.Application.Queries.AuthorQueries.GetAll;
using BooksWorld.Application.Queries.AuthorQueries.GetById;
using BooksWorld.Domain.Models;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Services;

public class AuthorService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public AuthorService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateAuthorRequest request)
    {
        var command = _mapper.Map<CreateAuthorCommand>(request);
        await _mediator.Send(command);
    }

    public async Task<Author> GetByIdAsync(int id)
    {
        var command = new GetAuthorByIdQuery(id);
        var author = await _mediator.Send(command);

        return author;
    }

    public async Task UpdateAsync(UpdateAuthorRequest request)
    {
        var command = _mapper.Map<UpdateAuthorCommand>(request);
        await _mediator.Send(command);
    }

    public async Task DeleteAsync(int id)
    {
        var command = new DeleteAuthorCommand(id);
        await _mediator.Send(command);
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        var authors = await _mediator.Send(new GetAllAuthorsQuery());

        return authors;
    }
}