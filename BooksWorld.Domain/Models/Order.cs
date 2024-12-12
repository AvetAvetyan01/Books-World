using System.ComponentModel.DataAnnotations;

namespace BooksWorld.Domain.Models;

public class Order 
{
    [Key]
    public int      Id          { get; set; }

    [Required]
    public Guid     UserId      { get; set; }
            
    [Required]
    public int      Sum         { get; set; }

    [Required]
    [StringLength(250)]
    public string   Address     { get; set; }

    [Required]
    [StringLength(500)]
    public string   Description { get; set; }

    [Required]
    public DateTime Date        { get; set; }
}