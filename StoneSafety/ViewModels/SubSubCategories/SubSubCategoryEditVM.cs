using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.SubSubCategories
{
    public class SubSubCategoryEditVM
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(200, ErrorMessage = "Название не может превышать 200 символов.")]
        public string Name { get; set; } 

        [Required]
        public int SubCategoryId { get; set; } 
        public IEnumerable<SelectListItem> SubCategories { get; set; }
    }
}
