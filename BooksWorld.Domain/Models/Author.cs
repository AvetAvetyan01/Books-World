using System.ComponentModel.DataAnnotations;

namespace BooksWorld.Domain.Models;

public class Author
{
    [Key]
    public int                  Id               { get; set; }

    [Required]
    [StringLength(150)]
    public string               FullName         { get; set; }

    [Required]
    [Url]
    public string               ImageUrl         { get; set; }

    [Required]
    [StringLength(3500)]
    public string               Autobiographical { get; set; }
}