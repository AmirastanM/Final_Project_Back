using Microsoft.AspNetCore.Mvc.Rendering;
using StoneSafety.Models;
using StoneSafety.ViewModels.Products;

namespace StoneSafety.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(Product product, IEnumerable<IFormFile> newImages);
        Task DeleteProductAsync(Product product);      
        Task EditAsync(ProductEditVM data);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllPaginateAsync(int page, int take);
        Task<IEnumerable<Product>> GetAllPopularAsync();  
        IEnumerable<ProductVM> GetMappedDatas(IEnumerable<Product> products);
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByIdWithAllDatasAsync(int id);
        Task<int> GetCountAsync();  
        Task DeleteProductImageAsync(MainAndDeleteImageVM data);
        Task SetMainImageAsync(MainAndDeleteImageVM data);        
        Task<IEnumerable<Product>> GetRandomProductsAsync(int count);              
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsBySubCategoryAsync(int subCategoryId);          
        Task<IEnumerable<Product>> GetProductsBySubSubCategoryAsync(int subSubCategoryId);
    }
}
