using Microsoft.EntityFrameworkCore;
using UserService.Data.Entities;

namespace UserService.Data.Persistence
{
    public class UserServiceDbContext : DbContext
    {
        public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("UserServiceDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(e => e.UserId);

            modelBuilder.Entity<User>()
            .HasOne<UserRole>(o => o.UserRole)
            .WithMany(c => c.Users)
            .HasForeignKey(o => o.RoleId);

            modelBuilder.Entity<UserRole>().HasKey(e => e.RoleId);
        }
    }
}
