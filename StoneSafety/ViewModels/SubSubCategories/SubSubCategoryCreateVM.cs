using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.SubSubCategories
{
    public class SubSubCategoryCreateVM
    {
        [Required]
        [StringLength(200, ErrorMessage = "The name cannot exceed 200 characters.")]
        public string Name { get; set; } 

        [Required]
        public int SubCategoryId { get; set; }
        public IEnumerable<SelectListItem> SubCategories { get; set; }
    }
}
