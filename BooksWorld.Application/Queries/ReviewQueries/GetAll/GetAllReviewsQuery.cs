using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.ReviewQueries.GetAll;

public sealed record GetAllReviewsQuery : IRequest<IEnumerable<Review>>;