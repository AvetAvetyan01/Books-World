using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.MVC.Controllers;

public class UserController : Controller
{
    public async Task<IActionResult> LikedBooks() => await Task.FromResult<IActionResult>(View());

    public async Task<IActionResult> Basket() => await Task.FromResult<IActionResult>(View());

    public async Task<IActionResult> Login() => await Task.FromResult<IActionResult>(View());

    public async Task<IActionResult> Profile() => await Task.FromResult<IActionResult>(View());

    public async Task<IActionResult> Signin() => await Task.FromResult<IActionResult>(View());
}