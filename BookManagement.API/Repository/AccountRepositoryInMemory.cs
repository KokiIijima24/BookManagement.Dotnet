using BookManagement.API.Models;

namespace BookManagement.API.Repository
{
    public class AccountRepositoryInMemory : IAccountRepository
    {
        private List<Account> items;

        public AccountRepositoryInMemory()
        {
            items = new List<Account>()
            {
                new Account(){ Id = 1, Age = 20, Name = "Sam"},
                new Account(){ Id = 2, Age = 24, Name = "Tom"},
            };
        }

        public Task CreateAsync(Account Account)
        {
            return Task.Run(() =>
            {
                if (items.FirstOrDefault(_ => _.Id == Account.Id) != null)
                {
                    items.Add(Account);
                }
            });
        }

        public Task DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                items.RemoveAll(x => x.Id == id);
            });
        }

        public Task<Account?> GetByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                return items.FirstOrDefault(x => x.Id == id);
            });
        }

        public Task<List<Account>> ListAsync()
        {
            return Task.Run(() =>
            {
                return items;
            });
        }

        public Task UpdateAsync(Account Account)
        {
            return Task.Run(() =>
            {
                var item = items.RemoveAll(x => x.Id == Account.Id);
                items.Add(Account);
            });
        }

        Task<Account> IAccountRepository.CreateAsync(Account Account)
        {
            throw new NotImplementedException();
        }

        Task<Account> IAccountRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Account> IAccountRepository.UpdateAsync(Account Account)
        {
            return Task.Run(() =>
            {
                var item = items.RemoveAll(x => x.Id == Account.Id);
                items.Add(Account);
                return Account;
            });
        }
    }
}
