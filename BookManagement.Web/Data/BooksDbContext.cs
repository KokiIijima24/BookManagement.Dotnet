using BookManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Web.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Register> Register { get; set; }
    }
}
