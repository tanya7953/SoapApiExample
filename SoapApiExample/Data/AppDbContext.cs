using Microsoft.EntityFrameworkCore;
using SoapApiExample.Models;

namespace SoapApiExample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
    }
}
