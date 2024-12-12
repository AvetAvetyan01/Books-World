using BooksWorld.Application.Commands.BookCommands.Create;
using BooksWorld.Application.Commands.BookCommands.Delete;
using BooksWorld.Application.Commands.BookCommands.Update;
using BooksWorld.Application.Queries.BookQueries.GetAll;
using BooksWorld.Application.Queries.BookQueries.GetById;
using BooksWorld.Application.Queries.BookQueries.GetCollection;
using BooksWorld.Application.Queries.BookQueries.GetPaged;
using BooksWorld.Domain.Common.Collections;
using BooksWorld.Domain.Models.Book;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Services;

public class BookService
{
    public readonly IMediator _mediator;
    public readonly IMapper _mapper;    
    public BookService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Book>> GetCollectionAsync(GetBooksCollectionRequest request)
    {
        var query = _mapper.Map<GetBooksCollectionQuery>(request);
        var collection = await _mediator.Send(query);

        return collection;
    }

    public async Task<PagedCollection<Book>> GetPaged(GetPagedBooksRequest request) 
    {
        var query = _mapper.Map<GetPagedBooksQuery>(request);
        var books = await _mediator.Send(query);

        return books;
    }

    public async Task CreateAsync(CreateBookRequest request)
    {
        var command = _mapper.Map<CreateBookCommand>(request);
        await _mediator.Send(command);
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var query = new GetBooksByIdQuery(id);
        var books = await _mediator.Send(query);

        return books;
    }

    public async Task UpdateAsync(UpdateBookRequest request)
    {
        var command = _mapper.Map<UpdateBookCommand>(request);
        await _mediator.Send(command);
    }

    public async Task DeleteAsync(int id)
    {
        var command = new DeleteBookCommand(id);
        await _mediator.Send(command);
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var books = await _mediator.Send(new GetAllBooksQuery());

        return books;
    }
}