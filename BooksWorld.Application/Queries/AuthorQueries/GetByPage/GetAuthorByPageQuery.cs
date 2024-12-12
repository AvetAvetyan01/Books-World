using BooksWorld.Domain.Common.Collections;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.AuthorQueries.GetByPage;

public sealed record GetAuthorByPageQuery
(
    int PageNumber,
    int PageSize
) : IRequest<PagedCollection<Author>>;
