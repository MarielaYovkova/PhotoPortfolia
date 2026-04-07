using System.ComponentModel.DataAnnotations;

namespace PhotoPortfolia.ViewModels
{
    public class AlbumFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Title must be between 3 and 50 characters long.")]
        [Display(Name = "Album Title")]
        public string Title { get; set; } = null!;

        [StringLength(500, ErrorMessage = "The Description cannot exceed 500 characters.")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid category from the list.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel>? Categories { get; set; }
    }

}
