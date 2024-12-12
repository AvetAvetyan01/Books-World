using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.Persistance.Repositories;

public class AudiobookRepository : IAudiobookRepository
{
    private readonly ApplicationDbContext _context;
    public AudiobookRepository(ApplicationDbContext context) => _context = context;

    public async Task CreateAsync(Audiobook audiobook) =>
        await _context.Audiobooks.AddAsync(audiobook);

    public async Task<Audiobook?> GetByIdAsync(int id) => 
        await _context.Audiobooks.FirstOrDefaultAsync(r => r.Id == id);

    public async Task<IEnumerable<Audiobook>> GetAllAsync() =>
        await Task.Run(() => _context.Audiobooks);

    public async Task DeleteAsync(Audiobook review) =>
        await Task.Run(() => _context.Audiobooks.Remove(review));

    public async Task UpdateAsync(Audiobook audiobook) =>
        await Task.Run(() => _context.Entry(audiobook).State = EntityState.Modified);
}
