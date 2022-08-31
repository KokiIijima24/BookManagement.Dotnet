using BookManagement.API.Models;

namespace BookManagement.API.Repository
{
    public class RegisterRepositoryInMemory : IRegisterRepository
    {
        private List<Register> items;

        public RegisterRepositoryInMemory()
        {
            items = new List<Register>()
            {
                new Register(){ Id = 1, Age = 20, Name = "Sam"},
                new Register(){ Id = 2, Age = 24, Name = "Tom"},
            };
        }

        public Task CreateAsync(Register register)
        {
            return Task.Run(() =>
            {
                if (items.FirstOrDefault(_ => _.Id == register.Id) != null)
                {
                    items.Add(register);
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

        public Task<Register?> GetByIdAsync(int id)
        {
            return Task.Run(() =>
            {
                return items.FirstOrDefault(x => x.Id == id);
            });
        }

        public Task<List<Register>> ListAsync()
        {
            return Task.Run(() =>
            {
                return items;
            });
        }

        public Task UpdateAsync(Register register)
        {
            return Task.Run(() =>
            {
                var item = items.RemoveAll(x => x.Id == register.Id);
                items.Add(register);
            });
        }

        Task<Register> IRegisterRepository.CreateAsync(Register register)
        {
            throw new NotImplementedException();
        }

        Task<Register> IRegisterRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Register> IRegisterRepository.UpdateAsync(Register register)
        {
            return Task.Run(() =>
            {
                var item = items.RemoveAll(x => x.Id == register.Id);
                items.Add(register);
                return register;
            });
        }
    }
}
