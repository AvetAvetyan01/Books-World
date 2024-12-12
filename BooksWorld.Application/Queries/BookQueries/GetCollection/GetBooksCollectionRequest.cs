using BooksWorld.Domain.FiltrationModels;

namespace BooksWorld.Application.Queries.BookQueries.GetCollection;

public sealed class GetBooksCollectionRequest : BooksFilter
{
    public int Size { get; set; }
};
