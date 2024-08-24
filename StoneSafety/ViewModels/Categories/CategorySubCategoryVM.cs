namespace StoneSafety.ViewModels.Categories
{
    public class CategorySubCategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<SubCategoryVM> Subcategories { get; set; } = new List<SubCategoryVM>();
    }
}
