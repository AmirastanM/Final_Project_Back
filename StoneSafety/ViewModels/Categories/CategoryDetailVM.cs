using System.Collections.Generic;

namespace StoneSafety.ViewModels.Categories
{
    public class CategoryDetailVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public ICollection<string> SubCategories { get; set; } = new List<string>();
        public int SubCategoryCount => SubCategories?.Count ?? 0; 
    }
}
