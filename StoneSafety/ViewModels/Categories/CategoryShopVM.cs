using StoneSafety.ViewModels.SubCategories;

namespace StoneSafety.ViewModels.Categories
{
    public class CategoryShopVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategoryShopVM> Subcategories { get; set; }
    }
}
