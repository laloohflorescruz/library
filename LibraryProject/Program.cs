using LibraryManagement;
using LibraryManagement.Models;
using LibraryManagement.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>();

//Services here!
builder.Services.AddScoped<IGenericRepository<Author>, GenericRepository<Author>>();
builder.Services.AddScoped<IGenericRepository<Customer>, GenericRepository<Customer>>();
builder.Services.AddScoped<IGenericRepository<LibraryBranch>, GenericRepository<LibraryBranch>>();
builder.Services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
