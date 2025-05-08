using BookManagement_InMemory.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement_InMemory.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
