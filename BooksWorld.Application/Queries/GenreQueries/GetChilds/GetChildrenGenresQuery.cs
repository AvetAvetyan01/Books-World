using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.GenreQueries.GetChilds;

public sealed record GetChildrenGenresQuery(int? BaseId) : IRequest<IEnumerable<Genre>>;
