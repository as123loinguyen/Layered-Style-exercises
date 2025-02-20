using Microsoft.EntityFrameworkCore;
using Multi_Layered_Architecture.part3.CoreLayer.Entities;

namespace Multi_Layered_Architecture.part3.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Thiết lập quan hệ giữa Movie và Review (1-n)
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId);

            // Thiết lập khóa chính cho bảng MovieSeriesTag (Many-to-Many giữa MovieSeries và Tag)
            modelBuilder.Entity<MovieSeriesTag>()
                .HasKey(mst => new { mst.MovieSeriesId, mst.TagId });

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.Movie)
                .WithMany(m => m.MovieSeriesTags)
                .HasForeignKey(mst => mst.MovieSeriesId);

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.Tag)
                .WithMany(t => t.MovieSeriesTags)
                .HasForeignKey(mst => mst.TagId);
        }
    }
}
