﻿// using BookManagement.API.Models;

// namespace BookManagement.API.Services
// {
//     public class BookService
//     {
//         // DI した DbContext を保持
//         BookManagementDbContext Context { get; }

//         // DbContext を DI（依存オブジェクトの注入）する
//         public BookService(BookManagementDbContext context) =>
//             Context = context;

//         // 書籍追加
//         public void Add(Book book)
//         {
//             Context.Books.Add(book);
//             Context.SaveChanges();
//         }

//         // 検索ワードがタイトルに含まれる書籍一覧を得る
//         public IEnumerable<Book> GetBooks(string term) =>
//             Context.Books
//                 .Where(book => book.Title.Contains(term))
//                 .OrderBy(book => book.ISBN)
//                 .ToArray();

//     }
// }
