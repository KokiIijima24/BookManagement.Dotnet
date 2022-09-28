using BookManagement.API.Models;
using BookManagement.API.Repository;

namespace BookManagement.API.Services
{
    public class BookService
    {
        private IBookRepository context;

        public BookService(IBookRepository appDbContext)
        {
            context = appDbContext;
        }

        // 書籍追加
        public void Add(Book book)
        {
            context.CreateAsync(book);
        }

        public Task<Book> GetBook(string ISBN, int userId)
        {
            return context.GetByIdAsync(ISBN);
        }

        // 検索ワードがタイトルに含まれる書籍一覧を得る
        public Task<List<Book>> SearchBooks(string bookTitle, string author)
        {
            // Authorに夜検索は未実装
            return context.ListAsync(bookTitle);
        }

        public Task<List<Book>> GetBookAll()
        {
            return context.ListAsync();
        }
    }
}
