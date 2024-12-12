using BooksWorld.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace BooksWorld.Domain.Models.Book;

public class BookBase
{
    [Required]
    public int      BookId    { get; set; }

    [Required]
    public Language Language  { get; set; }

    [Required]
    public int      Year      { get; set; }

    [Required]
    public int      Price     { get; set; }

    [Required]
    public string   Publisher { get; set; }
}