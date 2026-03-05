using PhotoPortfolia.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Photo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string ImageUrl { get; set; } = null!; 

    public string? Caption { get; set; }

    [Required]
    public int AlbumId { get; set; }

    [ForeignKey(nameof(AlbumId))]
    public Album Album { get; set; } = null!;
}

