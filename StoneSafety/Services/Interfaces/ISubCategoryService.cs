using Microsoft.AspNetCore.Mvc.Rendering;
using StoneSafety.Models;
using StoneSafety.ViewModels.SubCategories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoneSafety.Services.Interfaces
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategory>> GetAllAsync();
        Task<SubCategory> GetByIdAsync(int id);
        Task<IEnumerable<SubCategory>> GetAllWithHierarchyAsync();
        Task<List<SubCategory>> GetAllPaginateAsync(int page, int take);
        Task<int> GetCountAsync();
        Task<bool> ExistAsync(string name, int categoryId);
        Task<int> CreateAsync(SubCategoryCreateVM subCategoryCreateVM);
        Task UpdateAsync(SubCategory subCategory);
        Task DeleteByIdAsync(int id);
        List<SubCategoryVM> GetMappedDatas(List<SubCategory> subCategories);
        Task<IEnumerable<SubSubCategory>> GetBySubCategoryIdAsync(int subCategoryId);
        Task<int> GetProductCountBySubCategoryIdAsync(int subCategoryId);
        Task<IEnumerable<SelectListItem>> GetAllSelectListAsync();
    }
}
