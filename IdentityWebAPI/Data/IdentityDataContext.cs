using IdentityWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IdentityWebAPI.Data
{
    public class IdentityDataContext : DbContext
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Image> Images { get; set; }

        public DbSet<Identity> Identities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Identity>()
                .HasOne(i => i.Image)
                .WithOne()
                .HasForeignKey<Identity>(i => i.ImageId);
        }
    }
}
