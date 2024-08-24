namespace StoneSafety.ViewModels.SubCategories
{
    public class SubCategoryDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public ICollection<string> Products { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public ICollection<string> SubSubCategories { get; set; } 
    }
}
