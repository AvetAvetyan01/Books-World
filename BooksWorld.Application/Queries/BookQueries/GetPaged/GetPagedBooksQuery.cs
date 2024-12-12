using BooksWorld.Domain.Common.Collections;
using BooksWorld.Domain.Common.Enums;
using BooksWorld.Domain.FiltrationModels;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.BookQueries.GetPaged;

public sealed record GetPagedBooksQuery : IRequest<PagedCollection<Book>>
{
    public int          Page            { get; set; } 
    public BooksFilter  Filter          { get; set; }
    public SortingType  SortingType     { get; set; } 
    public bool         ByDescending    { get; set; }   
}
