using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.Persistance.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _context;
    public AuthorRepository(ApplicationDbContext context) => _context = context; 
    
    public async Task CreateAsync(Author author) =>
        await _context.Authors.AddAsync(author);

    public async Task<Author?> GetByIdAsync(int id) =>
        await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);

    public async Task UpdateAsync(Author changedAuthor) =>
        await Task.Run(() => _context.Entry(changedAuthor).State = EntityState.Modified);

    public async Task DeleteAsync(Author author) =>
        await Task.Run(() => _context.Authors.Remove(author));

    public async Task<IEnumerable<Author>> GetAllAsync() =>
        await Task.Run(() => _context.Authors);
}