using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWorld.Domain.Models;

public class Genre 
{
    [Key]
    public int      Id                      { get; set; }

    public int?     BaseGenreId             { get; set; }

    [Required]
    public string   Name                    { get; set; }

    [Required]
    public int      SubgenresCount          { get; set; }

    [Required]
    [ForeignKey("BaseGenreId")]
    public ICollection<Genre> Subgenres     { get; set; } = new List<Genre>();

    public static ICollection<int> FindChildGenresId(Genre genre)
    {
        var childrenGenresId = new List<int>();

        foreach (var child in genre.Subgenres)
        {
            if (child.SubgenresCount != 0)
                foreach (var subchild in FindChildGenresId(child))
                    childrenGenresId.Add(subchild);
            else
                childrenGenresId.Add(child.Id);
        }

        return childrenGenresId;
    }
}