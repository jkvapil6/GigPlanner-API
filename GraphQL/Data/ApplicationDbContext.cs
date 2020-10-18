using Microsoft.EntityFrameworkCore;

namespace GigPlanner.GraphQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder
        //     .Entity<Genre>()
        //     .HasIndex(a => a.UserName)
        //     .IsUnique();

        // Many-to-many: Band <-> Genre
        modelBuilder
            .Entity<BandGenre>()
            .HasKey(ca => new { ca.BandId, ca.GenreId });
    }

    public DbSet<Genre> Genres { get; set; } = default!;
    public DbSet<Band> Bands { get; set; } = default!;
    }
}