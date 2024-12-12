using BooksWorld.Domain.Common.Interfaces;
using BooksWorld.Domain.Models;

namespace BooksWorld.Domain.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetChildsAsync(int? baseId);
    }
}
