using System.ComponentModel.DataAnnotations;

namespace BooksWorld.Domain.Models;

public class Review
{
    [Key]
    public int      Id          { get; set; }

    [Required]
    public Guid     UserId      { get; set; }

    [Required]
    public int      BookId      { get; set; }

    [Required]
    public int      Grade       { get; set; } 

    [StringLength(1000)]
    public string?  Comment     { get; set; }

    [Required]
    public DateTime Date        { get; set; }
}