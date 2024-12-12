using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.ReviewQueries.GetBookReviews;

public class GetBookReviewsQueryHandler : IRequestHandler<GetBookReviewsQuery, IEnumerable<Review>>
{
    private readonly IReviewRepository _reviewRepository;

    public GetBookReviewsQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<Review>> Handle(GetBookReviewsQuery query, CancellationToken cancellationToken)
    {
        var bookReviews = await _reviewRepository.GetBooksReviewsAsync(query.BookId);

        return bookReviews;
    }
}
