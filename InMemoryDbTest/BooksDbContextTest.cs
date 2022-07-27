using BookManagement.Web.Data;
using BookManagement.Web.Models;
using BookManagement.Web.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InMemoryDbTest
{
    public class BooksDbContextTest
    {
        [Fact]
        public void Add_writes_to_database()
        {
            // インメモリ DB を使うオプション
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            // 本を追加。※using ステートメントで一度 DB との接続を切る。
            using (var context = new BooksDbContext(options)) // インメモリ DB を使うオプション設定を渡す
            {
                // サービスクラスをインスタンス化しデータベースコンテキストを DI
                var service = new BookService(context);
                service.Add(new Book
                {
                    ISBN = "978-4150117481",
                    Title = "月は無慈悲な夜の女王"
                });
            }

            // 再びインメモリ DB から値を取り出してテスト
            using (var context = new BooksDbContext(options))
            {

                Assert.Equal(1, context.Books.Count());
                var book = context.Books.Single(e => e.ISBN == "978-4150117481");
                Assert.Equal("月は無慈悲な夜の女王", book.Title);
            }
        }
    }
}
