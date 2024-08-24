using StoneSafety.ViewModels.Products;
using StoneSafety.ViewModels.SubSubCategories;

namespace StoneSafety.ViewModels.SubCategories
{
    public class SubCategoryShopVM
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public List<SubSubCategoryShopVM> SubSubCategoryShops { get; set; }
        public List<ProductShopVM> ProductShops { get; set; } 
     
    }
}
