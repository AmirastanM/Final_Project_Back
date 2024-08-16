using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace StoneSafety.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllPopularAsync();
            var response = products.Select(p => new ProductVMVC
            {
                Name = p.Name,
                MainImage = p.ProductImages.FirstOrDefault(i => i.IsMain)?.Name,
                Price = p.Price,
                Description = p.Description,
                SubCategoryName = p.Subcategory?.Name,
                SubSubCategoryName = p.SubSubCategory?.Name,
                ProductCode = p.ProductCode,
                Rating = p.Rating 
            });

            return await Task.FromResult(View(response));
        }
    }

    public class ProductVMVC
    {
        public string ProductName { get; set; }
        public string MainImage { get; set; }
        public decimal ProductPricePrice { get; set; }
        public string Description { get; set; }
        public string SubCategoryName { get; set; }
        public string SubSubCategoryName { get; set; }
        public string ProductCode { get; set; }
        public int Rating { get; set; }
    }
}
