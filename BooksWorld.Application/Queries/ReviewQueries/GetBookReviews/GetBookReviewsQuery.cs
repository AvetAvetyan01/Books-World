using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.ReviewQueries.GetBookReviews;

public sealed record GetBookReviewsQuery(int BookId) : IRequest<IEnumerable<Review>>;
