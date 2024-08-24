using StoneSafety.ViewModels.Products;
using StoneSafety.ViewModels.SubSubCategories;

namespace StoneSafety.ViewModels.SubCategories
{
    public class SubCategoryVM
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<SubSubCategoryVM> SubSubCategories { get; set; } = new List<SubSubCategoryVM>();
        public IEnumerable<ProductVM> Products { get; set; } = new List<ProductVM>();
        public int SubSubCategoryCount => SubSubCategories.Count();
        public int ProductCount => Products.Count();
    }
}
