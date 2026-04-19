namespace PhotoPortfolia.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalAlbums { get; set; }
        public int TotalPhotos { get; set; }
        public int TotalComments { get; set; }
        public List<CategoryStatViewModel> CategoryStats { get; set; } = new();
    }

    public class CategoryStatViewModel
    {
        public string CategoryName { get; set; } = null!;
        public int AlbumCount { get; set; }
    }
}

