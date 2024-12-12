using BooksWorld.Domain.Models.User;

namespace BooksWorld.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);

        Task<User?> GetByIdAsync(Guid id);
    }
}
