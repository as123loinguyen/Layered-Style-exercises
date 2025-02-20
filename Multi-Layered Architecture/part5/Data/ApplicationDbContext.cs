using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Multi_Layered_Architecture.part5.Models;

namespace Multi_Layered_Architecture.part5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
