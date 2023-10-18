using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<LibraryBranch> LibraryBranch { get; set; }
        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
