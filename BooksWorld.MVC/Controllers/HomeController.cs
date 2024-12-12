using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.MVC.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> About() => await Task.FromResult<IActionResult>(View());

    public async Task<IActionResult> FAQ() => await Task.FromResult<IActionResult>(View());

    public async Task<IActionResult> Feedback() => await Task.FromResult<IActionResult>(View());

    //public async Task SendFeedback() { }

    public async Task<IActionResult> GiftCards() => await Task.FromResult<IActionResult>(View());

    public async Task<IActionResult> Index() => await Task.FromResult<IActionResult>(View());

    public async Task<IActionResult> Locations() => await Task.FromResult<IActionResult>(View());

    public async Task<IActionResult> Partners() => await Task.FromResult<IActionResult>(View());

    public async Task<IActionResult> Privacy() => await Task.FromResult<IActionResult>(View());
}