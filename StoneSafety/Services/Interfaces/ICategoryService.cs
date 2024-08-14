using Microsoft.AspNetCore.Mvc.Rendering;
using StoneSafety.Models;
using StoneSafety.ViewModels.Categories;

namespace StoneSafety.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllWithHierarchyAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> GetByIdWithHierarchyAsync(int id);
        Task<SelectList> GetAllSelectedAsync();
        IEnumerable<CategoryVM> GetMappedDatas(IEnumerable<Category> categories);
        Task<IEnumerable<Category>> GetAllPaginateAsync(int page, int take);
        Task<int> GetCountAsync();
        Task<bool> ExistAsync(string name);
        Task CreateAsync(CategoryCreateVM request);
        Task EditAsync(Category category, CategoryEditVM request);
        Task DeleteAsync(Category category);
    }
}
