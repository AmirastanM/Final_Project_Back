using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Baskets;


namespace StoneSafety.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;
        private readonly ICategoryService _categoryService;
        private readonly IHttpContextAccessor _accessor;

        public HeaderViewComponent(ISettingService settingService,
                                   ICategoryService categoryService,
                                   IHttpContextAccessor accessor)
        {
            _settingService = settingService;
            _categoryService = categoryService;
            _accessor = accessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BasketVM> basketDatas = new();

            if (_accessor.HttpContext.Request.Cookies["basket"] is not null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]) ?? new List<BasketVM>();
            }

            var settings = await _settingService.GetAllAsync();
            var categories = await _categoryService.GetAllWithHierarchyAsync();

            var response = new HeaderVMVC
            {
                Settings = settings ?? new Dictionary<string, string>(),
                BasketCount = basketDatas.Sum(m => m.Count),
                BasketTotalPrice = basketDatas.Sum(m => m.Count * m.Price),
                Categories = (categories ?? new List<Category>()).Select(c => new CategoryVM
                {
                    Name = c.Name,
                    Subcategories = (c.SubCategories ?? new List<SubCategory>()).Select(sc => new SubCategoryVM
                    {
                        Name = sc.Name,
                        SubSubCategories = (sc.SubSubCategories ?? new List<SubSubCategory>()).Select(ssc => new SubSubCategoryVM
                        {
                            Name = ssc.Name
                        }).ToList()
                    }).ToList()
                }).ToList(),
                UserIsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.IsAuthenticated ? User.Identity.Name : null,
                IsAdmin = User.IsInRole("Admin") || User.IsInRole("SuperAdmin")
            };

            return View(response);
        }
    }

    public class HeaderVMVC
    {
        public int BasketCount { get; set; }
        public decimal BasketTotalPrice { get; set; }
        public Dictionary<string, string> Settings { get; set; }
        public List<CategoryVM> Categories { get; set; }
        public bool UserIsAuthenticated { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class CategoryVM
    {
        public string Name { get; set; }
        public List<SubCategoryVM> Subcategories { get; set; } = new List<SubCategoryVM>();
    }

    public class SubCategoryVM
    {
        public string Name { get; set; }
        public List<SubSubCategoryVM> SubSubCategories { get; set; } = new List<SubSubCategoryVM>();
    }

    public class SubSubCategoryVM
    {
        public string Name { get; set; }
    }
}
