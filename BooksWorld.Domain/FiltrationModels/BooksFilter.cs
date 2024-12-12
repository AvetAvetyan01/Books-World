using BooksWorld.Domain.Common.Enums;

namespace BooksWorld.Domain.FiltrationModels;

public class BooksFilter
{
    public int? AuthorId        { get; set; }
    public int? GenreId         { get; set; }
    public int? MinYear         { get; set; }
    public int? MaxYear         { get; set; }
    public int? MinPagesCount   { get; set; }
    public int? MaxPagesCount   { get; set; }
    public int? MaxPrice        { get; set; }
    public int? MinPrice        { get; set; }
    public bool HighRating      { get; set; } = false;
    public bool Discount        { get; set; } = false;

    public Language?    Languages   { get; set; }
    public BookFormat?  Formats     { get; set; }
}
