using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Categories;
using StoneSafety.ViewModels.SubCategories;
using StoneSafety.ViewModels.SubSubCategories;
using StoneSafety.ViewModels.Products;
using StoneSafety.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoneSafety.Helpers;

namespace StoneSafety.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ISubSubCategoryService _subSubCategoryService;
        private readonly IProductService _productService;
        private readonly ILogger<ShopController> _logger;

        public ShopController(
            ICategoryService categoryService,
            ISubCategoryService subCategoryService,
            ISubSubCategoryService subSubCategoryService,
            IProductService productService,
            ILogger<ShopController> logger)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _subSubCategoryService = subSubCategoryService;
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var categories = await _categoryService.GetAllAsync();
            var subCategories = await _subCategoryService.GetAllAsync();
            var subSubCategories = await _subSubCategoryService.GetAllAsync();
            var products = await _productService.GetAllPaginateAsync(page, 8);

            var viewModel = new ShopVM
            {
                Categories = categories.Select(c => new CategoryShopVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    Subcategories = subCategories
                        .Where(sc => sc.CategoryId == c.Id)
                        .Select(sc => new SubCategoryShopVM
                        {
                            Id = sc.Id,
                            Name = sc.Name,
                            SubSubCategoryShops = subSubCategories
                                .Where(ssc => ssc.SubCategoryId == sc.Id)
                                .Select(ssc => new SubSubCategoryShopVM
                                {
                                    Id = ssc.Id,
                                    Name = ssc.Name,
                                    SubCategoryName = sc.Name,
                                    ProductShops = products
                                        .Where(p => p.SubSubCategoryId == ssc.Id)
                                        .Select(p => new ProductShopVM
                                        {
                                            Id = p.Id,
                                            Name = p.Name,
                                            Price = p.Price,
                                            Image = p.ProductImages.FirstOrDefault()?.Name,
                                            Description = p.Description,
                                            ProductCode = p.ProductCode,
                                            Rating = p.Rating,
                                            SubCategoryId = sc.Id,
                                            SubCategoryName = sc.Name,
                                            SubSubCategoryId = ssc.Id,
                                            SubSubCategoryName = ssc.Name
                                        }).ToList()
                                }).ToList(),
                            ProductShops = products
                                .Where(p => p.SubcategoryId == sc.Id)
                                .Select(p => new ProductShopVM
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Price = p.Price,
                                    Description = p.Description,
                                    Image = p.ProductImages.FirstOrDefault()?.Name,
                                    ProductCode = p.ProductCode,
                                    Rating = p.Rating,
                                    SubCategoryId = sc.Id,
                                    SubCategoryName = sc.Name
                                }).ToList()
                        }).ToList()
                }).ToList(),
                Products = products.Select(p => new ProductShopVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.ProductImages.FirstOrDefault()?.Name,
                    Description = p.Description,
                    ProductCode = p.ProductCode,
                    Rating = p.Rating,
                    SubCategoryId = p.SubcategoryId ?? 0,
                    SubCategoryName = subCategories.FirstOrDefault(sc => sc.Id == p.SubcategoryId)?.Name,
                    SubSubCategoryId = p.SubSubCategoryId ?? 0,
                    SubSubCategoryName = subSubCategories.FirstOrDefault(ssc => ssc.Id == p.SubSubCategoryId)?.Name
                }).ToList()
            };
            List<ShopVM> ProductPaginate = new List<ShopVM> { viewModel };
            var totalPage = await GetPageCountAsync(8);
            var response = new Paginate<ShopVM>(ProductPaginate , totalPage, page);

            return View(response);
        }
        private async Task<int> GetPageCountAsync(int take)
        {
            int productCount = await _productService.GetCountAsync();
            return (int)Math.Ceiling((decimal)productCount / take);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            try
            {
                var products = await _productService.GetProductsByCategoryAsync(id);
                if (products == null)
                {
                    return NotFound("No products found for the specified category.");
                }
                return Json(products.Select(p => new ProductShopVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.ProductImages.FirstOrDefault()?.Name,
                    Description = p.Description,
                    ProductCode = p.ProductCode,
                    Rating = p.Rating
                }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching products by category");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsBySubCategory(int id)
        {
            var products = await _productService.GetProductsBySubCategoryAsync(id);
            return Json(products.Select(p => new ProductShopVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.ProductImages.FirstOrDefault()?.Name,
                Description = p.Description,
                ProductCode = p.ProductCode,
                Rating = p.Rating
            }));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsBySubSubCategory(int id)
        {
            var products = await _productService.GetProductsBySubSubCategoryAsync(id);
            return Json(products.Select(p => new ProductShopVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.ProductImages.FirstOrDefault()?.Name,
                Description = p.Description,
                ProductCode = p.ProductCode,
                Rating = p.Rating
            }));
        }
    }


}
