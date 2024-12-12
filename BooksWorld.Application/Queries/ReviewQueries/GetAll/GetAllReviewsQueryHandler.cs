using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.ReviewQueries.GetAll;

public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery, IEnumerable<Review>>
{
    private readonly IReviewRepository _reviewRepository;

    public GetAllReviewsQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepository.GetAllAsync();

        return reviews;
    }
}
