using Microsoft.AspNetCore.Mvc;
using BooksWorld.Application.Services;

namespace BooksWorld.MVC.Controllers;

public class GenreController : Controller
{
    public readonly GenreService _genreService;
    public GenreController(GenreService genreService)
        { _genreService = genreService; }

    public async Task<IActionResult> AllGenres() =>     
        await Task.FromResult<IActionResult>(View());

    //public async Task<IActionResult> ChildGenres(int baseGenreId)
    //{
    //    var childGenres = await _genreService.GetGenreChildsAsync(baseGenreId);

    //    return View(childGenres);
    //}
}