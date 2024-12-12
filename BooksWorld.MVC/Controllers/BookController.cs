using BooksWorld.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.MVC.Controllers;

public class BookController : Controller
{
    private readonly BookService _bookService;
    public BookController(BookService bookService)
        { _bookService = bookService; }

    public async Task<IActionResult> Book(int id) => 
        View(await _bookService.GetByIdAsync(id));

    public IActionResult Books() => View();

    //public async Task<IActionResult> Books(GetPagedBooksRequest request)
    //{
    //    var books = await _bookService.GetPaged(request);

    //    var response = new PagedCollectionResponse<Book>
    //    (
    //        request,
    //        books
    //    );

    //    return View(response);
    //}
        
}