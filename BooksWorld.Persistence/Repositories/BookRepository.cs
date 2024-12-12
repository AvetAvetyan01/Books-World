using BooksWorld.Domain.Common.Enums;
using BooksWorld.Domain.FiltrationModels;
using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using BooksWorld.Domain.Models.Book;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.Persistance.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;
    public BookRepository(ApplicationDbContext context) => _context = context;

    public async Task<IQueryable<Book>> GetFilteredBooks(BooksFilter filter) =>
        await Task.Run(() =>
        {
            var books = _context.Books
                                .Include(b => b.Author)
                                .Include(b => b.Discount)
                                .AsSplitQuery();
            
            if (filter.AuthorId != null)
                books = books.Where(b => b.Author.Id == filter.AuthorId);

            if (filter.GenreId != null)
            {
                books = books.Include(b => b.Genre);
                var genre = _context.Genres.FirstOrDefault(g => g.Id == filter.GenreId);

                if (genre != null)
                {
                    ICollection<int> childGenresId = Genre.FindChildGenresId(genre);

                    _ = childGenresId.Count == 0
                    ? books = books.Where(b => b.Genre.Id == filter.GenreId)
                    : books = books.Where(b => childGenresId.Contains(b.Genre.Id));
                }
            }

            if (filter.MinPagesCount != null)
                books = books.Where(b =>
                            b.Paperbooks != null && b.Paperbooks.Any(p => p.PagesCount >= filter.MinPagesCount) ||
                            b.eBooks != null && b.eBooks.Any(p => p.PagesCount >= filter.MinPagesCount));
            
            if (filter.MaxPagesCount != null)
                books = books.Where(b =>
                            b.Paperbooks != null && b.Paperbooks.Any(p => p.PagesCount <= filter.MaxPagesCount) ||
                            b.eBooks != null && b.eBooks.Any(p => p.PagesCount <= filter.MaxPagesCount));

            if (filter.MinPrice != null)
            {
                books = books
                    .Where(b => b.Paperbooks != null && b.Paperbooks.Any(p => p.Price >= filter.MinPrice))
                    .Where(b => b.Audiobooks != null && b.Audiobooks.Any(p => p.Price >= filter.MinPrice))
                    .Where(b => b.eBooks     != null && b.eBooks.Any(p => p.Price >= filter.MinPrice));
            }

            if (filter.MaxPrice != null)
            {
                books = books
                    .Where(b => b.Paperbooks != null && b.Paperbooks.Any(p => p.Price <= filter.MaxPrice))
                    .Where(b => b.Audiobooks != null && b.Audiobooks.Any(p => p.Price <= filter.MaxPrice))
                    .Where(b => b.eBooks     != null && b.eBooks.Any(p => p.Price <= filter.MaxPrice));
            }

            if (filter.MinYear != null)
            {
                books = books
                    .Where(b => b.Paperbooks != null && b.Paperbooks.Any(p => p.Year >= filter.MinYear))
                    .Where(b => b.Audiobooks != null && b.Audiobooks.Any(p => p.Year >= filter.MinYear))
                    .Where(b => b.eBooks     != null && b.eBooks.Any(p => p.Year >= filter.MinYear));
            }

            if (filter.MaxYear != null)
            {
                books = books
                    .Where(b => b.Paperbooks != null && b.Paperbooks.Any(p => p.Year <= filter.MaxYear))
                    .Where(b => b.Audiobooks != null && b.Audiobooks.Any(p => p.Year <= filter.MaxYear))
                    .Where(b => b.eBooks     != null && b.eBooks.Any(p => p.Year <= filter.MaxYear));
            }

            if (filter.HighRating)
                books = books.Where(b => b.Rating >= 4);
            
            if (filter.Discount)
                books = books.Where(b => b.Discount != null);

            if (filter.Languages != null)
                books = books.Where(b => b.Languages.HasFlag(filter.Languages));

            if (filter.Formats != null)
                books = books.Where(b => b.Formats.HasFlag(filter.Formats));

            return books;
        });

    public async Task<IEnumerable<Book>> GetOrderBy(IEnumerable<Book> books, SortingType sortingType, bool byDescending) =>
        await Task.Run(() =>
        {
            books = sortingType switch
            {
                SortingType.Popular => 
                    byDescending 
                        ? books.OrderByDescending(b => b.CountOfGrades) 
                        : books.OrderBy(b => b.CountOfGrades),

                SortingType.Rating => 
                    byDescending 
                        ? books.OrderByDescending(b => b.Rating) 
                        : books.OrderBy(b => b.Rating),

                _ => books,
            };

            return books;
        });

    public async Task CreateAsync(Book book) =>
        await _context.Books.AddAsync(book);

    public async Task<Book?> GetByIdAsync(int id) =>
       await Task.Run(() =>
                 _context.Books
                .Include(c => c.Author)
                .Include(c => c.Genre)
                .Include(c => c.Discount)
                .Include(c => c.Audiobooks)
                .Include(c => c.eBooks)
                .Include(c => c.Paperbooks)
                .Include(c => c.Reviews)
                .FirstOrDefault(b => b.Id == id));  

    public async Task UpdateAsync(Book book) =>
        await Task.Run(() => _context.Entry(book).State = EntityState.Modified);

    public async Task DeleteAsync(Book book) =>
        await Task.Run(() => _context.Books.Remove(book));

    public async Task<IEnumerable<Book>> GetAllAsync() =>
        await Task.Run(() => _context.Books);
}