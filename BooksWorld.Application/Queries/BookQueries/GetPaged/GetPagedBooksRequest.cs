using BooksWorld.Domain.Common.Enums;
using BooksWorld.Domain.FiltrationModels;

namespace BooksWorld.Application.Queries.BookQueries.GetPaged;

public sealed class GetPagedBooksRequest : BooksFilter
{
    public int  Page                { get; set; } = 1;
    public bool ByDescending        { get; set; } = false;
    public SortingType SortingType  { get; set; } = SortingType.Rating;
}
