using System.ComponentModel.DataAnnotations;

namespace BooksWorld.Domain.Models.Book;

public class Paperbook : BookBase
{
    [Key]
    [Required]
    public int      Id              { get; set; }

    [Required]
    public int      PagesCount      { get; set; }

    [Required]
    public int      Quantity        { get; set; }

    [Required]
    public int      CountOfSales    { get; set; }
}