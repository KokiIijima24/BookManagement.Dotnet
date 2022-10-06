using BookManagement.API.Models;
using BookManagement.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookManagementDbContext>(optionsBuilder => optionsBuilder.UseInMemoryDatabase("InMemoryDb"));

            // Repositoryを切り替えられる
            //services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountRepository, AccountRepositoryInMemory>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddRazorPages();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
