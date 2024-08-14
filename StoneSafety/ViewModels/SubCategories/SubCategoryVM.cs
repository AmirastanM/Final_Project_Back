using StoneSafety.ViewModels.Products;
using StoneSafety.ViewModels.SubSubCategories;

namespace StoneSafety.ViewModels.SubCategories
{
    public class SubCategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubSubCategoryVM> SubSubCategories { get; set; }
        public ICollection<ProductVM> Products { get; set; }
    }
}
