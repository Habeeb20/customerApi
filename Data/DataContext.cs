global using Microsoft.EntityFrameworkCore;
namespace Dotnet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
           base.OnConfiguring(optionsBuilder);
           optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=superhero;Trusted_Connection=true;TrustServerCertificate=true");
        }
        
        public DbSet<SuperHero> SuperHero{get; set;}
     
        
    }
}