using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PhotoPortfolia.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int AlbumId { get; set; }
        public virtual Album Album { get; set; } = null!;

        [Required]
        public string AuthorId { get; set; } = null!;
        public virtual IdentityUser Author { get; set; } = null!;
    }
}
