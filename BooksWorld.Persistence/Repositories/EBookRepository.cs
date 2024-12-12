using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.Persistance.Repositories;

public class EBookRepository : IEBookRepository
{
    private readonly ApplicationDbContext _context;
    public EBookRepository(ApplicationDbContext context) => _context = context;

    public async Task CreateAsync(EBook ebook) =>
        await _context.eBooks.AddAsync(ebook);

    public async Task<EBook?> GetByIdAsync(int id) =>
        await _context.eBooks.FirstOrDefaultAsync(r => r.Id == id);

    public async Task UpdateAsync(EBook ebook) =>
        await Task.Run(() => _context.Entry(ebook).State = EntityState.Modified);

    public async Task DeleteAsync(EBook ebook) =>
        await Task.Run(() => _context.eBooks.Remove(ebook));

    public async Task<IEnumerable<EBook>> GetAllAsync() =>
        await Task.Run(() => _context.eBooks);
}