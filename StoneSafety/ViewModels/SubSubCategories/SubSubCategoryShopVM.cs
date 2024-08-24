using StoneSafety.ViewModels.Products;

namespace StoneSafety.ViewModels.SubSubCategories
{
    public class SubSubCategoryShopVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubCategoryName { get; set; }
        public List<ProductShopVM> ProductShops { get; set; }
   
    }
}
