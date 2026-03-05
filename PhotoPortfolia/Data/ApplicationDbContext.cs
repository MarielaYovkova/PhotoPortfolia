using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Photo> Photos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Portraits" },
            new Category { Id = 2, Name = "Weddings" },
            new Category { Id = 3, Name = "Nature" }
        );

        base.OnModelCreating(modelBuilder);
    }
}

