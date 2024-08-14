using StoneSafety.ViewModels.SubCategories;
using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.Categories
{
    public class CategoryCreateVM
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public IFormFile Image { get; set; }
       
        public ICollection<SubCategoryVM> Subcategories { get; set; } = new List<SubCategoryVM>();
    }

}
