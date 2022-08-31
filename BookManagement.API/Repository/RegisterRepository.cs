using Microsoft.EntityFrameworkCore;

namespace BookManagement.API.Models
{
    public interface IRegisterRepository
    {
        Task<Register> GetByIdAsync(int id);
        Task<List<Register>> ListAsync();
        Task<Register> CreateAsync(Register register);
        Task<Register> UpdateAsync(Register register);
        Task<Register> DeleteAsync(int id);
    }

    /// <summary>
    /// データベースと繋ぐ実装
    /// </summary>
    public class RegisterRepository : IRegisterRepository
    {
        private readonly BookManagementDbContext context;

        public RegisterRepository(BookManagementDbContext dbContext)
        {
            context = dbContext;
        }

        public Task<Register> GetByIdAsync(int id)
        {
            return context.Register.FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task<List<Register>> ListAsync()
        {
            return context.Register.ToListAsync();
        }

        public async Task<Register> CreateAsync(Register register)
        {
            context.Register.Add(register);
            await context.SaveChangesAsync();
            return register;
        }

        public async Task<Register> UpdateAsync(Register register)
        {
            context.Entry(register).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return register;
        }
        public async Task<Register> DeleteAsync(int id)
        {
            var r = await GetByIdAsync(id);
            context.Remove(r);
            await context.SaveChangesAsync();
            return r;
        }
    }
}
