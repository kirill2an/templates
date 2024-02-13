using API.Domain.Entities;
using backend.domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace backend.infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<AppUser> Users { get; set; } = null!;
        public virtual DbSet<AppRole> Roles { get; set; } = null!;
        public virtual DbSet<AppUserRole> UserRoles { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>()
                .HasMany(u => u.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.Id)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(u => u.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.Id)
                .IsRequired();
        }
    }
}