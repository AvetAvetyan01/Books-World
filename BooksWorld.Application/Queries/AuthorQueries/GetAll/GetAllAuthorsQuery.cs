using MediatR;
using BooksWorld.Domain.Models;

namespace BooksWorld.Application.Queries.AuthorQueries.GetAll;

public sealed record GetAllAuthorsQuery : IRequest<IEnumerable<Author>>;