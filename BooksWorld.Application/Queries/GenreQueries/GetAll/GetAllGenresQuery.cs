using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.GenreQueries.GetAll;

public sealed record GetAllGenresQuery : IRequest<IEnumerable<Genre>>;
