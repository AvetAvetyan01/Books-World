using System.ComponentModel.DataAnnotations;

namespace BooksWorld.Domain.Models.Book;

public class Audiobook : BookBase
{
    [Key]
    [Required]
    public int      Id              { get; set; }

    [Required]
    public DateTime Duration        { get; set; }

    [Required]
    public string   Reader          { get; set; }
    
    [Required]
    public string   Url             { get; set; }

    [Url]
    public string?  IntroductionUrl { get; set; }
}