namespace PhotoPortfolia.ViewModels
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int AlbumId { get; set; }
    }
}