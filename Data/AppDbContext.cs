using Microsoft.EntityFrameworkCore;
using BookApi.Models;

namespace BookApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
