using BookManagement_InMemory.Data;
using BookManagement_InMemory.Models;
using BookManagement_InMemory.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagement_InMemory.Repositories.Services
{
    public class BookService : IBookRepository
    {
        private readonly BookDbContext _dbContext;

        public BookService(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBookAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if(book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task UpateBookAsync(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
