using BooksWorld.Application.Commands.AuthorCommands.Create;
using BooksWorld.Application.Commands.AuthorCommands.Update;
using BooksWorld.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController(AuthorService authorService) : ControllerBase 
{
    private readonly AuthorService _authorService = authorService;

    [HttpPost("create")]
    public async Task<IResult> Create(CreateAuthorRequest request) 
    { 
        await _authorService.CreateAsync(request);

        return Results.Ok("Author created successfully");
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id) 
    {   
        var book = await _authorService.GetByIdAsync(id);

        if (book is null)
            return Results.NotFound("Book not found");

        return Results.Ok(book);
    }

    [HttpPut("update")]
    public async Task<IResult> Update(UpdateAuthorRequest request) 
    {
        await _authorService.UpdateAsync(request);

        return Results.Ok("Book's data updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IResult> Delete(int id) 
    {  
        await _authorService.DeleteAsync(id);

        return Results.Ok("Book Deleted");
    }

    [HttpGet("all")]
    public async Task<IResult> GetAll() 
    {
        var books = await _authorService.GetAllAsync();

        return Results.Ok(books);
    }
}