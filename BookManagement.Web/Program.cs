using BookManagement.Web;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddRazorPages(options =>
//{
//    options.Conventions.AddPageRoute("/Pages");
//});

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, builder.Environment);