using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWorld.Domain.Models.User;

public class User : IdentityUser<Guid>
{
    [ForeignKey("UserId")]
    public ICollection<BasketBook> Bastek { get; set; }

    [ForeignKey("UserId")]
    public ICollection<LikedBook>  LikedBooks { get; set; }
}