using BooksWorld.Application.Commands.PaperbookCommands.Create;
using BooksWorld.Application.Commands.PaperbookCommands.Update;
using BooksWorld.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PaperbookController(PaperbookService paperbookService) : ControllerBase
{
    private readonly PaperbookService _paperbookService = paperbookService;

    [HttpPost("create")]
    public async Task<IResult> Create(CreatePaperbookRequest request)
    {
        await _paperbookService.CreateAsync(request);

        return Results.Ok("Paperbook created successfully");
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        var paperbook = await _paperbookService.GetByIdAsync(id);

        if (paperbook == null)
            return Results.NotFound("Paperbook not found");

        return Results.Ok(paperbook);
    }

    [HttpPut("update")]
    public async Task<IResult> Update(UpdatePaperbookRequest request)
    {
        await _paperbookService.UpdateAsync(request);

        return Results.Ok("Paperbook updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IResult> Delete(int id)
    {
        await _paperbookService.DeleteAsync(id);

        return Results.Ok("Paperbook deleted successfully");
    }

    [HttpGet("all")]
    public async Task<IResult> All()
    {
        var paperbooks = await _paperbookService.GetAllAsync();

        return Results.Ok(paperbooks);
    }
}
