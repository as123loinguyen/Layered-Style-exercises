using Microsoft.EntityFrameworkCore;
using Multi_Layered_Architecture.part3.CoreLayer.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Multi_Layered_Architecture.part3.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithOne()
                .HasForeignKey(r => r.MovieId);
        }
    }
}
