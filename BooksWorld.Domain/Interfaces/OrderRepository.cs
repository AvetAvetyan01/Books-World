using BooksWorld.Domain.Models;

namespace BooksWorld.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(int id);
        Task CreateAsync(Order order);
        Task DeleteAsync(Order order);
        Task<IEnumerable<Order>> GetAllAsync();
    }
}
