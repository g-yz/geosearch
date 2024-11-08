using Microsoft.EntityFrameworkCore;

namespace GeoSearch.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<FavoritePlace> FavoritePlaces { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<FavoritePlace>()
            .HasIndex(fp => fp.FsqId)
            .IsUnique();
    }
}
