using BooksWorld.Application.Commands.BookCommands.Create;
using BooksWorld.Application.Commands.BookCommands.Update;
using BooksWorld.Application.Queries.BookQueries.GetCollection;
using BooksWorld.Application.Queries.BookQueries.GetPaged;
using BooksWorld.Application.Services;
using BooksWorld.Domain.Models.Book;
using BooksWorld.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(BookService bookService) : ControllerBase
{
    private readonly BookService _bookService = bookService;

    [HttpGet("books-collection/")]
    public async Task<IResult> GetBooksCollection([FromQuery, FromBody] GetBooksCollectionRequest request)
    {
        var collection = await _bookService.GetCollectionAsync(request);

        return Results.Ok(collection);
    }

    [HttpGet("books/{request}")]
    public async Task<IResult> GetBooks([FromQuery, FromRoute] GetPagedBooksRequest request)
    {
        var books = await _bookService.GetPaged(request);

        var response = new PagedCollectionResponse<Book>
        (
            request,
            books
        );

        return Results.Ok(response);
    }

    [HttpPost("create")]
    public async Task<IResult> Create(CreateBookRequest request)
    {
        await _bookService.CreateAsync(request);

        return Results.Ok("Book created successfully");
    }
    
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        var book = await _bookService.GetByIdAsync(id);

        if (book is null)
            return Results.NotFound("Book not found");

        return Results.Ok(book);
    }

    [HttpPut("update")]
    public async Task<IResult> Update(UpdateBookRequest request)
    {
        await _bookService.UpdateAsync(request);

        return Results.Ok("Book data updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IResult> Delete(int id)
    {
        await _bookService.DeleteAsync(id);

        return Results.Ok("Book deleted successfully");
    }

    [HttpGet("all")]
    public async Task<IResult> GetAll()
    {
        var books = await _bookService.GetAllAsync();

        return Results.Ok(books);
    }
}