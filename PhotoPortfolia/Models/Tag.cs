using System.ComponentModel.DataAnnotations;

namespace PhotoPortfolia.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        public virtual ICollection<PhotoTag> PhotoTags { get; set; } = new HashSet<PhotoTag>();
    }
}

