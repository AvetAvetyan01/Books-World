using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.ReviewQueries.GetById;

public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, Review>
{
    private readonly IReviewRepository _reviewRepository;

    public GetReviewByIdQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<Review> Handle(GetReviewByIdQuery query, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetByIdAsync(query.ReviewId);

        return review;
    }
}
