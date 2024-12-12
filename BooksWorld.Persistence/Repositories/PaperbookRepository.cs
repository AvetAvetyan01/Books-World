using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.Persistance.Repositories;

public class PaperbookRepository : IPaperbookRepository
{
    private readonly ApplicationDbContext _context;
    public PaperbookRepository(ApplicationDbContext context) => _context = context;

    public async Task CreateAsync(Paperbook paperbook) =>
        await _context.Paperbooks.AddAsync(paperbook);

    public async Task<Paperbook?> GetByIdAsync(int id) =>
        await _context.Paperbooks.FirstOrDefaultAsync(r => r.Id == id);

    public async Task UpdateAsync(Paperbook paperbook) =>
        await Task.Run(() => _context.Entry(paperbook).State = EntityState.Modified);

    public async Task DeleteAsync(Paperbook review) =>
        await Task.Run(() => _context.Paperbooks.Remove(review));

    public async Task<IEnumerable<Paperbook>> GetAllAsync() =>
        await Task.Run(() => _context.Paperbooks);
}
