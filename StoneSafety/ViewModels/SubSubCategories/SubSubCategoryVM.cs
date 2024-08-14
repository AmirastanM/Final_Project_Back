using StoneSafety.ViewModels.Products;

namespace StoneSafety.ViewModels.SubSubCategories
{
    public class SubSubCategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductVM> Products { get; set; }
    }
}
