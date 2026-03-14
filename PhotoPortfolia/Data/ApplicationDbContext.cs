using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Models;

public class ApplicationDbContext : IdentityDbContext
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
        base.OnModelCreating(modelBuilder);

   
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Nature" },
            new Category { Id = 2, Name = "Portraits" }
        );

       
        modelBuilder.Entity<Album>().HasData(
            new Album
            {
                Id = 1,
                Title = "Mountain Serenity",
                Description = "Beautiful landscapes from the Alps.",
                CategoryId = 1,
                CreatedOn = DateTime.Now
            }
        );

       
        modelBuilder.Entity<Photo>().HasData(
            new Photo { Id = 1, AlbumId = 1, ImageUrl = "https://images.unsplash.com/photo-1464822759023-fed622ff2c3b", Caption = "Alpine Peaks" },
            new Photo { Id = 2, AlbumId = 1, ImageUrl = "https://images.unsplash.com/photo-1470071459604-3b5ec3a7fe05", Caption = "Forest Mist" }
        );
    }

}

