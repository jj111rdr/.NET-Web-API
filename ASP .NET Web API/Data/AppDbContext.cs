using ASP_.NET_Web_API.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP_.NET_Web_API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Character> Characters { get; set; }
    }
}
