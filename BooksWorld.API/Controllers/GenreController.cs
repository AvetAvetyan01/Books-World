using BooksWorld.Application.Commands.GenreCommands.Create;
using BooksWorld.Application.Commands.GenreCommands.Update;
using BooksWorld.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController(GenreService genreService) : ControllerBase
{
    private readonly GenreService _genreService = genreService;

    [HttpGet("genre/{baseId}/subgenres")]
    public async Task<IResult> GetChildGenres(int? baseId)
    {
        var subchilds = await _genreService.GetChildrenGenresAsync(baseId);

        return Results.Ok(subchilds);
    }

    [HttpPost("create")]
    public async Task<IResult> Create(CreateGenreRequest request)
    {   
        await _genreService.CreateAsync(request);

        return Results.Ok("Genre created successfully");
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        var genre = await _genreService.GetByIdAsync(id);

        if (genre is null)
            return Results.NotFound("Genre not found");

        return Results.Ok(genre);
    }

    [HttpPut("update")]
    public async Task<IResult> Update(UpdateGenreRequest request)
    {
        await _genreService.UpdateAsync(request);

        return Results.Ok("Genre updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IResult> Delete(int id)
    {
        await _genreService.DeleteAsync(id);

        return Results.Ok("Genre deleted successfully");
    }

    [HttpGet("all")]
    public async Task<IResult> GetAll()
    {
        var genres = await _genreService.GetAllAsync();

        return Results.Ok(genres);
    }
}