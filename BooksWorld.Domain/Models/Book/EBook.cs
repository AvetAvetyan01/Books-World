using BooksWorld.Domain.Models.Book;
using System.ComponentModel.DataAnnotations;

namespace BooksWorld.Domain.Models.Book;

public class EBook : BookBase
{
    [Key]
    [Required]
    public int      Id              { get; set; }

    [Required]
    public int      PagesCount      { get; set; }

    [Url]
    [Required]
    public string   Url             { get; set; }

    [Url]
    public string?  IntroductionUrl { get; set; }
}