using Microsoft.EntityFrameworkCore;
using WebAPI_ASP.NET.Models;

namespace WebAPI_ASP.NET
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<menu> Menu { get; set; }
        public DbSet<employes> Employes { get; set; }
    }
}
