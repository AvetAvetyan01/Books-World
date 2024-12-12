using BooksWorld.Application.Commands.AudiobookCommands.Create;
using BooksWorld.Application.Commands.AudiobookCommands.Update;
using BooksWorld.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AudiobookController(AudiobookService audiobookService) : ControllerBase
{
    private readonly AudiobookService _audiobookService = audiobookService;

    [HttpPost("create")]
    public async Task<IResult> Create(CreateAudiobookRequest request)
    {
        var result = await _audiobookService.CreateAsync(request);

        //return Results.Ok("Audiobook created successfully");

        return Results.Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        var audiobook = await _audiobookService.GetByIdAsync(id);
 
        if (audiobook == null)
            return Results.NotFound("Audiobook not found");

        return Results.Ok(audiobook);
    }

    [HttpPatch("update")]
    public async Task<IResult> Update([FromQuery] UpdateAudiobookRequest request)
    {
        await _audiobookService.UpdateAsync(request);

        return Results.Ok("Audiobook's data updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IResult> Delete(int id)
    {
        await _audiobookService.DeleteAsync(id);

        return Results.Ok("Audiobook deleted successfully");
    }

    [HttpGet("all")]
    public async Task<IResult> GetAll()
    {
        var audiobooks = await _audiobookService.GetAllAsync();

        return Results.Ok(audiobooks);
    }
}
