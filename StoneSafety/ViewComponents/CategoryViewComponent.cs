using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;


namespace StoneSafety.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly ISettingService _settingService;

        public CategoryViewComponent(ICategoryService categoryService, ISettingService settingService)
        {
            _categoryService = categoryService;
            _settingService = settingService;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool includeDetails = false)
        {
            var categories = await _categoryService.GetAllWithHierarchyAsync();
            var settings = await _settingService.GetAllAsync();

            var categoryVMs = categories.Select(c => new CategoryVMVC
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image,
                Settings = settings.ToDictionary(s => s.Key, s => s.Value),
                Subcategories = includeDetails ? c.SubCategories.Select(sc => new SubCategoryVMVC
                {
                    Name = sc.Name,
                    SubSubCategories = sc.SubSubCategories.Select(ssc => new SubSubCategoryVMVC
                    {
                        Name = ssc.Name,
                        Products = ssc.Products.Select(p => new ProductVMVC
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Price = p.Price,
                            MainImage = p.ProductImages.FirstOrDefault(i => i.IsMain)?.Name,
                            Description = p.Description,
                            SubCategoryName = sc.Name,
                            SubSubCategoryName = ssc.Name,
                            ProductCode = p.ProductCode,
                            Rating = p.Rating
                        }).ToList()
                    }).ToList()
                }).ToList() : new List<SubCategoryVMVC>()
            }).ToList();

            return View(categoryVMs);
        }
    }

    public class CategoryVMVC
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<SubCategoryVMVC> Subcategories { get; set; } = new List<SubCategoryVMVC>();
        public Dictionary<string, string> Settings { get; set; }
    }

    public class SubCategoryVMVC
    {
        public string Name { get; set; }
        public ICollection<SubSubCategoryVMVC> SubSubCategories { get; set; } = new List<SubSubCategoryVMVC>();
    }

    public class SubSubCategoryVMVC
    {
        public string Name { get; set; }
        public ICollection<ProductVMVC> Products { get; set; } = new List<ProductVMVC>();
    }
}
