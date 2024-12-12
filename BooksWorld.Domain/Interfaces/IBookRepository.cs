using BooksWorld.Domain.Common.Enums;
using BooksWorld.Domain.Common.Interfaces;
using BooksWorld.Domain.FiltrationModels;
using BooksWorld.Domain.Models.Book;

namespace BooksWorld.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IQueryable<Book>> GetFilteredBooks(BooksFilter filter);
        
        Task<IEnumerable<Book>> GetOrderBy(IEnumerable<Book> books, SortingType sortingType, bool byDescending);
    }
}