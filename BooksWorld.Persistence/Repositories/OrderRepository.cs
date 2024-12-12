using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.Persistance.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext context) => _context = context;

    public async Task CreateAsync(Order order) =>
        await _context.Orders.AddAsync(order);

    public async Task<Order?> GetByIdAsync(int id) =>
        await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

    public async Task UpdateAsync(Order order) =>
        await Task.Run(() => _context.Entry(order).State = EntityState.Modified);

    public async Task DeleteAsync(Order order) =>
        await Task.Run(() => _context.Orders.Remove(order));

    public async Task<IEnumerable<Order>> GetAllAsync() =>
        await Task.Run(() => _context.Orders);
}