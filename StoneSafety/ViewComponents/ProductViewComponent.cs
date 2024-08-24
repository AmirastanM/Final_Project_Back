using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;


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

            var randomProducts = products
                .OrderBy(p => Guid.NewGuid())
            .Take(3)
                .Select(p => new ProductVMVC
                {
                    Id = p.Id,
                    Name = p.Name,
                    MainImage = p.ProductImages.FirstOrDefault(i => i.IsMain)?.Name,
                    Price = p.Price,
                    Description = p.Description,
                    SubCategoryName = p.Subcategory?.Name,
                    SubSubCategoryName = p.SubSubCategory?.Name,
                    ProductCode = p.ProductCode,
                    Rating = p.Rating
                })
                .ToList();

            return View(randomProducts);
        }
    }
}

namespace StoneSafety.ViewComponents
{
    public class ProductVMVC
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainImage { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string SubCategoryName { get; set; }
        public string SubSubCategoryName { get; set; }
        public string ProductCode { get; set; }
        public int Rating { get; set; }
    }
}

