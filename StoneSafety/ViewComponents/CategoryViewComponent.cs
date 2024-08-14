using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using StoneSafety.Services.Interfaces;

namespace StoneSafety.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Получаем все категории с подкатегориями, субподкатегориями и продуктами.
            var categories = await _categoryService.GetAllWithHierarchyAsync();

            return View(categories.Select(c => new CategoryVMVC
            {
                Name = c.Name,
                Subcategories = c.Subcategories.Select(sc => new SubcategoryVMVC
                {
                    Name = sc.Name,
                    Products = sc.Products.Select(p => new ProductVMVC
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToList(),
                    SubSubCategories = sc.SubSubCategories.Select(ssc => new SubSubCategoryVMVC
                    {
                        Name = ssc.Name,
                        Products = ssc.Products.Select(p => new ProductVMVC
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).ToList()
                    }).ToList()
                }).ToList()
            }));
        }
    }

    public class CategoryVMVC
    {
        public string Name { get; set; }
        public List<SubcategoryVMVC> Subcategories { get; set; }
    }

    public class SubcategoryVMVC
    {
        public string Name { get; set; }
        public List<SubSubCategoryVMVC> SubSubCategories { get; set; }
        public List<ProductVMVC> Products { get; set; } // Продукты без SubSubCategory
    }

    public class SubSubCategoryVMVC
    {
        public string Name { get; set; }
        public List<ProductVMVC> Products { get; set; } // Продукты, относящиеся к SubSubCategory
    }

    public class ProductVMVC
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
