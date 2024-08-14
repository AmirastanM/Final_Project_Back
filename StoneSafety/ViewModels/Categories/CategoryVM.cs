using StoneSafety.ViewModels.SubCategories;


namespace StoneSafety.ViewModels.Categories
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<SubCategoryVM> Subcategories { get; set; } = new List<SubCategoryVM>();
    }
}
