using System.ComponentModel.DataAnnotations;

namespace BooksWorld.Domain.Models;

public class LikedBook
{
    [Key]
    public int      Id          { get; set; }

    [Required]
    public Guid     UserId      { get; set; }

    [Required]
    public int      BookId      { get; set; }
}