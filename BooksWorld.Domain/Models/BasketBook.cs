using BooksWorld.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace BooksWorld.Domain.Models;

public class BasketBook
{
    [Key]
    public int          Id          { get; set; }

    [Required]
    public Guid         UserId      { get; set; }

    [Required]
    public int          BaseBookId  { get; set; }

    [Required]
    public int          BookId      { get; set; }

    [Required]
    public BookFormat   Format      { get; set; }
}