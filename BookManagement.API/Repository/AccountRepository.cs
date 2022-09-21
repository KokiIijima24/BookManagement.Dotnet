using BookManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.API.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(int id);
        Task<List<Account>> ListAsync();
        Task<Account> CreateAsync(Account Account);
        Task<Account> UpdateAsync(Account Account);
        Task<Account> DeleteAsync(int id);
    }

    /// <summary>
    /// データベースと繋ぐ実装
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        private readonly BookManagementDbContext context;

        public AccountRepository(BookManagementDbContext dbContext)
        {
            context = dbContext;
        }

        public Task<Account> GetByIdAsync(int id)
        {
            return context.Account.FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task<List<Account>> ListAsync()
        {
            return context.Account.ToListAsync();
        }

        public async Task<Account> CreateAsync(Account Account)
        {
            context.Account.Add(Account);
            await context.SaveChangesAsync();
            return Account;
        }

        public async Task<Account> UpdateAsync(Account Account)
        {
            context.Entry(Account).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Account;
        }
        public async Task<Account> DeleteAsync(int id)
        {
            var r = await GetByIdAsync(id);
            context.Remove(r);
            await context.SaveChangesAsync();
            return r;
        }
    }
}
