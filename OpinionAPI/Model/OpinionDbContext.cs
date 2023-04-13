using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OpinionAPI.Model
{
    public class OpinionDbContext : DbContext
    {

        public OpinionDbContext(DbContextOptions<OpinionDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Users)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Movies)
                .WithMany(m => m.Ratings)
                .HasForeignKey(r => r.MovieId);
        }

    }
}
