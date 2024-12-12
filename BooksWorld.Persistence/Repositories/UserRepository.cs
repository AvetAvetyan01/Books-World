using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.User;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) => _context = context;

    public async Task CreateUserAsync(User user) =>
        await _context.Users.AddAsync(user);

    public async Task<User?> GetByIdAsync(Guid id) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
}