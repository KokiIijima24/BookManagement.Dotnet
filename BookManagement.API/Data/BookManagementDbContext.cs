using BookManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.API
{
    public class BookManagementDbContext : DbContext
    {
        public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Account> Account { get; set; }
    }
}
