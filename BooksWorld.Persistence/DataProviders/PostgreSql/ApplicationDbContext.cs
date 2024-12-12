using BooksWorld.Domain.Models;
using BooksWorld.Domain.Models.Book;
using BooksWorld.Domain.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.Persistance.DataProviders.PostgreSql;

public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
{
    public ApplicationDbContext(){}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Author>     Authors        { get; set; }
    public DbSet<Book>       Books          { get; set; }
    public DbSet<Audiobook>  Audiobooks     { get; set; }
    public DbSet<EBook>      eBooks         { get; set; }
    public DbSet<Paperbook>  Paperbooks     { get; set; }
    public DbSet<BasketBook> BastetBooks    { get; set; }
    public DbSet<Genre>      Genres         { get; set; }
    public DbSet<LikedBook>  LikedBooks     { get; set; }
    public DbSet<Order>      Orders         { get; set; }
    public DbSet<Review>     Reviews        { get; set; }
    public DbSet<Discount>   Discounts      { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql
                (Constant.DbConnectionString);
    }
}
