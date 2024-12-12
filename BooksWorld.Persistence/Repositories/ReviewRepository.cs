using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.Persistance.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;
    public ReviewRepository(ApplicationDbContext context) => _context = context; 

    public async Task<IEnumerable<Review>> GetBooksReviewsAsync(int bookId) =>
        await Task.Run(() => _context.Reviews.Where(r => r.Id == bookId));

    public async Task CreateAsync(Review review) =>
        await _context.Reviews.AddAsync(review);

    public async Task<Review?> GetByIdAsync(int id) =>
        await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);

    public async Task UpdateAsync(Review review) =>
        await Task.Run(() => _context.Entry(review).State = EntityState.Modified);

    public async Task DeleteAsync(Review review) =>
        await Task.Run(() => _context.Reviews.Remove(review));

    public async Task<IEnumerable<Review>> GetAllAsync() =>
        await Task.Run(() => _context.Reviews);
}