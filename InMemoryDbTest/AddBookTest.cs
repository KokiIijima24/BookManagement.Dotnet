using Xunit;

namespace InMemoryDbTest
{
    public class AddBookTest
    {
        [Fact]
        public void 新しい書籍の登録を行う()
        {
            //// インメモリ DB を使うオプション
            //var options = new DbContextOptionsBuilder<BookManagementDbContext>()
            //    .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            //    .Options;

            //// 本を追加。※using ステートメントで一度 DB との接続を切る。
            //using (var context = new BookManagementDbContext(options)) // インメモリ DB を使うオプション設定を渡す
            //{
            //    // サービスクラスをインスタンス化しデータベースコンテキストを DI
            //    var service = new BookService(context);
            //    service.Add(new Book
            //    {
            //        ISBN = "04632170A11526000000",
            //        Title = "四畳半タイムマシンブルース (角川文庫)"
            //    });
            //}

            //// 再びインメモリ DB から値を取り出してテスト
            //using (var context = new BookManagementDbContext(options))
            //{

            //    Assert.Equal(1, context.Books.Count());
            //    var book = context.Books.Single(e => e.ISBN == "04632170A11526000000");
            //    Assert.Equal("四畳半タイムマシンブルース (角川文庫)", book.Title);
            //}
        }
    }
}
