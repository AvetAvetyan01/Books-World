using BooksWorld.Application.Commands.EBookCommands.Create;
using BooksWorld.Application.Commands.EBookCommands.Update;
using BooksWorld.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EBookController(EBookService ebookService) : ControllerBase
{
    private readonly EBookService _ebookService = ebookService;

    [HttpPost("create")]
    public async Task<IResult> Create(CreateEBookRequest request)
    {
        await _ebookService.CreateAsync(request);

        return Results.Ok("eBook created successfully");
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        var ebook = await _ebookService.GetByIdAsync(id);

        if (ebook == null)
            return Results.NotFound("eBook not found");

        return Results.Ok(ebook);
    }

    [HttpPatch("update")]
    public async Task<IResult> Update(UpdateEBookRequest request)
    {
        await _ebookService.UpdateAsync(request);

        return Results.Ok("eBook's data updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IResult> Delete(int id)
    {
        await _ebookService.DeleteAsync(id);

        return Results.Ok("eBook deleted successfully");
    }

    [HttpGet("all")]
    public async Task<IResult> All()
    {
        var ebooks = await _ebookService.GetAllAsync();

        return Results.Ok(ebooks);
    }
}
