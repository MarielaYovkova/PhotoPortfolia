using PhotoPortfolia.ViewModels;

namespace PhotoPortfolia.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CategoryViewModel model);
        Task<CategoryViewModel?> GetByIdAsync(int id);
        Task EditCategoryAsync(CategoryViewModel model);
        Task DeleteCategoryAsync(int id);
    }
}
