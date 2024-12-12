using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.Persistance.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly ApplicationDbContext _context;
    public GenreRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Genre>> GetChildsAsync(int? baseId) =>
        await Task.Run(() =>
        {
            Genre baseGenre = _context.Genres.Include(g => g.Subgenres)
                                             .ThenInclude(g => g.Subgenres)
                                             .FirstOrDefault(g => g.Id == baseId)!;
            
            ICollection<int> childGenresId = Genre.FindChildGenresId(baseGenre);

            IEnumerable<Genre> children = _context.Genres.Include(g => g.Subgenres)
                                                       .ThenInclude(g => g.Subgenres)
                                                       .Where(g => childGenresId.Contains(g.Id));
            return children;
        });

    public async Task CreateAsync(Genre genre) =>
        await _context.Genres.AddAsync(genre);

    public async Task<Genre?> GetByIdAsync(int id) =>
        await _context.Genres.Include(g => g.Subgenres)
                             .FirstOrDefaultAsync(g => g.Id == id);

    public async Task UpdateAsync(Genre genre) =>
        await Task.Run(() => _context.Genres.Update(genre));
        //await Task.Run(() => _context.Entry(genre).State = EntityState.Modified);

    public async Task DeleteAsync(Genre genre) =>
        await Task.Run(() => _context.Genres.Remove(genre));

    public async Task<IEnumerable<Genre>> GetAllAsync() =>
        await Task.Run(() => _context.Genres.Include(g => g.Subgenres)
                                            .ThenInclude(g => g.Subgenres)
                                            .ThenInclude(g => g.Subgenres));
}