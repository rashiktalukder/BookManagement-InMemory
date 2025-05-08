using BookManagement_InMemory.Models;

namespace BookManagement_InMemory.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
