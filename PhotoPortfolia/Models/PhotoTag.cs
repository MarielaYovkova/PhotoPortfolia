using PhotoPortfolia.Models;
namespace PhotoPortfolia.Models
{
    public class PhotoTag
    {
        public int PhotoId { get; set; }
        public virtual Photo Photo { get; set; } = null!;

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; } = null!;
    }
}
