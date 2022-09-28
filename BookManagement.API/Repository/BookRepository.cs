using BookManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.API.Repository
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(string isbn);
        Task<List<Book>> ListAsync(string bookTitle);
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<Book> DeleteAsync(string isbn);
    }

    public class BookRepository : IBookRepository
    {
        private readonly BookManagementDbContext context;

        public BookRepository(BookManagementDbContext dbContext)
        {
            context = dbContext;
        }

        public Task<Book> GetByIdAsync(string isbn)
        {
            return context.Books.FirstOrDefaultAsync(s => s.ISBN == isbn);
        }

        public IEnumerable<Book> ListAsync(string terms)
        {
            return context.Books.Where(_ => _.Title.Contains(terms));
        }

        public async Task<Book> CreateAsync(Book Book)
        {
            context.Books.Add(Book);
            await context.SaveChangesAsync();
            return Book;
        }

        public async Task<Book> UpdateAsync(Book Book)
        {
            context.Entry(Book).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Book;
        }

        public async Task<Book> DeleteAsync(string isbn)
        {
            var r = await GetByIdAsync(isbn);
            context.Remove(r);
            await context.SaveChangesAsync();
            return r;
        }

        Task<List<Book>> IBookRepository.ListAsync(string bookTitle)
        {
            throw new NotImplementedException();
        }
    }
}
