using StoneSafety.Models;
using StoneSafety.ViewModels.SubSubCategories;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISubSubCategoryService
{
    Task<bool> ExistAsync(string name, int subCategoryId, int? excludeId = null);
    Task<SubSubCategory> GetByIdAsync(int id);
    Task<int> CreateAsync(SubSubCategoryCreateVM request); 
    Task UpdateAsync(SubSubCategoryEditVM request);
    Task DeleteAsync(int id);
    Task<IEnumerable<SubSubCategory>> GetAllAsync();
    Task<List<SubSubCategoryVM>> GetPaginatedAsync(int page, int take);
    Task<int> GetCountAsync();
    Task<IEnumerable<SubSubCategory>> GetBySubCategoryIdAsync(int subCategoryId);
    Task<int> GetTotalCountAsync();
   

}

