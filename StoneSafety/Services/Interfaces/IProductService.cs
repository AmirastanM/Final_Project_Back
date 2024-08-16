using Microsoft.AspNetCore.Mvc.Rendering;
using StoneSafety.Models;
using StoneSafety.ViewModels.Products;

namespace StoneSafety.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreateVM data);
        Task DeleteAsync(Product product);
        Task EditAsync(Product product, ProductEditVM data);
        Task<IEnumerable<Product>> GetAllPaginateAsync(int page, int take);
        Task<IEnumerable<Product>> GetAllPopularAsync();
        Task<SelectList> GetAllSelectedActiveAsync();
        Task<SelectList> GetAllSelectedAvailableAsync(int categoryId, int subCategoryId);
        IEnumerable<ProductVM> GetMappedDatas(IEnumerable<Product> products);
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByIdWithImagesAsync(int id);
        Task<Product> GetByIdWithAllDatasAsync(int id);
        Task<int> GetCountAsync();
        Task<bool> ExistAsync(string name);
        Task DeleteProductImageAsync(MainAndDeleteImageVM data);
        Task SetMainImageAsync(ProductVM data);
    }
}
