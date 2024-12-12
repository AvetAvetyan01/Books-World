using System.ComponentModel.DataAnnotations;

namespace BooksWorld.Domain.Models;

public class Discount
{
    [Key]
    public int      Id          { get; set; }
        
    [Required]
    public int      Percent     { get; set; }

    [Required]
    public DateTime Deadline    { get; set; }
}