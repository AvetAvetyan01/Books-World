using BooksWorld.Application.Commands.ReviewCommands.Create;
using BooksWorld.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController(ReviewService reviewService) : ControllerBase
{
    private readonly ReviewService _reviewService = reviewService;

    [HttpGet("book/{bookId}/reviews")]
    public async Task<IResult> GetBookReviews(int bookId)
    {
        var reviews = await _reviewService.GetReviewsOfBookAsync(bookId);

        if (reviews == null)
            return Results.NotFound("Review not found");
        
        return Results.Ok(reviews);
    }

    [HttpPost("create")]
    public async Task<IResult> Create(CreateReviewRequest request) 
    {
        await _reviewService.CreateAsync(request);

        return Results.Ok("Review created successfully");
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id) 
    {
        var review = await _reviewService.GetByIdAsync(id);

        if (review == null)
            return Results.NotFound("Review not found");
        
        return Results.Ok(review);
    }

    //[HttpPut("update")]
    //public async Task<IResult> Update(UpdateReviewRequest request) 
    //{
    //    await _reviewService.UpdateAsync(request);

    //    return Results.Problem("Review updated successfully");
    //}

    [HttpDelete("delete/{id}")]
    public async Task<IResult> Delete(int id) 
    {
        await _reviewService.DeleteAsync(id);

        return Results.Ok("Review deleted successfully");
    }

    [HttpGet("all")]
    public async Task<IResult> GetAllReviews() 
    {
        var reviews = await _reviewService.GetAllAsync();
        
        return Results.Ok(reviews);
    }
}