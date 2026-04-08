namespace PhotoPortfolia.ViewModels
{
    public class AlbumDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public List<PhotoViewModel> Photos { get; set; } = new List<PhotoViewModel>();
    }

    public class PhotoViewModel
    {
        public string ImageUrl { get; set; } = null!;
        public string? Caption { get; set; }
    }
}
