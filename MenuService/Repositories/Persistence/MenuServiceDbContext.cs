using MenuService.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace MenuService.Repositories.Persistence
{
    public class MenuServiceDbContext : DbContext
    {
        public MenuServiceDbContext(DbContextOptions<MenuServiceDbContext> options) : base(options) 
        {
        }

        public DbSet<MenuGroup> MenuGroups { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MenuServiceDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.
        }
    }
}
