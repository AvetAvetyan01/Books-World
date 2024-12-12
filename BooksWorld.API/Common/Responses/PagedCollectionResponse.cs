using BooksWorld.Application.Queries.BookQueries.GetPaged;
using BooksWorld.Domain.Common.Collections;

namespace BooksWorld.MVC.Models;

public sealed record PagedCollectionResponse<T>
(
    GetPagedBooksRequest Request,
    PagedCollection<T> Response
);
