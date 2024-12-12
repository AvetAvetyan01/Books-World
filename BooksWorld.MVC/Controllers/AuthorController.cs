using BooksWorld.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.MVC.Controllers;

public class AuthorController : Controller
{
    private readonly AuthorService _authorService;
    public AuthorController(AuthorService authorService)
    {
        _authorService = authorService;
    }

    
    public async Task<IActionResult> Author(int id)
    {
        var author = await _authorService.GetByIdAsync(id);

        return View(author);
    }
}
