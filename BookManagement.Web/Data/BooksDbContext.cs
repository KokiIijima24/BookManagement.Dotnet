using BookManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Web
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookManagement.Web.Models.Register> Register { get; set; }
    }
}
