using BooksWorld.Domain.Models;
using BooksWorld.Domain.Common.Interfaces;

namespace BooksWorld.Domain.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetBooksReviewsAsync(int bookId);
    }
}
