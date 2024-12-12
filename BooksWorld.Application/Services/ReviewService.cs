using BooksWorld.Application.Commands.ReviewCommands.Create;
using BooksWorld.Application.Commands.ReviewCommands.Delete;
using BooksWorld.Application.Queries.ReviewQueries.GetAll;
using BooksWorld.Application.Queries.ReviewQueries.GetBookReviews;
using BooksWorld.Application.Queries.ReviewQueries.GetById;
using BooksWorld.Domain.Models;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Services;

public class ReviewService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ReviewService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Review>> GetReviewsOfBookAsync(int bookId)
    {
        var query = new GetBookReviewsQuery(bookId);
        var reviews = await _mediator.Send(query);

        return reviews;
    }

    public async Task CreateAsync(CreateReviewRequest request)
    {
        var command = _mapper.Map<CreateReviewCommand>(request);
        await _mediator.Send(command);
    }

#pragma warning disable CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    public async Task<Review?> GetByIdAsync(int id)
#pragma warning restore CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    {
        var query = new GetReviewByIdQuery(id);
        var review = await _mediator.Send(query);

        return review;
    }

    //public async Task UpdateAsync(UpdateReviewRequest request)
    //{
    //    var command = _mapper.Map<UpdateReviewCommand>(request);
    //    await _mediator.Send(command);
    //}

    public async Task DeleteAsync(int id)
    {
        var command = new DeleteReviewCommand(id);
        await _mediator.Send(command);
    }

    public async Task<IEnumerable<Review>> GetAllAsync()
    {
        var reviews = await _mediator.Send(new GetAllReviewsQuery());

        return reviews;
    }
}