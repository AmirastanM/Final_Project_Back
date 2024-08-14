using StoneSafety.ViewModels.SubCategories;
using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.Categories
{
    public class CategoryEditVM
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
      
        public ICollection<SubCategoryVM> Subcategories { get; set; } = new List<SubCategoryVM>();
    }
}
