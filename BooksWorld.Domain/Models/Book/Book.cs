using BooksWorld.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWorld.Domain.Models.Book;

public class Book
{
    [Key]
    public int          Id              { get; set; }

    [Required]
    [Url]
    public string       ImageUrl        { get; set; }

    [Required]
    [StringLength(70)]
    public string       Title           { get; set; }

    [Required]
    [StringLength(2000)]
    public string       Description     { get; set; }
        
    public double       Rating          { get; set; } = 0;

    public int          CountOfGrades   { get; set; } = 0;

    public Language     Languages       { get; set; }

    public BookFormat   Formats         { get; set; } 

    [Required]
    public Author       Author          { get; set; }

    [Required]
    public Genre        Genre           { get; set; }

    public Discount?    Discount        { get; set; }

    [ForeignKey("BookId")]
    public ICollection<Audiobook>?  Audiobooks  { get; set; } = new List<Audiobook>();

    [ForeignKey("BookId")]
    public ICollection<EBook>?      eBooks      { get; set; } = new List<EBook>();

    [ForeignKey("BookId")]
    public ICollection<Paperbook>?  Paperbooks  { get; set; } = new List<Paperbook>();

    [ForeignKey("BookId")]
    public ICollection<Review>?     Reviews     { get; set; } = new List<Review>();
}