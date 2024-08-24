
using StoneSafety.Helpers;
using StoneSafety.ViewModels.Products;

namespace StoneSafety.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<StoneSafety.ViewModels.Categories.CategoryShopVM> Categories { get; set; }
        public IEnumerable<StoneSafety.ViewModels.SubCategories.SubCategoryShopVM> SubCategoryShops { get; set; }
        public IEnumerable<StoneSafety.ViewModels.SubSubCategories.SubSubCategoryShopVM> SubSubCategoryShops { get; set; }
        public IEnumerable<StoneSafety.ViewModels.Products.ProductShopVM> Products { get; set; }
      
    }
}

