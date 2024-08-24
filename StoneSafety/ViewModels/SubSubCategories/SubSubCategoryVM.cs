using StoneSafety.ViewModels.Products;

namespace StoneSafety.ViewModels.SubSubCategories
{
    public class SubSubCategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubCategoryName { get; set; }   
        public ICollection<ProductVM> Products { get; set; } = new List<ProductVM>();
        public DateTime CreatedDate { get; set; }
        public int ProductCount { get; set; }
    }
}
