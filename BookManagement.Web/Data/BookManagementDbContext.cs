using BookManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Web
{
    public class BookManagementDbContext : DbContext
    {
        public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Register> Register { get; set; }
    }
}
